using System;
using System.Configuration;
using System.Text;

namespace Task1
{
    public sealed class Polynomial
    {
        #region Constructors,fields,properties.
        /// <summary>
        /// Coefficients of polynomial
        /// </summary>
        private readonly double[] coefficients;
        private static double eps;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coefficients">consists of coefficients of polynomial</param>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients.Length < 1)
            {
                throw new ArgumentException(nameof(coefficients));
            }

            this.coefficients = new double[coefficients.Length];
            coefficients.CopyTo(this.coefficients, 0);
        }

        /// <summary>
        /// Static constructor for setting the value of the variable "eps"
        /// </summary>
            static Polynomial()
            {
#pragma warning disable CS0618 // Type or member is obsolete
            string str = ConfigurationSettings.AppSettings.Get("eps");
#pragma warning restore CS0618 // Type or member is obsolete

            try
            {
                eps = Double.Parse(str);
            }
            catch (Exception)
            {
                eps = 0.000001;
            }
        }

        /// <summary>
        /// Get length of coefficients
        /// </summary>
        public int Length
        {
            get { return coefficients.Length; }
        }
        #endregion Constructors,fields,properties.
        #region Operators
        /// <summary>
        /// Returns true if polynomials are equal,else returns false
        /// </summary>
        /// <param name="firstPolynomial"></param>
        /// <param name="secondPolynomial"></param>
        /// <returns>Returns the bool result of the comparison<returns>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Returns true if polynomials are not equal,else returns false
        /// </summary>
        /// <param name="firstPolynomial"></param>
        /// <param name="secondPolynomial"></param>
        /// <returns>Returns the bool result of the comparison<returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return !firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Addition two objects of Polynomial class
        /// </summary>
        /// <param name="firstPolynomial"></param>
        /// <param name="secondPolynomial"></param>
        /// <returns>Returns the result of addition of two polynomials</returns>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial));
            }

            if (secondPolynomial == null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial));
            }

            double[] sum = new double[firstPolynomial.Length < secondPolynomial.Length ? firstPolynomial.Length : secondPolynomial.Length];
            Array.Copy(firstPolynomial.coefficients, sum, firstPolynomial.coefficients.Length);
            for (int i = 0; i < secondPolynomial.Length; i++)
            {
                sum[i] += secondPolynomial.coefficients[i];
            }

            return new Polynomial(sum);
        }

        /// <summary>
        /// Returns opposed Polynomial
        /// </summary>
        /// <param name="poly">Polynomial to opposite</param>
        /// <returns>Returns a polynomial with opposite coefficientes<returns>
        public static Polynomial operator -(Polynomial poly)
        {
            if (poly == null)
            {
                throw new ArgumentNullException(nameof(poly));
            }

            double[] sum = new double[poly.Length];      
            for (int i = 0; i < poly.Length; i++)
            {
                sum[i] = -poly.coefficients[i];
            }

            return new Polynomial(sum);
        }

        /// <summary>
        /// Subtraction of two Polynomial
        /// </summary>
        /// <param name="firstPolynomial"></param>
        /// <param name="secondPolynomial"></param>
        /// <returns>returns Polynomial<returns>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {           
            return firstPolynomial + (-secondPolynomial);
        }

        /// <summary>
        /// Subtraction of  two Polynomial
        /// </summary>
        /// <param name="firstPolynomial"></param>
        /// <param name="secondPolynomial"></param>
        /// <returns>Returns the result of substraction of two polynomials<returns>
        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial == null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial));
            }

            if (secondPolynomial == null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial));
            }

            double[] result = new double[firstPolynomial.Length + secondPolynomial.Length];
            for (int i = 0; i < firstPolynomial.coefficients.Length; i++)
            {
                for (int j = 0; j < secondPolynomial.coefficients.Length; j++)
                {
                    result[i + j] += firstPolynomial.coefficients[i] * secondPolynomial.coefficients[j];
                }
            }

            return new Polynomial(result);
        }
        #endregion Operators
        #region Methods
        /// <summary>
        /// Compares instance of polynomial class and object and return true if are equal
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
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                else
                {
                    return this.Equals((Polynomial)obj);
                }
            }            
        }

        /// <summary>
        /// Compares instance of polynomial class and object and return true if are equal
        /// </summary>
        /// <param name="poly"></param>
        /// <returns>True if two objects of Polynomial class are equal</returns>
        public bool Equals(Polynomial poly)
        {
            if (ReferenceEquals(poly, null))
            {
                return false;
            }
            else
            {
                if (ReferenceEquals(this, poly))
                {
                    return true;
                }
                else
                {
                    if (poly.Length != this.Length)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < poly.Length; i++)
                        {
                            if (Math.Abs(poly.coefficients[i] - this.coefficients[i]) > eps)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Return string representation of the polynomial
        /// </summary>
        /// <returns>string representation of the polynomial</returns>
        public override string ToString()
        {
            StringBuilder strRepresentation = new StringBuilder();
            for (int i = 0; i < coefficients.Length; i++)
            {
                strRepresentation.Append($"({coefficients[i]})x^{i} + ");
            }

            strRepresentation.Remove(strRepresentation.Length - 3, 3);
            return strRepresentation.ToString();
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>       
        /// </returns>
        public override int GetHashCode()
        {
            return coefficients.GetHashCode();
        }
        #endregion Methods
    }
}