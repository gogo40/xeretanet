using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;

namespace xeretanet
{
	public partial class WordDetector
	{
		#region Constants

		private static string[] _words = new string[] {
			"facebook",
			"Facebook"
		};

		#endregion

		#region Internal parsing functions

		private static WordDetector FindWords (TcpPacket packet)
		{
			var word = new WordDetector ();
			word.Packet = packet;

			// For each one word in the list, convert to byte and check if it's inside or not.
			foreach (string s in _words) {
				var sb = ASCIIEncoding.ASCII.GetBytes (s);

				if (!word.Found.Contains(s) && packet.PayloadData.Contains(sb)) {
					word.Found.Add (s);
				}
			}

			return word;
		}

		#endregion

		#region Parse function

		public static WordDetector Parse (TcpPacket packet)
		{
			return FindWords(packet);
		}

		#endregion


	}
}

