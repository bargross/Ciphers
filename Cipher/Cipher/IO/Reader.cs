using System;

namespace Cipher.IO
{
    public static class Reader
    {
        public static T Read<T>()
        {
            var value = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

            Console.WriteLine(Environment.NewLine);

            return value;
        }
    }
}
