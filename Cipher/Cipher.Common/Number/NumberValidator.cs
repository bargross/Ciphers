namespace Cipher.Common.Number
{
    public static class NumberValidator
    { 
        public static bool IsOdd(int number)  => number % 2 != 0;

        public static bool IsEven(int number) => number % 2 == 0;
    }
}
