using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Filters
    {
        /// <summary>
        /// This method returns an array of numbers
        /// </summary>
        /// <param name="array">Array for filtration</param>
        /// <returns>Filtered array</returns>   
        public static int[] FilterDigit(int[] array, Predicate<int> predict)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (predict == null)
            {
                throw new ArgumentNullException();
            }

            List<int> filtredArray = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (predict(array[i]))
                {
                    filtredArray.Add(array[i]);
                }
            }

            return filtredArray.ToArray();
        }
    }
}
