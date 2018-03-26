using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Task1.Tests
{
    public class PolynomialTests
    {
        [TestCase(1, 2, 3, 4, 5, 6, 7)]
        public void PolynomialEquals_ValidParams_Equals(params int[] indexes)
        {
            Polynomial polynomial1 = new Polynomial(1,2,3,4,5,6,7);
            Polynomial polynomial2 = new Polynomial(indexes);
            Assert.AreEqual(polynomial1.Equals(polynomial2),true);
        }
        [TestCase(1, 2, 3, 4, 5, 6, 7)]
        public void PolynomialEquals_ValidParams_NotEquals(params int[] indexes)
        {
            Polynomial polynomial1 = new Polynomial(1, 2, 3, 4, 5, 6);
            Polynomial polynomial2 = new Polynomial(indexes);
            Assert.AreEqual(polynomial1.Equals(polynomial2), false);
        }
        [Test]
        public void PolynomialAdd_TwoPolynomial_ValidRes()
        {
            Polynomial polynomial1 = new Polynomial(1, 2, 3);
            Polynomial polynomial2 = new Polynomial(3, 2, 1);
            Polynomial expectedPolynomial = new Polynomial(4, 4, 4);
            Assert.AreEqual(expectedPolynomial.Equals(polynomial1+polynomial2),true);
        }
    }
}
