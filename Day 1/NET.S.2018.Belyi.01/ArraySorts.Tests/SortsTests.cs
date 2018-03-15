using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArraySorts.Tests
{
    [TestClass]
    public class SortsTests
    {
        #region QuickSort Tests

        /// <summary>
        /// Testing the implementation of the quick sort algorithm on valid data(array not sorted)
        /// </summary>
        [TestMethod]
        public void QuickSort_UnsortedArray_SortedArray()
        {
            int[] actualArray = new int[] { 4, -2, -3, 1, 1, 7, 1 };
            int[] expectedArray = new int[] { -3, -2, 1, 1, 1, 4, 7 };
            ArraySorts.Sorts.QuickSort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// Testing the implementation of the quick sort algorithm on valid data(array sorted)
        /// </summary>
        [TestMethod]
        public void QuickSort_SortedArray_SortedArray()
        {
            int[] actualArray = new int[] { -3, -2, 1, 1, 1, 4, 7 };
            int[] expectedArray = new int[] { -3, -2, 1, 1, 1, 4, 7 };
            ArraySorts.Sorts.QuickSort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// Testing the implementation of the quick sort algorithm on empty array
        /// </summary>
        [TestMethod]
        public void QuickSort_ArrayWithNoElements_EmptyArray()
        {
            int[] actualArray = new int[] { };
            int[] expectedArray = new int[] { };
            ArraySorts.Sorts.QuickSort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// Testing the implementation of the quick sort algorithm on invalid data(null reference)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NullReference_ArgumentNullException()
        {
            int[] actualArray = null;
            ArraySorts.Sorts.QuickSort(actualArray);       
        }
        #endregion

        #region MergeSort Tests
        /// <summary>
        /// Testing the implementation of the merge sort algorithm on valid data(array not sorted)
        /// </summary>
        [TestMethod]
        public void MergeSort_UnsortedArray_SortedArray()
        {
            int[] actualArray = new int[] { 4, -2, -3, 1, 1, 7, 1 };
            int[] expectedArray = new int[] { -3, -2, 1, 1, 1, 4, 7 };
            actualArray = ArraySorts.Sorts.MergeSort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// Testing the implementation of the merge sort algorithm on valid data(array sorted)
        /// </summary>
        [TestMethod]
        public void MergeSort_SortedArray_SortedArray()
        {
            int[] actualArray = new int[] { -3, -2, 1, 1, 1, 4, 7 };
            int[] expectedArray = new int[] { -3, -2, 1, 1, 1, 4, 7 };
            actualArray = ArraySorts.Sorts.MergeSort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// Testing the implementation of the quick sort algorithm on empty array
        /// </summary>
        [TestMethod]
        public void MergeSort_ArrayWithNoElements_EmptyArray()
        {
            int[] actualArray = new int[] { };
            int[] expectedArray = new int[] { };
            actualArray = ArraySorts.Sorts.MergeSort(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        /// <summary>
        /// Testing the implementation of the quick sort algorithm on invalid data(null reference)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_NullReference_ArgumentNullException()
        {
            int[] actualArray = null;
            actualArray = ArraySorts.Sorts.MergeSort(actualArray);
        }
        #endregion
    }
}
