using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;

namespace xeretanet
{
	public partial class Http
	{
		public TcpPacket Packet { get; set; }

		public string Method { get; set; }
		public string Uri { get; set; }
		public string Version { get; set; }
		public Dictionary<string, string> Headers { get; set; }

		public Http ()
		{
			this.Headers = new Dictionary<string, string>();
		}

		public string Print ()
		{
			StringBuilder builder = new StringBuilder ();

			builder.Append("[");
			builder.Append ((this.Packet.ParentPacket as IPv4Packet).SourceAddress);
			builder.Append ("] [HTTP] [");
			builder.Append (this.Method);
			builder.Append ("] http://");

			if (this.Headers.ContainsKey ("Host")) {
				builder.Append (this.Headers ["Host"]);
			} else {
				builder.Append ((this.Packet.ParentPacket as IpPacket).DestinationAddress);
			}

			builder.Append (this.Uri);
			builder.Append("\n");

			return builder.ToString ();
		}
	}
}

