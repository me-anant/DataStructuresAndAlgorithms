using DataStructures.Lib.Arrays;
using DataStructuresAndAlgorithms.Api.Services;
using System.Collections.Generic;
using Xunit;

namespace DataStructuresAndAlgorithms.Test.Tests
{
    public class ArrayTests
    {
        private readonly ArrayService _arrayService;
        public ArrayTests()
        {
            _arrayService = new ArrayService();
        }

        [Fact]
        public void MyDynamicArray_Equals_OriginalArray()
        {
            List<int> originalArray = _arrayService.CreateArray(new List<int>()) as List<int>;
            MyDynamicArray<int> myDynamicArray = _arrayService.CreateArray(new MyDynamicArray<int>()) as MyDynamicArray<int>;

            Assert.Equal(myDynamicArray, originalArray);
        }

        [Fact]
        public void MyDynamicArray_NotEquals_OriginalArray()
        {
            List<int> originalArray = _arrayService.CreateArray(new List<int>()) as List<int>;
            MyDynamicArray<int> myDynamicArray = _arrayService.CreateArray(new MyDynamicArray<int>()) as MyDynamicArray<int>;

            myDynamicArray.Clear();

            Assert.NotEqual(myDynamicArray, originalArray);
        }
    }
}
