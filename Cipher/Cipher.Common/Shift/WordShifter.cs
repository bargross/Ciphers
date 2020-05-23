using System.Text;

namespace Cipher.Common.Shift
{
    public class WordShifter: CharShifter, IWordShifter
    {
		private StringBuilder _wordBuilder;

		public WordShifter()
		{
			_wordBuilder = new StringBuilder();
		}

        public string Shift(string word, int shiftBy)
        {
			if (string.IsNullOrEmpty(word))
			{
				return string.Empty;
			}

			foreach (char character in word)
			{
				if (character != ' ')
				{
					_wordBuilder.Append(Shift(character, shiftBy));
				}
			}

			var encodedString = _wordBuilder.ToString();

			_wordBuilder.Clear();

			return encodedString;
		}

		public string UnShift(string encodedWord, int shiftBy)
		{
			if (string.IsNullOrEmpty(encodedWord))
			{
				return string.Empty;
			}

			foreach (char character in encodedWord)
			{
				if (character != ' ')
				{
					_wordBuilder.Append(UnShift(character, shiftBy));
				}
			}

			var decodedString = _wordBuilder.ToString();

			_wordBuilder.Clear();

			return decodedString;
		}
    }
}
