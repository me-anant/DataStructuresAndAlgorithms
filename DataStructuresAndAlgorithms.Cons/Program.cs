using DataStructures.Lib.Arrays;
using DataStructures.Lib.Stacks;
using DataStructuresAndAlgorithms.Api.Services;
using System;

namespace DataStructuresAndAlgorithms.Cons
{
    class Program
    {
        private static StackService _stackService;
        private static ArrayService _arrayService;

        static void Main(string[] args)
        {
            _stackService = new StackService();
            _arrayService = new ArrayService();

            // Pass your stack class as an argument in the below method.
            // Run the DataStructuresAndAlgorithms.Cons project to test.
            //_stackService.CompareConsoleStackResult(new MyStack());

            // Pass your dynamic array class as an argument in the below method.
            // For testing purposes use int for your array type arguments.
            // Run the DataStructuresAndAlgorithms.Cons project to test.
            //_arrayService.CompareConsoleArrayResult(new MyDynamicArray<int>());
        }
    }
}
