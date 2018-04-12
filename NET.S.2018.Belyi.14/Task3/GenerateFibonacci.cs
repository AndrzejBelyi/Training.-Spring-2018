using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class GenerateFibonacci
    {
        /// <summary>
        /// Generates the specified n.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">n</exception>
        public static int[] Generate(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException(nameof(n));
            }

            int[] array = new int[n];
            array[0] = 0;
            array[1] = 1;
            for (int i = 2; i < n; i++)
            {
                array[i] = unchecked(array[i - 1] + array[i - 2]);
            }

            return array;
        }
    }
}
