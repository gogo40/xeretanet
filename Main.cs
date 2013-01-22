using System;
using SharpPcap;
using PacketDotNet;

namespace xeretanet
{
	class MainClass
	{
		private const string VERSION = "0.0";
		private static void runTcpParsers (TcpPacket packet)
		{
			var http = Http.Parse (packet);
			if (http != null) {
				Console.WriteLine (http.Print ());
			}

			var word = WordDetector.Parse (packet);
			if ((word != null) && (word.Found.Count > 0)) {
				Console.WriteLine (word.Print ());
			}
		}

		private static void runUdpParsers (UdpPacket packet)
		{
			//Console.WriteLine ("Got UDP packet!");
		}

		private static void onPacketArrival (object sender, CaptureEventArgs e)
		{
			var packet = Packet.ParsePacket (e.Packet.LinkLayerType, e.Packet.Data);

			// Test for TCP packet.
			TcpPacket tcpPacket = packet.Extract (typeof(TcpPacket)) as TcpPacket;
			if (tcpPacket != null) {
				runTcpParsers (tcpPacket);
			} else {
				// Test for UDP packet
				UdpPacket udpPacket = packet.Extract(typeof(UdpPacket)) as UdpPacket;
				if (udpPacket != null) {
					runUdpParsers (udpPacket);
				}
			}
		}

		public static void Main (string[] args)
		{
			Console.WriteLine("XeretaNET " + VERSION);

			SharpPcap.LibPcap.CaptureFileReaderDevice dev = new SharpPcap.LibPcap.CaptureFileReaderDevice ("/tmp/br1");

			dev.OnPacketArrival += new PacketArrivalEventHandler (onPacketArrival);

			dev.Capture ();
		}
	}
}
