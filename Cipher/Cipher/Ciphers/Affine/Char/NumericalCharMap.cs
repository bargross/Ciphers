using System;
using System.Collections.Generic;

using Cipher.Ciphers.Atbash.Dictionary;
using Cipher.Common.Alphabet;

namespace Cipher.Ciphers.Affine.Char
{
    public class NumericalCharMap
    {
        private IDictionary<LetterTypeEnum, IDictionary<char, int>> _charOrdinalMap;
        private IAlphabetGenerator _alphabetGenerator;

        public int Count { get; } = 0;

        public NumericalCharMap()
        {
            _charOrdinalMap = new Dictionary<LetterTypeEnum, IDictionary<char, int>>()
            {
                { LetterTypeEnum.UPPERCASE, new Dictionary<char, int>()  },
                { LetterTypeEnum.LOWERCASE, new Dictionary<char, int>() }
            };

            _alphabetGenerator = new AlphabetGenerator();
            Populate(LetterTypeEnum.UPPERCASE, _alphabetGenerator.CapitalLetters);
            Populate(LetterTypeEnum.LOWERCASE, _alphabetGenerator.LowerCaseLetters);

            Count = _charOrdinalMap[LetterTypeEnum.UPPERCASE].Count;
        }

        private void Populate(LetterTypeEnum type, List<char> chars)
        {
            if (chars.Count > 25)
            {
                throw new ArgumentException("Expected alphabet of length 25");
            }

            IDictionary<char, int> charMap = new Dictionary<char, int>();
            for (int i = 0; i < chars.Count; ++i)
            {
                _charOrdinalMap[type].Add(chars[i], i);
            }
        }

        private bool IsAlphabeticalCharacter(char character)
        {
            return _charOrdinalMap[LetterTypeEnum.UPPERCASE].ContainsKey(character)
                || _charOrdinalMap[LetterTypeEnum.LOWERCASE].ContainsKey(character);
        }

        private LetterTypeEnum GetLetterType(char character) => char.IsUpper(character) ? LetterTypeEnum.UPPERCASE : LetterTypeEnum.LOWERCASE;

        public int Get(char character)
        {
            if (!IsAlphabeticalCharacter(character))
            {
                throw new ArgumentException("Invalid character");
            }

            var letterType = GetLetterType(character);
            return _charOrdinalMap[letterType][character];
        }
    }
}
