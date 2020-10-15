using System;

namespace Algorithms.Lib.QuickSorts
{
    public static class MyQuickSort
    {
        public static T[] QuickSort<T>(this T[] array)
        {
            ProcessQuickSort(array, 0, array.Length);

            return array;
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

            // het heeft met je pivot index te maken...
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
