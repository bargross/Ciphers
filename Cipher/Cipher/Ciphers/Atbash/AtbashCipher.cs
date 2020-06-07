using System.Text;

using Cipher.Ciphers.Atbash.Word;
using Cipher.Interface;

namespace Cipher.Ciphers.Atbash
{
    public class AtbashCipher: ISimpleCipher
    {
        private IWordMapper _wordMapper;
        private StringBuilder _wordbuilder;

        public AtbashCipher()
        {
            _wordMapper = new WordMapper();
            _wordbuilder = new StringBuilder();
        }

        public string Encode(string words)
        {
            foreach(char character in words)
            {
                _wordbuilder.Append(_wordMapper.MapTo(character));
            }

            var encodedWords = _wordbuilder.ToString();
            _wordbuilder.Clear();

            return encodedWords;
        }

        public string Decode(string encodedString)
        {
            foreach (char character in encodedString)
            {
                _wordbuilder.Append(_wordMapper.MapFrom(character));
            }

            var decodedWords = _wordbuilder.ToString();
            _wordbuilder.Clear();

            return decodedWords;
        }

        // TODO: current ISimpleCipher interface cannot support these methods, otherwise it'd force any other cipher using the same interface
        // to implement these. They either need to be move only a new interface with its new type or modify the current interface to satisfy these additional methods
        public string EncodeAll(string[] phrases)
        {
            foreach (string phrase in phrases)
            {
                _wordbuilder.Append($"{_wordMapper.MapMultipleTo(phrase.ToCharArray())}, ");
            }

            var encodedPhrases = _wordbuilder.ToString();
            _wordbuilder.Clear();

            return encodedPhrases;
        }

        public string DecodeAll(string[] encodedPhrases)
        {
            foreach (string phrase in encodedPhrases)
            {
                _wordbuilder.Append($"{_wordMapper.MapMultipleFrom(phrase.ToCharArray())}, ");
            }

            var decodedPhrases = _wordbuilder.ToString();
            _wordbuilder.Clear();

            return decodedPhrases;
        }
    }
}
