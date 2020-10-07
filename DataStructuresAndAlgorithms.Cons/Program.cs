using DataStructures.Lib;
using System;
using System.Collections;

namespace DataStructuresAndAlgorithms.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareStacks();
        }

        private static void CompareStacks()
        {
            Console.WriteLine("ORIGINAL STACK");
            CreateStack(new Stack());
            Console.WriteLine("*****************************");
            Console.WriteLine("CUSTOM STACK");
            CreateStack(new MyStack());
        }

        private static void CreateStack(dynamic stack)
        {
            stack.Push(1);
            stack.Push("one");
            stack.Push(1.2358);
            Console.WriteLine($"PEEK: {stack.Peek()}");
            stack.Pop();
            stack.Pop();
            stack.Push("On Top");
            stack.Pop();
            stack.Pop();
            stack.Push(DateTime.Now);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
