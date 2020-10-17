using Algorithms.Lib.Sorting.Helpers;
using DataStructures.Lib.Arrays;
using System;
using System.Linq;

namespace Algorithms.Lib.Sorting.MergeSorts
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
            MyDynamicArray<object> map = SortHelper.CreateMap(array, keys, keySelector);

            return SortHelper.OrderByMapToArray(array, map, keys.MergeSort());
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
