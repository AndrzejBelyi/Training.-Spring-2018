using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        /// <summary>
        /// Cooficients of polynomial
        /// </summary>
        private int[] indexes;
        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="indexes"></param>
        public Polynomial(params int [] indexes)
        {
            this.indexes = indexes;
        }
        /// <summary>
        /// Get length of indexes
        /// </summary>
        public int Length
        {
            get { return indexes.Length; }
        }

        /// <summary>
        /// Addition two objects of Polynomial class
        /// </summary>
        /// <param name="firstPolynomial"></param>
        /// <param name="secondPolynomial"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial firstPolynomial,Polynomial secondPolynomial)
        {
            int[] sum= new int[firstPolynomial.Length < secondPolynomial.Length ? firstPolynomial.Length : secondPolynomial.Length];
            for (int i = 0; i < firstPolynomial.Length; i++)
            {
                sum[i] += firstPolynomial.indexes[i];
            }
            for (int i = 0; i < secondPolynomial.Length; i++)
            {
                sum[i] += secondPolynomial.indexes[i];
            }
            return new Polynomial(sum);
        }

        /// <summary>
        /// Compare two objects of plynomial class and return true if are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if two objects of Polynomial class are equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                Polynomial poly = obj as Polynomial;
                if(poly.Length!=this.Length)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < poly.Length; i++)
                    {
                        if (poly.indexes[i] != this.indexes[i])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        }
}
