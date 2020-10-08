using System;
using System.Collections;
using System.Linq;

namespace DataStructuresAndAlgorithms.Api.Services
{
    public class StackService : AsideService
    {
        public void CompareStackResult(object yourStack)
        {
            if (yourStack is null)
                throw new ArgumentNullException(nameof(yourStack), "The parameter can not be null");

            if (yourStack is Stack)
                throw new InvalidOperationException("Use your own stack implementation when calling this method.");

            ThrowInValidOperationExceptionIfAnyMethodNotFoundOfTheGivenMethods(yourStack, "Push", "Pop", "Peek", "ToArray", "Contains", "Clear");

            Console.WriteLine("\n" + yourStack.GetType()?.Name);
            Console.WriteLine("---------------------------------");
            object customStack = CreateStack(yourStack);
            Console.WriteLine("*****************************");
            Console.WriteLine("\nORIGINAL STACK");
            Console.WriteLine("---------------------------------");
            Stack originalStack = CreateStack(new Stack()) as Stack;

            Console.WriteLine("============================================");
            if (Enumerable.SequenceEqual(originalStack.ToArray(),
                yourStack.GetType().GetMethod("ToArray").Invoke(customStack, null) as object[])
                && string.Equals(OriginalOutputs, CustomOutputs))
                Console.WriteLine("\nThe Stacks are equal; you created a correct implementation of a Stack.");
            else Console.WriteLine("\nThe Stacks are not equal; you will have to try a different implementation.");
        }

        private object CreateStack(dynamic stack)
        {
            string outputs = "";

            stack.Push(1);
            stack.Push("one");
            stack.Push(1.2358);
            outputs += $"PEEK: {stack.Peek()}";
            Console.WriteLine($"PEEK: {stack.Peek()}");
            stack.Pop();
            stack.Pop();
            stack.Push("On Top");
            stack.Pop();
            outputs += $"Stack Count: {stack.Count}Stack Contains 'one' ?: {stack.Contains("one")}Stack Contains 1: {stack.Contains(1)}";
            Console.WriteLine($"Stack Count: {stack.Count}");
            Console.WriteLine($"Stack Contains 'one' ?: {stack.Contains("one")}");
            Console.WriteLine($"Stack Contains 1: {stack.Contains(1)}");
            stack.Clear();
            outputs += $"Stack cleared; Stack Count: {stack.Count}Stack Contains 1 ?: {stack.Contains(1)}";
            Console.WriteLine($"Stack cleared; Stack Count: {stack.Count}");
            Console.WriteLine($"Stack Contains 1 ?: {stack.Contains(1)}");
            stack.Push("BOTTOM");
            stack.Push(DateTime.Now.ToShortDateString());
            stack.Push(500);

            SetupOutputs(stack, outputs, typeof(Stack));
            ConsoleWriteResults(stack, typeof(Stack));
            return stack;
        }
    }
}
