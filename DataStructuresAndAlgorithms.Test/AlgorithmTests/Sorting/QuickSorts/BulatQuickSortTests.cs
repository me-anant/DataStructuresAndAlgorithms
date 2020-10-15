using Algorithms.Lib.QuickSorts;
using Xunit;

namespace DataStructuresAndAlgorithms.Test.AlgorithmTests.Sorting.QuickSorts
{
    public class BulatQuickSortTests
    {
        private BulatQuickSort<int> _bulatQuickSortIntegers = new BulatQuickSort<int>();
        private BulatQuickSort<string> _bulatQuickSortStrings = new BulatQuickSort<string>();

        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayOne()
        {
            int[] arr = { 350, 78, 5, 4, 80, 65, 17, 1, 9, 53 };
            int[] expected = { 1, 4, 5, 9, 17, 53, 65, 78, 80, 350 };

            _bulatQuickSortIntegers.Sort(arr);

            Assert.Equal(expected, arr);
        }

        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayTwo()
        {
            int[] arr = { 5, 4, 80, 65, 17, 1, 9, 53 };
            int[] expected = { 1, 4, 5, 9, 17, 53, 65, 80 };

            _bulatQuickSortIntegers.Sort(arr);

            Assert.Equal(expected, arr);
        }

        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayThree()
        {
            int[] arr = { 5, 4, 80, 65, 9, 31, 458, 17, 1, 9, 53 };
            int[] expected = { 1, 4, 5, 9, 9, 17, 31, 53, 65, 80, 458 };

            _bulatQuickSortIntegers.Sort(arr);

            Assert.Equal(expected, arr);
        }

        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayFour()
        {
            int[] arr = { 5, 4, 80, 65, 17, 1, 9, 53, 913 };
            int[] expected = { 1, 4, 5, 9, 17, 53, 65, 80, 913 };

            _bulatQuickSortIntegers.Sort(arr);

            Assert.Equal(expected, arr);
        }

        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayFive()
        {
            int[] arr = { 1 };
            int[] expected = { 1 };

            _bulatQuickSortIntegers.Sort(arr);

            Assert.Equal(expected, arr);
        }

        [Fact]
        public void MyQuickSortedStringArray_Equals_ExpectedSortedStringArrayOne()
        {
            string[] arr = { "table", "chair", "sky", "river", "coding", "cow", "keyboard", "stocks", "april" };
            string[] expected = { "april", "chair", "coding", "cow", "keyboard", "river", "sky", "stocks", "table" };

            _bulatQuickSortStrings.Sort(arr);

            Assert.Equal(expected, arr);
        }
    }
}