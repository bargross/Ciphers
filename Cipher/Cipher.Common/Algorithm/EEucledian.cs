namespace Cipher.Common.Algorithm
{
    public static class EEucledian
    {
		public static int FindModInverse(int value, int modulo)
		{
			var remainder = value % modulo;
			for (var inverse = 1; inverse < modulo; inverse++)
			{
				if ((remainder * inverse) % modulo == 1)
				{
					return inverse;
				}
			}

			return 0; // not found
		}
	}
}
