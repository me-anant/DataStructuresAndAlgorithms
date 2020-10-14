using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.MergeSorts
{
	public class im1024MergeSort
	{
		private static double[] _array;

		public static double[] MergeSort(double[] array1)
		{
			//if (_array is null)
				_array = array1;
			return MergeSortHelper(_array);
		}

		/*input: an array from double type
		 *output: the input array, increasingly sorted*/
		private static double[] MergeSortHelper(double[] array1)
		{
			if (array1 is null || array1.Length == 0)
				return new double[0];
			if (array1.Length == 1)
				return array1;
			int mid_pointer = (array1.Length + 1) / 2; //this is the index of the middle cell of the array

			double[] right_side = new double[mid_pointer];
			Array.Copy(array1, 0, right_side, 0, right_side.Length);
			right_side = MergeSortHelper(right_side);

			double[] left_side = new double[array1.Length / 2];
			Array.Copy(array1, mid_pointer, left_side, 0, left_side.Length);
			left_side = MergeSortHelper(left_side);

			return Merge(right_side, left_side);
		}

		/*input: two increasingly sorted arrays from double type
		 *output: an increasingly sorted array from double type with all of the elements from
		 *the input arrays*/
		private static double[] Merge(double[] sorted_array1, double[] sorted_array2)
		{
			double[] merged_array = new double[sorted_array1.Length + sorted_array2.Length];
			int pointer1 = 0, pointer2 = 0, merged_pointer = 0;

			while (pointer1 < sorted_array1.Length && pointer2 < sorted_array2.Length)
			{
				if (sorted_array1[pointer1] <= sorted_array2[pointer2])
				{
					merged_array[merged_pointer] = sorted_array1[pointer1];
					pointer1++;
					merged_pointer++;
					continue;
				}

				if (sorted_array1[pointer1] > sorted_array2[pointer2])
				{
					merged_array[merged_pointer] = sorted_array2[pointer2];
					pointer2++;
					merged_pointer++;
					continue;
				}
			}

			while (pointer1 < sorted_array1.Length)
			{
				merged_array[merged_pointer] = sorted_array1[pointer1];
				pointer1++;
				merged_pointer++;
			}

			while (pointer2 < sorted_array2.Length)
			{
				merged_array[merged_pointer] = sorted_array2[pointer2];
				pointer2++;
				merged_pointer++;
			}

			return merged_array;
		}
	}
}
