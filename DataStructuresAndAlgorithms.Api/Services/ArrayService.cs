using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.Api.Services
{
    public class ArrayService : BaseService
    {
        public void CompareConsoleArrayResult(object yourArray)
        {
            if (yourArray is null)
                throw new ArgumentNullException(nameof(yourArray), "The parameter can not be null");

            Type type = yourArray.GetType().GetGenericArguments().SingleOrDefault();
            if (type == null || type != typeof(int))
                throw new InvalidOperationException("Please use 'int' as type arguments for your array when testing.");

            ThrowInValidOperationExceptionIfAnyMethodNotFoundOfTheGivenMethods(yourArray, "Add", "Remove", "RemoveAt", "IndexOf", "Contains", "Clear");

            Console.WriteLine("\n" + yourArray.GetType()?.Name);
            Console.WriteLine("---------------------------------");
            IEnumerable<int> customArray = CreateConsoleArray(yourArray) as IEnumerable<int>;
            Console.WriteLine("*****************************");
            Console.WriteLine("\nORIGINAL");
            Console.WriteLine("---------------------------------");
            List<int> originalArray = CreateConsoleArray(new List<int>()) as List<int>;
            Console.WriteLine("============================================");
            if (Enumerable.SequenceEqual(originalArray, customArray)
                && string.Equals(OriginalOutputs, CustomOutputs))
                Console.WriteLine("\nThe Arrays are equal; you created a correct implementation of a Dynamic Array.");
            else Console.WriteLine("\nThe Arrays are not equal; you will have to try a different implementation.");
        }

        /// <summary>
        /// Performs some predefined actions on a dynamic array or any type that implements the dynamic array data structure.
        /// </summary>
        /// <param name="stack">The dynamic array to perform some actions upon.</param>
        /// <returns>
        /// The provided dynamic array with some pre defined values.
        /// </returns>
        public object CreateArray(dynamic array)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array), "The parameter can not be null");

            ThrowInValidOperationExceptionIfAnyMethodNotFoundOfTheGivenMethods(array, "Add", "Remove", "RemoveAt", "IndexOf", "Contains", "Clear");

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Remove(3);
            array.Clear();
            array.Add(1000);
            array.Add(2000);
            array.Add(3000);
            array[1] = 5;
            array.RemoveAt(2);

            return array;
        }

        private object CreateConsoleArray(dynamic array)
        {
            string outputs = "";
            bool isList = array.GetType() == typeof(List<int>);

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Remove(3);
            outputs += $"Index of '1': {array.IndexOf(1)}";
            Console.WriteLine($"Index of '1': {array.IndexOf(1)}");
            outputs += $"Array Length: {(isList ? array.Count : array.Length)}Array Contains '5' ?: {array.Contains(5)}Array Contains '3' ?: {array.Contains(3)}";
            Console.WriteLine($"Array Length: {(isList ? array.Count : array.Length)}");
            Console.WriteLine($"Array Contains '5' ?: {array.Contains(5)}");
            Console.WriteLine($"Array Contains '3' ?: {array.Contains(3)}");
            array.Clear();
            outputs += $"Array Cleared; Array Length: {(isList ? array.Count : array.Length)}Array Contains '1' ?: {array.Contains(1)}";
            Console.WriteLine($"Array Cleared; Array Length: {(isList ? array.Count : array.Length)}");
            Console.WriteLine($"Array Contains '1' ?: {array.Contains(1)}");
            array.Add(1000);
            array.Add(2000);
            array.Add(3000);
            array[1] = 5;
            array.RemoveAt(2);

            SetupOutputs(array, outputs, typeof(List<int>));
            ConsoleWriteResults(array, typeof(List<int>));
            return array;
        }
    }
}
