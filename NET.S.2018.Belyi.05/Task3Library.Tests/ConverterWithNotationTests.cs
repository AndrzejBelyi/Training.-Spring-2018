using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3Library.Tests
{
   public class ConverterWithNotationTests
    {
        [Test]
        [TestCase("0110111101100001100001010111111", 2, 934331071)]
        [TestCase("01101111011001100001010111111", 2, 233620159)]
        [TestCase("11101101111011001100001010", 2, 62370570)]
        public void ConvertWithNoNotation_ValidateDataFromBinary(string number, int p, int expectedResult)
        {
            Assert.AreEqual(expectedResult, number.ToDec(new Notation(p)));
        }

        [Test]
        [TestCase("1AeF101", 16, 28242177)]
        [TestCase("1ACB67", 16, 1756007)]
        [TestCase("764241", 8, 256161)]
        [TestCase("10", 5, 5)]
        public void ConvertWithNoNotation_ValidateData(string number, int p, int expectedResult)
        {
            Assert.AreEqual(expectedResult, number.ToDec(new Notation(p)));
        }

        [Test]
        [TestCase("1AeF101", 2)]
        [TestCase("SA123", 2)]
        [TestCase("764241", 20)]
        public void ToDecimalFormArgumentException(string number, int p)
           => Assert.Throws<ArgumentException>(() => number.ToDec(new Notation(p)));
    }
}
