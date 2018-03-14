using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArraySorts.Tests
{
    [TestClass]
    public class SortsTests
    {
        [TestMethod]
        public void QuickSort_4231_1234()
        {
            int[] arr1 = new int[4] {4, 2, 3, 1};
            ArraySorts.Sorts.QuickSort(arr1);
            CollectionAssert.AreEqual(new int[4] { 1, 2, 3, 4},arr1);
        }
        [TestMethod]
        public void MergeSort_4231_1234()
        {
            int[] arr1 = new int[4] {4,2,3,1};
            arr1 = ArraySorts.Sorts.MergeSort(arr1);
            CollectionAssert.AreEqual(new int[4] { 1, 2, 3, 4 }, arr1);
            
        }
    }
}
