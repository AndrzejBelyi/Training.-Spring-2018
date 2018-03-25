using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Sorts
    {
        /// <summary>
        /// Sorting an array by the sum of elements of a row, sorting in descending order is possible.
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="decreasing">Sorting in descending order</param>
        public static void SortBySumOfElements(int[][] array,bool decreasing = false)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentException(nameof(array));
            }

            if (decreasing)
            {
                SortOrderOfDecreasingSumsOfElementsOfRows(array);
            }
            else
            {
                SortOrderOfIncreasingSumsOfElementsOfRows(array);
            }
        }

        /// <summary>
        /// Sorting an array by the max of elements of a row, sorting in descending order is possible.
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="decreasing">Sorting in descending order</param>
        public static void SortByMax(int[][] array, bool decreasing = false)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentException(nameof(array));
            }

            if (decreasing)
            {
                SortOrderOfDecreasingMaxElements(array);
            } 
            else
            {
                SortOrderOfIncreasingMaxElements(array);
            }
        }

        /// <summary>
        /// Sorting an array by the min of elements of a row, sorting in descending order is possible.
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="decreasing">Sorting in descending order</param>
        public static void SortByMin(int[][] array, bool decreasing = false)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 1)
            {
                throw new ArgumentException(nameof(array));
            }

            if (decreasing)
            {
                SortOrderOfDecreasingMinElements(array);
            }
            else
            {
                SortOrderOfIncreasingMinElements(array);
            }
        }

        /// <summary>
        /// Method sorts in ascending order the sum of elements of rows of the matrix
        /// </summary>
        /// <param name="array">Array to sort</param>
        private static void SortOrderOfIncreasingSumsOfElementsOfRows(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        if (array[j + 1] != null)
                        {
                            if (Sum(array[j]) > Sum(array[j + 1]))
                            {
                                Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method sorts in decreasing order the sum of elements of rows of the matrix
        /// </summary>
        /// <param name="array">Array to sort</param>
        private static void SortOrderOfDecreasingSumsOfElementsOfRows(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        if (array[j + 1] != null)
                        {
                            if (Sum(array[j]) < Sum(array[j + 1]))
                            {
                                Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sort in order of increasing the maximum elements of rows of the matrix;
        /// </summary>
        /// <param name="array">Array to sort</param>
        private static void SortOrderOfIncreasingMaxElements(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        if (array[j + 1] != null)
                        {
                            if (Max(array[j]) > Max(array[j + 1]))
                            {
                                Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sort in order of decreasing the maximum elements of rows of the matrix;
        /// </summary>
        /// <param name="array">Array to sort</param>
        private static void SortOrderOfDecreasingMaxElements(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        if (array[j + 1] != null)
                        {
                            if (Max(array[j]) < Max(array[j + 1]))
                            {
                                Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sort in order of increasing the minimum elements of rows of the matrix;
        /// </summary>
        /// <param name="array">Array to sort</param>
        private static void SortOrderOfIncreasingMinElements(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        if (array[j + 1] != null)
                        {
                            if (Min(array[j]) > Min(array[j + 1]))
                            {
                                Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sort in order of decreasing the minimum elements of rows of the matrix;
        /// </summary>
        /// <param name="array">Array to sort</param>
        private static void SortOrderOfDecreasingMinElements(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] == null)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                    else
                    {
                        if (array[j + 1] != null)
                        {
                            if (Min(array[j]) < Min(array[j + 1]))
                            {
                                Swap(ref array[j], ref array[j + 1]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds and returns maximum element of array
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <returns>Max element of array</returns>
        private static int Max(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
               if(array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Finds and returns minimum element of array
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <returns>Max element of array</returns>
        private static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        /// <summary>
        ///  Returns sum of the elements of the array
        /// </summary>
        /// <param name="array">Array to calculate</param>
        /// <returns>sum of elements</returns>
        private static int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        /// <summary>
        ///  Swap two arrays
        /// </summary>
        /// <param name="array1">First array to swap</param>
        /// <param name="array2">Second array to swap </param>
        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
}
