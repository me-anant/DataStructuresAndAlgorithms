using System;
using System.Collections;
using System.Linq;

namespace DataStructuresAndAlgorithms.Api.Services
{
    public class StackService
    {
        public static void CompareStackResult(object yourStack)
        {
            if (yourStack is null)
                throw new ArgumentNullException(nameof(yourStack), "The parameter can not be null");

            if (yourStack is Stack)
                throw new InvalidOperationException("Use your own stack implementation when calling this method.");

            ThrowInValidOperationExceptionIfMethodNotFound(yourStack, "Push", "Pop", "Peek", "ToArray", "Contains", "Clear");

            Console.WriteLine("\n" + yourStack.GetType()?.Name);
            Console.WriteLine("---------------------------------");
            object customStack = CreateStack(yourStack);
            Console.WriteLine("*****************************");
            Console.WriteLine("\nORIGINAL STACK");
            Console.WriteLine("---------------------------------");
            Stack originalStack = CreateStack(new Stack()) as Stack;

            Console.WriteLine("============================================");
            if (Enumerable.SequenceEqual(originalStack.ToArray(),
                yourStack.GetType().GetMethod("ToArray").Invoke(customStack, null) as object[]))
                Console.WriteLine("\nThe Stacks are equal; you created a correct implementation of a Stack.");
            else Console.WriteLine("\nThe Stacks are not equal; you will have to try a different implementation.");
        }

        private static object CreateStack(dynamic stack)
        {
            stack.Push(1);
            stack.Push("one");
            stack.Push(1.2358);
            Console.WriteLine($"PEEK: {stack.Peek()}");
            stack.Pop();
            stack.Pop();
            stack.Push("On Top");
            stack.Pop();
            stack.Push(DateTime.Now.ToShortDateString());
            Console.WriteLine($"Stack Count: {stack.Count}");
            Console.WriteLine($"Stack Contains 'one' ?: {stack.Contains("one")}");
            Console.WriteLine($"Stack Contains 1: {stack.Contains(1)}");
            stack.Clear();
            Console.WriteLine($"Stack cleared; Stack Count: {stack.Count}");
            Console.WriteLine($"Stack Contains 1 ?: {stack.Contains(1)}");
            stack.Push("BOTTOM");
            stack.Push(500);
            ConsoleWriteStackResults(stack);
            return stack;
        }

        private static void ConsoleWriteStackResults(dynamic stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }

        private static void ThrowInValidOperationExceptionIfMethodNotFound(object stack, params string[] methodNames)
        {
            foreach (string methodName in methodNames)
            {
                if (stack.GetType()?.GetMethod(methodName) is null)
                    throw new InvalidOperationException($"The required '{methodName}' method was not found in the '{stack.GetType().Name}' class");
            }
        }
    }
}
