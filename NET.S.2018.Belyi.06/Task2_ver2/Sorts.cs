using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_ver2
{
    public class Sorts
    {
        /// <summary>
        /// Sort jagged array by a rule 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public static void BubbleSort(int[][] array, IComparer<int[]> comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer.Compare(array[j],array[j+1]) > 0)
                    {
                       Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
        /// <summary>
        /// Swap two arrays
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
 }
