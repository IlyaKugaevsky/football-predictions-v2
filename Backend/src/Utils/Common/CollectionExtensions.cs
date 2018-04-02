using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.Common
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
