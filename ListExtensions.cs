using Snap.Data.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snap.Extenion.Enumerable
{
    public static class ListExtensions
    {
        /// <summary>
        /// 向列表添加物品，检测是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool AddIfNotNull<T>(this List<T> list, T? item)
        {
            if (item is not null)
            {
                list.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<T> ClonePartially<T>(this List<T> listToClone) where T : IPartiallyCloneable<T>
        {
            return listToClone.Select(item => item.ClonePartially()).ToList();
        }

        private static readonly Lazy<Random> random = new(() => new());
        public static T? GetRandom<T>(this List<T> list)
        {
            return list.Count > 0
                ? list[random.Value.Next(0, list.Count)]
                : default;
        }

        /// <summary>
        /// 在列表中获取随机的不重复项目
        /// 使用默认的比较器比较与上个项目的不同
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="lastItem"></param>
        /// <returns></returns>
        public static T? GetRandomNoRepeat<T>(this List<T> list, T? lastItem)
        {
            if (list.Count >= 2)
            {
                T? random;

                do
                {
                    random = list.GetRandom();
                }
                while (EqualityComparer<T>.Default.Equals(lastItem, random));
                return random;
            }
            else
            {
                return list.GetRandom();
            }
        }

        public static T? GetRandomNoRepeat<T>(this List<T> list, Func<T?, bool> duplicationEvaluator)
        {
            if (list.Count >= 2)
            {
                T? random;

                do
                {
                    random = list.GetRandom();
                }
                while (!duplicationEvaluator.Invoke(random));
                return random;
            }
            else
            {
                return list.GetRandom();
            }
        }
    }
}
