using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorts
{
    /// <summary>
    /// This static class contains static methods to sort(quick sort,merge sort)
    /// </summary>
    public static class Sorts
    {
        /// <summary>
        /// This public method used to calling overloaded version of QuickSort
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            if (array != null && array.Length > 1)
            {
                QuickSort(array, 0, array.Length - 1);
            }
        }       

        /// <summary>
        /// This public method used to sorting array used merged sort algorithm
        /// </summary>
        /// <param name="array"></param>
        public static int[] MergeSort(int[] array)
        {
            if (array.Length < 2)
            {
                return array;
            }
            else
            {
                int middle = array.Length / 2;
                int[] left = array.Take(middle).ToArray();
                int[] right = array.Skip(middle).ToArray();
                return Merge(MergeSort(left),MergeSort(right));
            }
        }

        /// <summary>
        /// This private recursive method used to sort array using quick sort algorithm 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        private static void QuickSort(int[] array, int first, int last)
        {
            int pivotElement = array[((last - first) / 2) + first];
            int i = first, j = last;
            while (i <= j)
            {
                while (array[i] < pivotElement && i <= last)
                {
                    i++;
                }

                while (array[j] > pivotElement && j >= first)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (j > first)
            {
                QuickSort(array, first, j);
            }

            if (i < last)
            {
                QuickSort(array, i, last);
            }
        }

        /// <summary>
        /// This private method merged two arrays,use for merge sort algorithm
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>return merged array</returns>
        private static int[] Merge(int[] left, int[] right)
        {
            int j = 0, k = 0;
            int[] merged = new int[left.Length + right.Length]; 
            for (int i = 0; i < merged.Length; i++)
            {
                if (j < left.Length && k < right.Length)
                {
                    if (left[j] < right[k])
                    {
                        merged[i] = left[j];
                        j++;
                    }
                    else
                    {
                        merged[i] = right[k];
                        k++;
                    }
                }
                else
                {
                    if (k < right.Length)
                    {
                        merged[i] = right[k];
                        k++;
                    }
                    else
                    {
                        merged[i] = left[j];
                        j++;
                    }
                }
            }

            return merged;
        }
    }
}
