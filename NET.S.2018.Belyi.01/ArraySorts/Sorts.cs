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
        /// Used to sort array using quick sort algorithm
        /// </summary>
        /// <param name="array">array which must be sort</param>
        /// <exception cref="ArgumentNullException">Null reference of the array.</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();                
            }
            else
            {
                if (array.Length > 1)
                {
                    QuickSort(array, 0, array.Length - 1);
                }
            }
        }
        /// <summary>
        /// Used to sort array using merge sort algorithm
        /// </summary>
        /// <param name="array">array which must be sort</param>
        /// <exception cref="ArgumentNullException">Null reference of the array.</exception>
        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length > 1)
            {
                Merge(array, 0, array.Length - 1);
            }
        }

        /// <summary>
        /// This private recursive method used to sort array using quick sort algorithm 
        /// </summary>
        /// <param name="array">array which must be sort</param>
        /// <param name="first">left index of the part of the array</param>
        /// <param name="last">right index of the part of the array</param>
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
        /// This private method sorting array using merge sort algorithm
        /// </summary>
        /// <param name="array">array which must be sort</param>
        /// <param name="first">left index of the part of the array</param>
        /// <param name="last">right index of the part of the array</param>
        private static void Merge(int[] array, int first, int last)
        {
            int arraySize = last - first + 1;
            if (arraySize < 2)
            {
                return;
            }

            int mid = (first + last) / 2;
            Merge(array, first, mid);
            Merge(array, mid + 1, last);

            int[] temp = new int[arraySize];
            int i = first;
            int j = mid + 1;
            for (int k = 0; k < arraySize; k++)
            {
                if (i > mid)
                {
                    temp[k] = array[j++];
                }
                else
                {
                    if (j > last)
                    {
                        temp[k] = array[i++];
                    }
                    else
                    {
                        if (array[j] < array[i])
                        {
                            temp[k] = array[j++];
                        }
                        else
                        {
                            temp[k] = array[i++];
                        }
                    }
                }
            }
            for (int k = 0; k < arraySize; k++)
            {
                array[first + k] = temp[k];
            }
        }
    }
}
