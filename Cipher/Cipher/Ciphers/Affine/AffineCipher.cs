using System;
using Cipher.Interface;
using Cipher.Ciphers.Affine.Shift;

namespace Cipher.Ciphers.Affine
{
    public class AffineCipher: IComplexCipher
    {
        public WordShifter _wordShifter;
         
        public string Encode(string value)
        {
            if(_wordShifter == null)
            {
                throw new ArgumentNullException("Missing odd and rand keys missing");
            }

            return _wordShifter.ShiftWord(value);
        }

        public string Decode(string encodedString)
        {
            if (_wordShifter == null)
            {
                throw new ArgumentNullException("Missing odd and rand keys missing");
            }

            return _wordShifter.UnShiftWord(encodedString);
        }

        public void Set<T>(T keys) where T: Common.Model.Keys.IKeys<int>
        {
            var oddKey = keys.KeyOne;
            var randKey = keys.KeyTwo;

            _wordShifter = new WordShifter(oddKey, randKey);
        }
    }
}
