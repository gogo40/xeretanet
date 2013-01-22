using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;

namespace xeretanet
{
	public partial class WordDetector
	{
		public TcpPacket Packet { get; set; }

		public List<string> Found { get; set; }

		public WordDetector ()
		{
			this.Found = new List<string>();
		}

		public string Print ()
		{
			StringBuilder builder = new StringBuilder ();

			builder.Append("[");
			builder.Append ((this.Packet.ParentPacket as IpPacket).SourceAddress);
			builder.Append ("] [WORD] Found: ");
			builder.Append (String.Join (",", this.Found));
			builder.Append("\n");

			return builder.ToString ();
		}
	}
}

