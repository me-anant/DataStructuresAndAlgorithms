using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Test.AlgorithmTests
{
    class im1024MergeSortTests
    {
        public static void Tests()
        {
            double[] array, check;

            array = new double[6] { 8, 2, 5.5, 5, 1, -3.2 };
            check = new double[6] { -3.2, 1, 2, 5, 5.5, 8 };
            OneTest(array, check);

            array = new double[6] { 2, 2, 5.5, 5, 2, -3 };
            check = new double[6] { -3, 2, 2, 2, 5, 5.5 };
            OneTest(array, check);

            array = new double[1] { 2 };
            check = new double[1] { 2 };
            OneTest(array, check);

            array = new double[0] { };
            check = new double[0] { };
            OneTest(array, check);

            array = new double[4] { 6.6, 5.5, 4.4, 3.3 };
            check = new double[4] { 3.3, 4.4, 5.5, 6.6 };
            OneTest(array, check);
        }

        private static void OneTest(double[] array, double[] check)
        {
            double[] sorted = im1024MergeSort.MergeSort(array);
            Console.WriteLine(TestToString(array, sorted, check));
        }

        private static string TestToString(double[] array, double[] sorted, double[] check)
        {
            string tostring = "Array: " + ArrayToString(array);
            tostring += "\nsorted:" + ArrayToString(sorted);
            tostring += "\nshould be: " + ArrayToString(check) + "\n";
            return tostring;
        }

        private static string ArrayToString(double[] array)
        {
            string tostring = "[";
            for (int index = 0; index < array.Length - 1; index++)
                tostring += (array[index] + ", ");
            if (array.Length > 0)
                tostring += (array[array.Length - 1] + "]");
            else
                tostring += "]";
            return tostring;
        }
    }
}
