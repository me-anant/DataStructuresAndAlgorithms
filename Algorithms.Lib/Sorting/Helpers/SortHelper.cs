using DataStructures.Lib.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.Sorting.Helpers
{
    public static class SortHelper
    {
        internal static T[] OrderByMapToArray<T, TKey>(T[] array, MyDynamicArray<object> map, TKey[] keys)
        {
            return OrderByMap(array, map, keys).ToArray();
        }

        internal static IEnumerable<T> OrderByMap<T, TKey>(T[] array, MyDynamicArray<object> map, TKey[] keys)
        {
            for (int i = 0; i < map.Length; i++)
            {
                int index = map.IndexOf(keys.GetValue(i));
                map[index] = $"CLEARED_{Guid.NewGuid()}";
                yield return array[index];
            }
        }

        internal static MyDynamicArray<object> CreateMap<T, TKey>(T[] array, TKey[] keys, Func<T, TKey> keySelector)
        {
            MyDynamicArray<object> map = new MyDynamicArray<object>(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                keys[i] = keySelector(array[i]);
                map[i] = keys.GetValue(i);
            }

            return map;
        }
    }
}
