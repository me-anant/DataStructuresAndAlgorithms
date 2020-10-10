using DataStructures.Lib.Arrays;
using DataStructures.Lib.Classes;
using DataStructures.Lib.LinkedLists;
using DataStructures.Lib.Stacks;
using DataStructuresAndAlgorithms.Api.Services;
using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> vs = new LinkedList<int>();
            vs.AddLast(5);
            vs.AddLast(5);
            vs.AddLast(5);
            vs.AddLast(10);
            vs.Remove(5);

            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }
        }
    }
}
