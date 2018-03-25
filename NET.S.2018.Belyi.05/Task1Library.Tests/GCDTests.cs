using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task1Library.GCD;

namespace Task1Library.Tests
{
    public class GCDTests
    {
        [Test]
        [TestCase(9, -3, 3)]
        [TestCase(10000, 15000, 5000)]
        [TestCase(10, 10, 10)]
        [TestCase(10, 9, 1)]
        [TestCase(-3, 9, 3)]
        [TestCase(15000, 10000, 5000)]
        [TestCase(10, 10, 10)]
        [TestCase(9, 10, 1)]
        public void GetGcdByEuclid_TwoArguments(int firstNumber, int secondNumber, int expectedResult)
        {
            int actualResult = GCD.GetGCDByEuclid(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(-9, -18, 27, 9)]
        [TestCase(10, 10, 9, 1)]
        [TestCase(3, 3, 3, 3)]
        [TestCase(0, 3, 6, 3)]
        [TestCase(0, 0, 3, 3)]
        public void GetGcdByEuclid_ThreeArguments(int firstNumber, int secondNumber, int thirdNumber, int expectedResult)
        {
            int actualResult = GCD.GetGCDByEuclid(firstNumber, secondNumber, thirdNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(9, -18, 27, -36, 9)]
        [TestCase(1, 9, 7, 5, 3, 11)]
        [TestCase(3, 3, 3, 3, 3, 3, 3, 3)]
        [TestCase(3, 3, 6, 9, 0)]
        [TestCase(3, 0, 6, 3, 0)]
        public void GetGcdByEuclid_ManyArguments(int expectedResult, params int[] arguments)
        {
            int actualResult = GCD.GetGCDByEuclid(arguments);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetGcdByEuclid_NullArgument_NullArgumentException()
            => Assert.Throws<ArgumentNullException>(() => GCD.GetGCDByEuclid(null));

        [Test]
        public void GetGcdByEuclid_OneArgument_ArgumentException()
            => Assert.Throws<ArgumentException>(() => GCD.GetGCDByEuclid(12));

        [Test]
        [TestCase(9, -3, 3)]
        [TestCase(10000, 15000, 5000)]
        [TestCase(10, 10, 10)]
        [TestCase(10, 9, 1)]
        [TestCase(-3, 9, 3)]
        [TestCase(15000, 10000, 5000)]
        [TestCase(10, 10, 10)]
        [TestCase(9, 10, 1)]
        public void GetGcdByStein_TwoArguments(int firstNumber, int secondNumber, int expectedResult)
        {
            int actualResult = GCD.GetGCDByStein(firstNumber, secondNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(-9, -18, 27, 9)]
        [TestCase(10, 10, 9, 1)]
        [TestCase(3, 3, 3, 3)]
        [TestCase(0, 3, 6, 3)]
        public void GetGcdByStein_ThreeArguments(int firstNumber, int secondNumber, int thirdNumber, int expectedResult)
        {
            int actualResult = GCD.GetGCDByStein(firstNumber, secondNumber, thirdNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(9, -18, 27, -36, 9)]
        [TestCase(1, 9, 7, 5, 3, 11)]
        [TestCase(3, 3, 3, 3, 3, 3, 3, 3)]
        [TestCase(3, 3, 6, 9, 0)]
        [TestCase(3, 0, 6, 3, 0)]

        public void GetGcdByStein_ManyArguments(int expectedResult, params int[] arguments)
        {
            int actualResult = GCD.GetGCDByStein(arguments);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetGcdByStein_NullArgument_NullArgumentException()
            => Assert.Throws<ArgumentNullException>(() => GCD.GetGCDByStein(null));

        [Test]
        public void GetGcdByStein_OneArgument_ArgumentException()
            => Assert.Throws<ArgumentException>(() => GCD.GetGCDByStein(12));
    }
}
