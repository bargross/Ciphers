using System.Collections.Generic;

namespace Cipher.Ciphers.Atbash.Dictionary
{
    public interface ICharDictionary
    {
        char Replace(char character);
        IEnumerable<char> ReplaceMultiple(char[] characters);
    }
}
