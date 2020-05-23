using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher.Common.Shift
{
    public interface IWordShifter: ICharShifter
    {
        string Shift(string word, int shiftCount);
        string UnShift(string word, int shiftCount);
    }
}
