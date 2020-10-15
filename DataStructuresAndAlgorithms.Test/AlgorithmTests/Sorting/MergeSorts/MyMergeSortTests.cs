using Algorithms.Lib.MergeSorts;
using System.Collections.Immutable;
using Xunit;

namespace DataStructuresAndAlgorithms.Test.AlgorithmTests.Sorting.MergeSorts
{
    public class MyMergeSortTests
    {
        [Fact]
        public void MyMergeSortedIntArray_Equals_ExpectedSortedIntArray()
        {
            int[] arr = { 5, 4, 30, 1, 7, 58, 111, 777, 666, 2, 17 };

            Assert.Equal(arr.ToImmutableSortedSet(), arr.MergeSort());
        }
    }
}
