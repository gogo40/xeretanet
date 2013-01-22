using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;

namespace xeretanet
{
	public partial class Http
	{
		#region Constants

		private static byte[] _requestGET = ASCIIEncoding.ASCII.GetBytes("GET ");
		private static byte[] _requestPOST = ASCIIEncoding.ASCII.GetBytes("POST ");

		#endregion

		#region Internal parsing functions

		private static Http ParseRequest (TcpPacket packet)
		{
			string payload = ASCIIEncoding.ASCII.GetString (packet.PayloadData);

			var http = new Http ();
			http.Packet = packet;

			// Break the lines by \n.
			var lines = payload.Replace ("\r", "").Split ('\n');

			// The first line is the request itself.
			try {
				var lineData = lines [0].Split (' ');

				http.Method = lineData [0].Trim ();
				http.Uri = lineData [1];
				http.Version = lineData [2].Trim ();
			} catch {
				return null;
			}

			try {
			// The other lines are the headers.
			for (int i = 1; i < lines.Length; i++) {
				var line = lines[i];

				// If we found an empty line, let's stop.
				if (line == "") {
					break;
				}

				// The format of the line must "field: value", otherwise we probably don't have any
				// other headers after that.
				var lineData = line.Split (':');
				if (lineData.Length == 2) {
					http.Headers.Add(lineData[0], lineData[1].Substring(1));
				} else {
					break;
				}
			}
			} catch {
				return null;
			}

			return http;
		}

		#endregion

		#region Parse function

		public static Http Parse (TcpPacket packet)
		{
			// Let's use a more "strict" analysis.
			if (packet.DestinationPort != 80) {
				return null;
			}

			// The easiest way of detecting HTTP stuff is looking at the start of the packet:
			// if there's a "GET " or "POST ", then it's probably HTTP.
			if (packet.PayloadData.StartsWith (_requestGET) || packet.PayloadData.StartsWith (_requestPOST)) {
				// Ok, we have a HTTP packet. So let's work on it.
				return ParseRequest (packet);
			} else {
				return null;
			}
		}

		#endregion


	}
}

