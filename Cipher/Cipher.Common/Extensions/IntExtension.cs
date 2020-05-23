
using Cipher.Common.Algorithm;

namespace Cipher.Common.Extensions
{
    public static class IntExtension
    {
        public static int GetModInverse(this int value, int modulo)
        {
            return EEucledian.FindModInverse(value, modulo);
        }
    }
}
