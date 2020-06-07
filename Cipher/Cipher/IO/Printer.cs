using System;

namespace Cipher.IO
{
    public static class Printer
    {
        public static void Print<T>(T content)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(content);
            Console.WriteLine(Environment.NewLine);
        }
    }
}
