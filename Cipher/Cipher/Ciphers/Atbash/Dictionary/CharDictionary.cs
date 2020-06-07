using System;
using System.Linq;
using System.Collections.Generic;

using Cipher.Common.Extensions;

namespace Cipher.Ciphers.Atbash.Dictionary
{
    public class CharDictionary: ICharDictionary
    {
        private IDictionary<char, char> _upperCaseLettersDictionary;
        private IDictionary<char, char> _lowerCaseLettersDictionary;

        public CharDictionary(List<char> upperCase, List<char> lowerCase)
        {
            _upperCaseLettersDictionary = new Dictionary<char, char>();
            _lowerCaseLettersDictionary = new Dictionary<char, char>();
           
            Map(upperCase, upperCase.Backwards().ToList(), LetterTypeEnum.UPPERCASE);
            Map(lowerCase, lowerCase.Backwards().ToList(), LetterTypeEnum.LOWERCASE);
        }

        private void Map(IEnumerable<char> from, IEnumerable<char> to, LetterTypeEnum type)
        {
            if(from.Count() - to.Count() != 0)
            {
                throw new ArgumentException("Length of lists must match");
            }

            switch(type)
            {
                case LetterTypeEnum.UPPERCASE:
                    AddToMap(_upperCaseLettersDictionary, from, to);
                    break;
                case LetterTypeEnum.LOWERCASE:
                    AddToMap(_lowerCaseLettersDictionary, from, to);
                    break;
                default: throw new ArgumentException("Invalid char type");
            }
        }

        private void AddToMap(IDictionary<char, char> container, IEnumerable<char> keys, IEnumerable<char> values)
        {
            for(int i = 0; i < keys.Count(); ++i)
            {
                container.Add(keys.ElementAt(i), values.ElementAt(i));
            }
        }

        private bool Contains(char keyCharacter)
        {
            var type = MapCharTypeToEnum(keyCharacter);
            if (type == LetterTypeEnum.UPPERCASE)
            {
                return _upperCaseLettersDictionary.ContainsKey(keyCharacter);
            }

            return _lowerCaseLettersDictionary.ContainsKey(keyCharacter);
        }

        private LetterTypeEnum MapCharTypeToEnum(char character) => char.IsUpper(character) ? LetterTypeEnum.UPPERCASE : LetterTypeEnum.LOWERCASE;

        public char Replace(char character)
        {
            var type = MapCharTypeToEnum(character);
            switch(type)
            {
                case LetterTypeEnum.UPPERCASE:
                    if(!Contains(character))
                    {
                        throw new ArgumentException("Invalid char");
                    }

                    return _upperCaseLettersDictionary[character];
                case LetterTypeEnum.LOWERCASE:
                    if (!Contains(character))
                    {
                        throw new ArgumentException("Invalid char");
                    }
                    return _lowerCaseLettersDictionary[character];
                default:
                    throw new ArgumentException("Invalid char");
            }
        }

        public IEnumerable<char> ReplaceMultiple(char[] characters)
        {
            if(characters == null || characters.Length == 0)
            {
                throw new ArgumentException("Invalid collection");
            }

            var container = characters.Select(Replace);

            return container;
        }
    }
}
