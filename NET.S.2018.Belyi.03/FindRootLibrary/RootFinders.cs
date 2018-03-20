using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRootLibrary
{
   public static class RootFinders
    {
        /// <summary>
        /// Find a n-root of number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="rank"></param>
        /// <param name="eps"></param>
        /// <returns>Retruns root</returns>
        public static double FindNthRoot(double number,int rank, double eps)
        {
            if(rank < 0 || number < 0 || eps <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(rank == 1 || number == 1)
            {
                return number;
            }            
            double root = ((rank - 1) + number) / rank;
            double x = 1;
            while (Math.Abs(root - x) > eps)
            {
                x = root;
                root = (((rank - 1) * x) + (number / Math.Pow(x, rank - 1))) / rank;
            }

            return root;
        }
    }
}
