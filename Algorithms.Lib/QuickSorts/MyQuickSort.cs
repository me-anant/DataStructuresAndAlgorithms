using System;

namespace Algorithms.Lib.QuickSorts
{
    public static class MyQuickSort
    {
        private static int _counter = 0;

        public static int[] QuickSort(this int[] array)
        {
            ProcessQuickSort(array, 0, array.Length);

            _counter = 0;
            return array;
        }

        private static void ProcessQuickSort(int[] array, int bottom, int top)
        {
            if (bottom < top)
            {
                dynamic partitionIndex = Partition(array, bottom, top);

                ProcessQuickSort(array, partitionIndex.Bottom, partitionIndex.Top);
                ProcessQuickSort(array, partitionIndex.Bottom + 1, partitionIndex.Top);
            }

            return;
        }

        private static object Partition(int[] array, int bottom, int top)
        {
            if(_counter >= array.Length)
            {
                return new
                {
                    Bottom = 0,
                    Top = 0
                };
            }

            int[] arr = new int[top - bottom];
            Array.Copy(array, bottom, arr, 0, top - bottom);

            int midPoint = (int)Math.Ceiling((float)arr.Length / 2);

            if (midPoint <= 1)
            {
                return new
                {
                    Bottom = top,
                    Top = array.Length
                };
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr[midPoint]) continue;

                if (arr[i] > arr[midPoint] && midPoint > i)
                {
                    var bigger = arr[i];
                    arr[i] = arr[midPoint];
                    arr[midPoint] = bigger;
                    midPoint = i;
                }

                if (arr[i] < arr[midPoint] && midPoint < i)
                {
                    var smaller = arr[i];
                    var midPointVal = arr[midPoint];
                    arr[midPoint] = smaller;
                    var next = arr[midPoint + 1];
                    arr[midPoint + 1] = midPointVal;
                    if (i != midPoint + 1) arr[i] = next;
                    midPoint++;
                }
            }

            Array.Copy(arr, 0, array, bottom, top - bottom);
            _counter++;

            return new
            {
                Bottom = bottom,
                Top = midPoint + 1
            };
        }
    }
}
