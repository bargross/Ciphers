using System.Linq;
using System.Collections.Generic;

using Cipher.Common.Alphabet;
using Cipher.Ciphers.Atbash.Dictionary;
using Cipher.Common.Extensions;

namespace Cipher.Ciphers.Atbash.Word
{
    public class WordMapper: IWordMapper
    {
        private CharDictionary _forwardDictionary;
        private CharDictionary _inverseDictionary;

        public WordMapper()
        {
            AlphabetGenerator generator = new AlphabetGenerator();
            var upperCase = generator.CapitalLetters;
            var lowerCase = generator.LowerCaseLetters;

            _forwardDictionary = new CharDictionary(upperCase, lowerCase);
            _inverseDictionary = new CharDictionary(upperCase.Backwards().ToList(), lowerCase.Backwards().ToList());
        }

        public char MapTo(char character) => _forwardDictionary.Replace(character);
        public IEnumerable<char> MapMultipleTo(char[] characters) => _forwardDictionary.ReplaceMultiple(characters);
        public char MapFrom(char character) => _inverseDictionary.Replace(character);
        public IEnumerable<char> MapMultipleFrom(char[] characters) => _inverseDictionary.ReplaceMultiple(characters);
    }
}
