using System;
using System.Collections.Generic;
using System.Linq;

namespace Snap.Extenion.Enumerable
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T?> source)
        {
            return source.Where(x => x is not null)!;
        }

        /// <summary>
        /// source.FirstOrDefault(predicate) ?? source.FirstOrDefault();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T? MatchedOrFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.FirstOrDefault(predicate) ?? source.FirstOrDefault();
        }

        /// <summary>
        /// 立即展开迭代器，并对其中的项进行枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// condition ? source.Where(predicate) : source;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereWhen<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
    }
}
