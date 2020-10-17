using Algorithms.Lib.Helpers;
using Algorithms.Lib.Sorting.Helpers;
using DataStructures.Lib.Arrays;
using System;

namespace Algorithms.Lib.Sorting.QuickSorts
{
    public static class MyQuickSort
    {
        public static T[] QuickSort<T>(this T[] array)
        {
            AlgorithmsHelper.ThrowArgumentExceptionIfDataTypeIsClassAndNotString(typeof(T));

            ProcessQuickSort(array, 0, array.Length);
            return array;
        }

        public static T[] QuickSortBy<T, TKey>(this T[] array, Func<T, TKey> keySelector)
        {
            TKey[] keys = new TKey[array.Length];
            MyDynamicArray<object> map = SortHelper.CreateMap(array, keys, keySelector);

            return SortHelper.OrderByMapToArray(array, map, keys.QuickSort());
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
