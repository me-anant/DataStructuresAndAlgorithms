using System.Collections;
using DataStructures.Lib.Stacks;
using DataStructuresAndAlgorithms.Api.Services;
using Xunit;

namespace DataStructuresAndAlgorithms.Test.DataStructureTests.Stacks
{
    public class BMartinStackTest
    {
        private readonly StackService _stackService;
        public BMartinStackTest()
        {
            _stackService = new StackService();
        }

        [Fact]
        public void MyStack_Equals_OriginalStack()
        {
            Stack originalStack = _stackService.CreateStack(new Stack()) as Stack;
            BMartinStack mystack = _stackService.CreateStack(new BMartinStack()) as BMartinStack;

            Assert.Equal<object>(mystack, originalStack);
        }

        [Fact]
        public void MyStack_NotEquals_OriginalStack()
        {
            Stack originalStack = _stackService.CreateStack(new Stack()) as Stack;
            BMartinStack myStack = _stackService.CreateStack(new BMartinStack()) as BMartinStack;

            myStack.Clear();

            Assert.NotEqual<object>(myStack, originalStack);
        }
    }
}