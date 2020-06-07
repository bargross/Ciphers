using System.Collections.Generic;
using System.Linq;

namespace Cipher.Common.Extensions
{
    public static class ListExtension
    {
        public static IEnumerable<T> Backwards<T>(this IEnumerable<T> list)
        {
            for (var x = list.Count(); --x >= 0;)
            {
                yield return list.ElementAt(x);
            }
        }
    }
}
