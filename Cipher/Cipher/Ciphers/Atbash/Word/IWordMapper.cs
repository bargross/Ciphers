using System.Collections.Generic;

namespace Cipher.Ciphers.Atbash.Word
{
    public interface IWordMapper
    {
        char MapFrom(char character);
        IEnumerable<char> MapMultipleFrom(char[] characters);
        char MapTo(char character);
        IEnumerable<char> MapMultipleTo(char[] characters);

    }
}
