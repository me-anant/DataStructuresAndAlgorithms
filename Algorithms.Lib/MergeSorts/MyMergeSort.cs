using System;

namespace Algorithms.Lib.MergeSorts
{
    public static class MyMergeSort
    {
        private static int[] _array;
        private static int _midPoint;
        private static int _beginPoint = 0;
        private static int _counter = 0;

        public static void MergeSort(this int[] array)
        {
            if (_array is null) _array = array;
            _midPoint = (int)Math.Ceiling((float)array.Length / 2);
            ProcessMergeSort(array);
        }

        private static void ProcessMergeSort(int[] array, int sourceIndex = 0)
        {
            var midPoint = (int)Math.Ceiling((float)array.Length / 2);
            int rightArrayLength = array.Length - midPoint;

            var leftArray = new int[midPoint];
            Array.Copy(array, 0, leftArray, 0, midPoint);

            var rightArray = new int[rightArrayLength];
            Array.Copy(array, midPoint, rightArray, 0, rightArrayLength);


            if (0 < array.Length - 1)
            {
                _counter++;

                if (_counter > _midPoint) _beginPoint = _midPoint;

                ProcessMergeSort(leftArray, _beginPoint);

                if (_counter > _midPoint) _beginPoint = midPoint + _midPoint;
                else _beginPoint = midPoint;

                ProcessMergeSort(rightArray, _beginPoint);

                Merge(midPoint, rightArrayLength, sourceIndex);
            }

            return;
        }

        private static void Merge(int l, int r, int sourceIndex)
        {
            var leftArray = new int[l];
            Array.Copy(_array, sourceIndex, leftArray, 0, l);

            var rightArray = new int[r];
            Array.Copy(_array, sourceIndex + l, rightArray, 0, r);

            int leftTracker = 0;
            int rightTracker = 0;

            var currentPosition = sourceIndex;

            while (leftTracker < leftArray.Length && rightTracker < rightArray.Length)
            {
                if (leftArray[leftTracker] <= rightArray[rightTracker])
                {
                    _array[currentPosition] = leftArray[leftTracker];
                    leftTracker++;
                }
                else
                {
                    _array[currentPosition] = rightArray[rightTracker];
                    rightTracker++;
                }
                currentPosition++;
            }

            while (leftTracker < leftArray.Length)
            {
                _array[currentPosition] = leftArray[leftTracker];
                leftTracker++;
                currentPosition++;
            }

            while (rightTracker < rightArray.Length)
            {
                _array[currentPosition] = rightArray[rightTracker];
                rightTracker++;
                currentPosition++;
            }
        }
    }
}
