using System.Collections.Generic;

namespace Snap.Extenion.Enumerable
{
    public static class CollectionExtensions
    {
        public static bool IsEmpty<T>(this ICollection<T>? collection)
        {
            return collection is null || collection?.Count == 0;
        }
    }
}
