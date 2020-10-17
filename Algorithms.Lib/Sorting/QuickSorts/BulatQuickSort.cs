using System;

namespace Algorithms.Lib.Sorting.QuickSorts
{
    public class BulatQuickSort<T> where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var low = 0;
            var high = array.Length - 1;

            QuickSortImpl(array, low, high);
        }

        private void QuickSortImpl(T[] array, int low, int high)
        {
            if (low < high)
            {
                var pivotIndex = Partition(array, low, high);

                QuickSortImpl(array, low, pivotIndex - 1);
                QuickSortImpl(array, pivotIndex + 1, high);
            }
        }

        /// <param name="array"></param>
        /// <param name="low">starting index</param>
        /// <param name="high">ending index</param>
        /// <returns>index of pivot element after placing it correctly in sorted array</returns>
        private int Partition(T[] array, int low, int high)
        {
            var pivot = array[high];
            
            // Index of smaller element
            var i = low - 1;

            for (var j = low; j <= high - 1; j++)
            {
                // If current element array[j] is less than pivot, swap them
                if (array[j].CompareTo(pivot) < 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }

        private void Swap(T[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}