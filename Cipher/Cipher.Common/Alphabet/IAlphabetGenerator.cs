using System.Collections.Generic;

namespace Cipher.Common.Alphabet
{
    public interface IAlphabetGenerator
    {
        List<char> FullAlphabet { get;  }
        List<char> CapitalLetters { get; }
        List<char> LowerCaseLetters { get; }
    }
}
