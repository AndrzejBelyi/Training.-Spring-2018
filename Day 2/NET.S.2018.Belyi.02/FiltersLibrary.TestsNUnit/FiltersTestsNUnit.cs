using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FiltersLibrary.TestsNUnit
{
    [TestFixture]
    public class FiltersTestsNUnit
    {
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
            actualArray = Filters.FilterDigit(actualArray, targetDigit);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on invalid data(null reference)
        /// </summary>
        [Test]
        public void FilterDigit_ArrayNullReference_ArgumentNullException()
        {
            Assert.That(() => Filters.FilterDigit(null, 5), Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on invalid data(digit more than 9)
        /// </summary>        
        [Test]
        public void FilterDigit_TargetDigitIsNotDigit_ArgumentException()
        {
            Assert.That(() => Filters.FilterDigit(new int[] { 1, 2, 3 }, 11), Throws.TypeOf<ArgumentException>());
        }
    }
}
