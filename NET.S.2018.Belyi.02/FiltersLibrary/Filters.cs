using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLibrary
{
    /// <summary>
    /// Class have methods to filter array 
    /// </summary>
    public class Filters
    {
        /// <summary>
        /// This method returns an array of numbers that contain a given digit
        /// </summary>
        /// <param name="array"></param>
        /// <param name="targetDigit"></param>
        /// <returns>Filtered array</returns>
        public static int[] FilterDigit(int[] array, int targetDigit)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (targetDigit > 9 || targetDigit < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                List<int> filtredArray = new List<int>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].ToString().Contains(targetDigit.ToString()))
                    {
                        filtredArray.Add(array[i]);
                    }
                }

                return filtredArray.ToArray();
            }
        }
    }
}
