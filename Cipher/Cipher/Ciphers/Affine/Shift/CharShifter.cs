using Cipher.Ciphers.Affine.Char;
using Cipher.Common.Extensions;

namespace Cipher.Ciphers.Affine.Shift
{
    public class CharShifter
    {
        private NumericalCharMap _charMap;

        private int _oddKey;
        private int _randKey;

        public CharShifter(int oddKey, int randKey)
        {
            _charMap = new NumericalCharMap();
            _oddKey = oddKey;
            _randKey = randKey;
        }

        private int CalculateShiftValueInAlphabet(int charOrdinal)
        {
            return (_oddKey * charOrdinal + _randKey) % 26;
        }

        private int CalculateOriginalValueInAlphabet(int charOrdinal)
        {
            return (_oddKey.GetModInverse(_charMap.Count) * (charOrdinal - _randKey)) % 26;
        }

        public char ShiftChar(char character)
        {
            return (char)CalculateShiftValueInAlphabet(_charMap.Get(character));
        }

        public char UnShiftChar(char character)
        {
            return (char)CalculateOriginalValueInAlphabet(character);
        }
    }
}
