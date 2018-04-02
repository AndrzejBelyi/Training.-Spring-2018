using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ver2
{
    public class Filters
    {
        public static int[] FilterDigit(int[] array,IPredicate predict)
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
                if (predict.Predicate(array[i]))
                {
                    filtredArray.Add(array[i]);
                }
            }

            return filtredArray.ToArray();
        }
    }
}
