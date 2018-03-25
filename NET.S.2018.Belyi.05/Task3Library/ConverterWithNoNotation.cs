using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Library
{
    /// <summary>
    /// Class contains method which convert number from any number system, to decimal
    /// </summary>
    public static class ConverterWithNoNotation
    {
        /// <summary>
        /// Method converts number to decimal numeral system
        /// </summary>
        /// <param name="number"></param>
        /// <param name="p"></param>
        /// <returns>returns integer</returns>
        public static int ToDec(this string number, int p)
        {
            int result = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int x = 0;
                if (number[i] < '0' || number[i] > '9')
                {
                    x = char.ToUpper(number[i]) - 'A' + 10;
                }
                else
                {
                    x = number[i] - '0';
                }

                result = result * p + x;
            }

            return result;
        }
    }
}
