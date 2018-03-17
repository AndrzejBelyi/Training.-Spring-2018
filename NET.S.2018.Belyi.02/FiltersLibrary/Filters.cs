using System;
using System.Collections;
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
        /// <param name="array">Array for filtration</param>
        /// <param name="targetDigit">digit for filtration</param>
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

        public static ArrayList FilterDigit0(int[] listInts, int number)
        {
            if (listInts.Length == 0)
            {
                throw new ArgumentException();
            }

            ArrayList listFilter = new ArrayList();
            for (int i = 0; i < listInts.Length; i++)
            {
                string supportString = listInts[i].ToString();
                string numberString = number.ToString();
                if (supportString.Contains(numberString))
                {
                    listFilter.Add(listInts[i]);
                }
            }

            return listFilter;
        }

        public static int[] FilterDigit1(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
            {
                throw new ArgumentException($"{nameof(digit)} must be from 0 to 9", nameof(digit));
            }

            if (numbers == null)
            {
                throw new ArgumentException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                return null;
            }

            int[] result = new int[0];
            string digitStr = digit.ToString();
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                if (number.Contains(digitStr))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = numbers[i];
                }
            }

            return result;
        }

        public static int[] FilterDigit2(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
            {
                throw new ArgumentException($" {nameof(digit)} must be from 0 to 9", nameof(digit));
            }

            if (numbers == null)
            {
                throw new ArgumentException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                return null;
            }

            List<int> result = new List<int>();
            string digitStr = digit.ToString();
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                if (number.Contains(digitStr))
                {
                    result.Add(numbers[i]);
                }
            }

            return result.ToArray();
        }

        public static int[] FilterDigit3(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
            {
                throw new ArgumentException($"{nameof(digit)} must be from 0 to 9", nameof(digit));
            }

            if (numbers == null)
            {
                throw new ArgumentException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException(nameof(numbers));
            }

            List<int> result = new List<int>();
            foreach (var element in numbers)
            {
                if (IsContainsDigit(element, digit))
                {
                    result.Add(element);
                }
            }

            return result.ToArray();
        }

        private static bool IsContainsDigit(int number, int digit)
        {
            while (number != 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number = number / 10;
            }

            return false;
        }
    }
}
