using Cipher.Interface;
using Cipher.Common.Shift;

namespace Cipher.Ciphers.ROT13
{
    public class ROT13Cipher: ISimpleCipher
    {
		private IWordShifter _globalShifter;

		public ROT13Cipher()
		{
			_globalShifter = new WordShifter();
		}

		public string Encode(string value)
		{
			return _globalShifter.Shift(value, 13);
		}

		public string Decode(string encodedString)
		{
			return _globalShifter.UnShift(encodedString, 13);
		}
	}
}
