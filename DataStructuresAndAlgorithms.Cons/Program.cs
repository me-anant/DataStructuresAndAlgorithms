using DataStructures.Lib.Arrays;
using DataStructures.Lib.Stacks;
using DataStructuresAndAlgorithms.Api.Services;
using System;
using System.Collections.Generic;

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

            //_stackService.CompareConsoleStackResult(new MyStack());

            //_arrayService.CompareConsoleArrayResult(new MyDynamicArray<int>());

        }
    }
}
