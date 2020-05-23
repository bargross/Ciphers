using System;
using System.Collections.Generic;

namespace Cipher.Common.Extensions
{
    public static class ListExtension
    {
        public static IEnumerable<T> Backwards<T>( this IList<T> list)
        {
            for (int x = list.Count; --x >= 0;)
            {
                yield return list[x];
            }
        }
    }
}
