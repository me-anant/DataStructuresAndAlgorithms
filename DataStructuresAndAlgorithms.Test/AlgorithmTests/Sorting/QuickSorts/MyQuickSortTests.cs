using Algorithms.Lib.QuickSorts;
using Xunit;

namespace DataStructuresAndAlgorithms.Test.AlgorithmTests.Sorting.QuickSorts
{
    public class MyQuickSortTests
    {
        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayOne()
        {
            int[] arr = { 350, 78, 5, 4, 80, 65, 17, 1, 9, 53 };
            int[] expected = { 1, 4, 5, 9, 17, 53, 65, 78, 80, 350 };

            var actual = arr.QuickSort();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayTwo()
        {
            string[] arr = { "sit", "down", "on", "the", "ground", "david" };
            string[] expected = { "david", "down", "ground", "on", "sit", "the" };

            var actual = arr.QuickSort();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayThree()
        {
            int[] arr = { 5, 4, 80, 65, 9, 31, 458, 17, 1, 9, 53 };
            int[] expected = { 1, 4, 5, 9, 9, 17, 31, 53, 65, 80, 458 };

            var actual = arr.QuickSort();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MyQuickSortedIntArray_Equals_ExpectedSortedIntArrayFour()
        {
            char[] arr = { 'd', 'z', 'w', '3', 'f', 'z', 'g', 'b', 't' };
            char[] expected = { '3', 'b', 'd', 'f', 'g', 't', 'w', 'z', 'z' };

            var actual = arr.QuickSort();

            Assert.Equal(expected, actual);
        }
    }
}
