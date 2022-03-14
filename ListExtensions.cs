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
        public static T? GetRandomNotRepeat<T>(this List<T> list, Func<T, bool> checkRepeat)
        {
            if (list.Count >= 2)
            {
                T? random;

                do
                {
                    random = list.GetRandom();
                }
                while (!checkRepeat.Invoke(random!));
                return random;
            }
            else
            {
                return list.GetRandom();
            }
        }
    }
}
