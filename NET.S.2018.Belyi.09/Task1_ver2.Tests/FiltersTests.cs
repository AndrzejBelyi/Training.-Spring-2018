using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ver2.Tests
{
    public class NumberIsPositive : IPredicate
    {
        public bool Predicate(int value)
        {
            return value >=0 ? true:false;
        }
    }
    public class NumberIsNegative : IPredicate
    {
        public bool Predicate(int value)
        {
            return value < 0 ? true : false;
        }
    }
    public class FiltersTests
    {
        [Test]
        [TestCase(new int[] { -7, -1, 2, -3, 4, -5, 6, -7, 68, 69, 70, 15, 17 }, new int[] { -7, -1, -3, -5, -7 })]
        [TestCase(new int[] { 7, -7, 70, 17 }, new int[] { -7 })]
        public void FilterDigit_UnfilteredArray_FilteredArray(int[] actualArray, int[] expectedArray)
        {
            actualArray = Filters.FilterDigit(actualArray, new NumberIsNegative());
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on valid data
        /// </summary>
        /// <param name="actualArray"></param>
        /// <param name="expectedArray"></param>
        /// <param name="targetDigit"></param>
        [Test]
        [TestCase(new int[] { -7, -1, 2, -3, 4, -5, 6, -7, 68, 69, 70, 15, 17 }, new int[] { 2, 4, 6, 68, 69, 70, 15, 17 })]
        public void FilterDigit1_UnfilteredArray_FilteredArray(int[] actualArray, int[] expectedArray)
        {
            actualArray = Filters.FilterDigit(actualArray,new NumberIsPositive());
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on invalid data(null reference)
        /// </summary>
        [Test]
        public void FilterDigit_ArrayNullReference_ArgumentNullException()
        {
            Assert.That(() => Filters.FilterDigit(null,new NumberIsNegative()), Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on invalid data(null reference)
        /// </summary>
        [Test]
        public void FilterDigit_ArrayNullReference2_ArgumentNullException()
        {
            Assert.That(() => Filters.FilterDigit(new int[] { 1, 2 }, null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
