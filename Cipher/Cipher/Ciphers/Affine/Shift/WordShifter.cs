using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher.Ciphers.Affine.Shift
{
    public class WordShifter: CharShifter
    {
        public WordShifter(int oddKey, int randKey): base(oddKey, randKey) { }

        public string ShiftWord(string phrase)
        {
            var builder = new StringBuilder();
            foreach(char character in phrase)
            {
                if(character != ' ')
                {
                    builder.Append(ShiftChar(character));
                }
            }

            return builder.ToString();
        }

        public string UnShiftWord(string encodedString)
        {
            var builder = new StringBuilder();
            foreach (char character in encodedString)
            {
                if (character != ' ')
                {
                    builder.Append(UnShiftChar(character));
                }
            }

            return builder.ToString();
        }
    }
}
