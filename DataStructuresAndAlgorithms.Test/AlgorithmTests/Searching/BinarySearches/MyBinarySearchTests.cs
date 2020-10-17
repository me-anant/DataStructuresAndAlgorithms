using Algorithms.Lib.Searching.BinarySearches;
using System;
using Xunit;

namespace DataStructuresAndAlgorithms.Test.AlgorithmTests.Searching.BinarySearches
{
    public class MyBinarySearchTests
    {
        [Fact]
        public void MyBinarySearch_Equals_One()
        {
            int[] arr = { 350, 78, 5, 4, 80, 65, 17, 1, 9, 53 };

            int key = arr.BinarySearch(1);

            Assert.Equal(1, key);
        }

        [Fact]
        public void MyBinarySearch_Returns_0()
        {
            int[] arr = { 350, 78, 5, 4, 80, 65, 17, 1, 9, 53 };

            int key = arr.BinarySearch(3);

            Assert.Equal(0, key);
        }
    }
}
