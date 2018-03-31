using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_ver2.Tests
{
    public class SortDecreasingMaxElements : IComparer<int[]>
    {
        public int Compare(int[] firstArray, int[] secondArray)
        {
            if (ReferenceEquals(firstArray, secondArray))
            {
                return 0;
            }

            if (firstArray == null)
            {
                return 1;
            }

            if (secondArray == null)
            {
                return -1;
            }

            return secondArray.Max().CompareTo(firstArray.Max());
        }
    }
}
