using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiltersLibrary.Tests
{
    /// <summary>
    /// Test class include some test methods for DigitFilter method
    /// </summary>
    [TestClass]
    public class FiltersTests
    {
        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on valid data
        /// </summary>
        [TestMethod]
        public void DigitFilter_UnfilteredArray_FilteredArray()
        {
            int[] actualArray = new int[13] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int[] expectedArray = new int[4] { 7, 7, 70, 17 };
            actualArray = Filters.FilterDigit(actualArray, 7);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on valid data
        /// </summary>
        [TestMethod]
        public void DigitFilter_FilteredArray_FilteredArray()
        {
            int[] actualArray = new int[4] { 7, 7, 70, 17 };
            int[] expectedArray = new int[4] { 7, 7, 70, 17 };
            actualArray = Filters.FilterDigit(actualArray, 7);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on invalid data(null reference)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DigitFilter_ArrayNullReference_ArgumentNullException()
        {
            int[] actualArray = null;
            Filters.FilterDigit(actualArray, 7);
            CollectionAssert.AreEqual(null, actualArray);
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on invalid data(digit more than 9)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DigitFilter_TargetDigitIsNotDigit_ArgumentException()
        {
            int[] actualArray = new int[4] { 7, 7, 70, 17 };
            int[] expectedArray = new int[4] { 7, 7, 70, 17 };
            actualArray = Filters.FilterDigit(actualArray, 11);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }       
    }
}
