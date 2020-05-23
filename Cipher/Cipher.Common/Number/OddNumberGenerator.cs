namespace Cipher.Common.Number
{
    public class OddNumberGenerator
    {
        private int GetAdditionalFactor(int from, int to) => from % 2 == 0 & to % 2 == 0 ? 0 : 1;

        public int[] GetNumbersBetween(int from, int to)
        {
            int numberOfOddValuesInSequence = (to - from) / 2 + GetAdditionalFactor(from, to);
            int[] oddNumbers = new int[numberOfOddValuesInSequence];

            int index = 0;
            for(int i = from; i < to; ++i)
            {
                if(i % 2 != 0)
                {
                    oddNumbers[index] = i;
                }
            }

            return oddNumbers;
        }

    }
}
