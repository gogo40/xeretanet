using System;

namespace xeretanet
{
	public static class Extensions
	{
		public static bool StartsWith (this byte[] array, byte[] other)
		{
			for (int i = 0; i < other.Length; i++) {
				if ((i >= array.Length) || (array [i] != other [i])) {
					return false;
				}
			}

			return true;
		}

		public static bool Contains (this byte[] array, byte[] other)
		{
			int j = 0;

			for (int i = 0; i < array.Length; i++) {
				if (array[i] == other[j]) {
					if (j == other.Length-1) {
						return true;
					} else {
						j++;
					}
				} else {
					if (j > 0) {
						//i = i-(j-1);
						i--;
					}
					j = 0;
				}
			}

			return false;
		}
	}
}

