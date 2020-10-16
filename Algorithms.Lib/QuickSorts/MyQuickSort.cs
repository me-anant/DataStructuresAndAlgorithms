using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.QuickSorts
{
    public static class MyQuickSort
    {
        public static T[] QuickSort<T>(this T[] array)
        {
            ProcessQuickSort(array, 0, array.Length);

            return array;
        }

        public static T[] QuickSortBy<T, TKey>(this T[] array, Func<T, TKey> keySelector)
        {
            TKey[] keys = new TKey[array.Length];
            int[] map = new int[keys.Length];
            object[] oldMap = new object[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                keys[i] = keySelector(array[i]);
                oldMap[i] = keys.GetValue(i);
            }

            keys.QuickSort();

            for (int i = 0; i < keys.Length; i++)
            {
                int index = Array.IndexOf(oldMap, keys.GetValue(i));
                map[i] = index;
                oldMap[index] = "CLEARED";
            }

            return GetMapOrder(array, map).ToArray();
        }

        private static IEnumerable<T> GetMapOrder<T>(T[] array, int[] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                yield return array[map[i]];
            }
        }

        private static void ProcessQuickSort<T>(T[] array, int bottom, int top)
        {
            if (bottom < top)
            {
                int partitionIndex = Partition(array, bottom, top);

                ProcessQuickSort(array, bottom, partitionIndex - 1);
                ProcessQuickSort(array, partitionIndex, top);
            }
        }

        private static int Partition<T>(T[] array, int bottom, int top)
        {
            T[] arr = new T[top - bottom];
            Array.Copy(array, bottom, arr, 0, top - bottom);

            int pivotIndex = (int)Math.Ceiling((float)(arr.Length / 2));
            T pivot = arr[pivotIndex];

            int partitionIndex = bottom;

            for (int i = bottom; i < top; i++)
            {
                var current = array[i] as IComparable<T>;

                if (current.CompareTo(pivot) < 0)
                {
                    array[i] = array[partitionIndex];
                    array[partitionIndex] = (T)current;
                    if ((bottom + pivotIndex).Equals(partitionIndex))
                    {
                        pivotIndex = i;
                    }
                    partitionIndex++;
                }
            }

            T oldBig = array[partitionIndex];
            if (!pivot.Equals(oldBig))
            {
                array[partitionIndex] = pivot;
                array[bottom + pivotIndex] = oldBig;
            }

            return partitionIndex + 1;
        }
    }
}
