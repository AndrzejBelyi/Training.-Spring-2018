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
        Polynomial poly =new Polynomial(1, 2.2, 3, 4.11, 5, 6, 7);

        [Test]
        public void Constructor_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Polynomial());
        }

        [Test]
        public void Equals_ValidParams_Equals()
        {
            Polynomial polynomial1 = new Polynomial(1, 2.2, 3, 4.11, 5, 6, 7);
            Assert.AreEqual(true, polynomial1.Equals(poly));
        }

        [Test]
        public void OperatorEquals_ValidParams_Equals()
        {
            Polynomial polynomial1 = new Polynomial(1, 2.2, 3, 4.11, 5, 6, 7);
            Assert.AreEqual(true, polynomial1==poly);
        }

        [Test]
        public void OperatorNotEquals_ValidParams_NotEquals()
        {
            Polynomial polynomial1 = new Polynomial(1, 2, 3, 4.11, 5, 6, 7);
            Assert.AreEqual(true, polynomial1 != poly);
        }

        [Test]
        public void Equals_ValidParams_NotEquals()
        {
            Polynomial polynomial1 = new Polynomial(1, 2.2, 3, 4.11, 5, 5, 7);
            Assert.AreEqual(false, polynomial1.Equals(poly));
        }

        [Test]
        public void Equals_EqualsObjects_Equals()
        {
            Polynomial polynomial1 = poly;
            Assert.AreEqual(true, poly.Equals(polynomial1));
        }

        [Test]
        public void OperatorAddition_ValidData_ValidRes()
        {
            Polynomial polynomial1 = new Polynomial(1, 2.2, 3);
            Polynomial polynomial2 = new Polynomial(3, 2.2 , 1);
            Polynomial expectedPolynomial = new Polynomial(4, 4.4, 4);
            Assert.AreEqual(true, expectedPolynomial.Equals(polynomial1 + polynomial2));
        }

        [Test]
        public void OperatorSubstraction_ValidData_ValidRes()
        {
            Polynomial polynomial1 = new Polynomial(4, 4.4, 4);
            Polynomial polynomial2 = new Polynomial(3, 2.2, 1);
            Polynomial expectedPolynomial = new Polynomial(1, 2.2, 3);
            Assert.AreEqual(true, expectedPolynomial.Equals(polynomial1 - polynomial2));
        }

        [Test]
        public void ToString_ValidData_ValidRes()
        {
            Assert.AreEqual("(1)x^0 + (2,2)x^1 + (3)x^2 + (4,11)x^3 + (5)x^4 + (6)x^5 + (7)x^6", poly.ToString());
        }

    }
}
