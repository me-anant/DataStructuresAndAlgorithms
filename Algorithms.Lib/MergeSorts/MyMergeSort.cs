using DataStructures.Lib.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.MergeSorts
{
    public static class MyMergeSort
    {
        public static T[] MergeSort<T>(this T[] array)
        {
            ProcessMergeSort(array, 0, array.Length - 1);
            return array;
        }

        public static T[] MergeSortBy<T, TKey>(this T[] array, Func<T, TKey> keySelector)
        {
            TKey[] keys = new TKey[array.Length];
            MyDynamicArray<object> map = new MyDynamicArray<object>(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                keys[i] = keySelector(array[i]);
                map[i] = keys.GetValue(i);
            }

            keys.MergeSort();

            return GetMapOrder(array, map, keys).ToArray();
        }

        private static IEnumerable<T> GetMapOrder<T, TKey>(T[] array, MyDynamicArray<object> map, TKey[] keys)
        {
            for (int i = 0; i < map.Length; i++)
            {
                int index = map.IndexOf(keys.GetValue(i));
                map[index] = $"CLEARED_{Guid.NewGuid()}" ;
                yield return array[index];
            }
        }

        private static void ProcessMergeSort<T>(T[] array, int bottom, int top)
        {
            if (bottom < top)
            {
                int middle = bottom + (top - bottom) / 2;

                ProcessMergeSort(array, bottom, middle);
                ProcessMergeSort(array, middle + 1, top);

                Merge(array, bottom, middle, top);
            }
        }

        private static void Merge<T>(T[] array, int bottom, int middle, int top)
        {
            T[] leftArray = new T[middle - bottom + 1];
            Array.Copy(array, bottom, leftArray, 0, middle - bottom + 1);

            T[] rightArray = new T[top - middle];
            Array.Copy(array, middle + 1, rightArray, 0, top - middle);

            int mainIndex = bottom;
            int leftTracker = 0;
            int rightTracker = 0;

            while (leftTracker < leftArray.Length && rightTracker < rightArray.Length)
            {
                IComparable<T> currentLeft = leftArray[leftTracker] as IComparable<T>;

                if (currentLeft.CompareTo(rightArray[rightTracker]) <= 0)
                {
                    array[mainIndex] = leftArray[leftTracker];
                    leftTracker++;
                }
                else
                {
                    array[mainIndex] = rightArray[rightTracker];
                    rightTracker++;
                }
                mainIndex++;
            }

            while (leftTracker < leftArray.Length)
            {
                array[mainIndex] = leftArray[leftTracker];
                leftTracker++;
                mainIndex++;
            }

            while (rightTracker < rightArray.Length)
            {
                array[mainIndex] = rightArray[rightTracker];
                rightTracker++;
                mainIndex++;
            }
        }
    }
}
