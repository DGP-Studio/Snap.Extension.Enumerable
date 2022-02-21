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

        private static Lazy<Random> random = new(() => new());
        public static T? GetRandom<T>(this List<T> list)
        {
            return list.Count > 0
                ? list[random.Value.Next(0, list.Count)]
                : default;
        }
    }
}
