using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FiltersLibrary.TestsNUnit
{
    [TestFixture]
    public class AlgorithmsTestsNUnit
    {
        #region FindNextBiggerNumberTests
        [Test]
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        public void FindNextBiggerNumber_Number_NextBiggerNumber(int number, int expectedResult)
        {
            int actualResult = Algorithms.FindNextBiggerNumber(number);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindNextBiggerNumber_NegativeNumber_ArgumentException()
        {
            Assert.That(() => Algorithms.FindNextBiggerNumber(-2), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void FindNextBiggerNumber_MaxValue_NoException()
        {
            Algorithms.FindNextBiggerNumber(2147483647);
        }
        #endregion FindNextBiggerNumberTests
        #region FilterDigitTests
        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on valid data
        /// </summary>
        /// <param name="actualArray"></param>
        /// <param name="expectedArray"></param>
        /// <param name="targetDigit"></param>
        [Test]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, new int[] { 7, 7, 70, 17 }, 7)]
        [TestCase(new int[] { 7, 7, 70, 17 }, new int[] { 7, 7, 70, 17 }, 7)]
        public void FilterDigit_UnfilteredArray_FilteredArray(int[] actualArray, int[] expectedArray, int targetDigit)
        {
            actualArray = Algorithms.FilterDigit(actualArray, targetDigit);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on invalid data(null reference)
        /// </summary>
        [Test]
        public void FilterDigit_ArrayNullReference_ArgumentNullException()
        {
            Assert.That(() => Algorithms.FilterDigit(null, 5), Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on invalid data(digit more than 9)
        /// </summary>        
        [Test]
        public void FilterDigit_TargetDigitIsNotDigit_ArgumentException()
        {
            Assert.That(() => Algorithms.FilterDigit(new int[] { 1, 2, 3 }, 11), Throws.TypeOf<ArgumentException>());
        }
        #endregion filterDigitTests
    }
}
