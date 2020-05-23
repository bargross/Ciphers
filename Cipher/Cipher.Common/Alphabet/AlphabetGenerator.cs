using System.Collections.Generic;

namespace Cipher.Common.Alphabet
{
    public class AlphabetGenerator: IAlphabetGenerator
    {
        public List<char> FullAlphabet
        {
            get
            {
                var fullAlphabet = CapitalLetters;
                fullAlphabet.AddRange(LowerCaseLetters);

                return fullAlphabet;
            }
        }

        public List<char> CapitalLetters 
        { 
            get 
            {
                return Generate(AlphabetASCIIOrdinalBounds.CapitalsASCIIStart, AlphabetASCIIOrdinalBounds.CapitalsASCIIEnd);
            } 
        } 

        public List<char> LowerCaseLetters 
        {
            get
            {
                return Generate(AlphabetASCIIOrdinalBounds.LowerCaseASCIIStart, AlphabetASCIIOrdinalBounds.LowerCaseASCIIEnd);
            }
        }

        private List<char> Generate(int start, int end)
        {
            List<char> characters = new List<char>();
            for(int i = start; i != end; ++i)
            {
                characters.Add((char)i);
            }

            return characters;
        }
    }
}
