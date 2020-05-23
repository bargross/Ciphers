using System.Text;
using Cipher.Interface;
using Cipher.Common.Shift;

namespace Cipher.Ciphers.Ceasar
{
	public class CeasarCipher : ISimpleCipher
	{

		private IWordShifter _globalShifter;

		public CeasarCipher()
		{
			_globalShifter = new WordShifter();
		}

		public string Encode(string value)
		{
			return _globalShifter.Shift(value, 3);
		}

		public string Decode(string encodedString)
		{
			return _globalShifter.UnShift(encodedString, 3);
		}
	}
}
