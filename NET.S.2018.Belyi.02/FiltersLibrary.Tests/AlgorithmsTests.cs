using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiltersLibrary.Tests
{
    /// <summary>
    /// Test class include some test methods for DigitFilter method
    /// </summary>
    [TestClass]
    public class AlgorithmsTests
    {
        /// <summary>
        /// This is a method for verifying the algorithm for filtering an array on valid data
        /// </summary>
        [TestMethod]
        public void DigitFilter_UnfilteredArray_FilteredArray()
        {
            int[] actualArray = new int[13] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int[] expectedArray = new int[4] { 7, 7, 70, 17 };
            actualArray = Algorithms.FilterDigit(actualArray, 7);
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
            actualArray = Algorithms.FilterDigit(actualArray, 7);
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
            Algorithms.FilterDigit(actualArray, 7);
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
            actualArray = Algorithms.FilterDigit(actualArray, 11);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void DigitFilter_Perfomance()
        {
            int[] array = Enumerable.Range(1, 7000000).ToArray();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Algorithms.FilterDigit(array, 7);
            stopWatch.Stop();
            Console.WriteLine("Время сортировки 10000000 элементов: " + stopWatch.Elapsed);
        }

        [TestMethod]
        public void DigitFilter0_Perfomance()
        {
            int[] array = Enumerable.Range(1, 7000000).ToArray();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Algorithms.FilterDigit0(array, 7);
            stopWatch.Stop();
            Console.WriteLine("Время сортировки 10000000 элементов: " + stopWatch.Elapsed);
        }

        [TestMethod]
        public void DigitFilter1_Perfomance()
        {
            int[] array = Enumerable.Range(1, 7000000).ToArray();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Algorithms.FilterDigit1(array, 7);
            stopWatch.Stop();
            Console.WriteLine("Время сортировки 10000000 элементов: " + stopWatch.Elapsed);
        }

        [TestMethod]
        public void DigitFilter2_Perfomance()
        {
            int[] array = Enumerable.Range(1, 7000000).ToArray();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Algorithms.FilterDigit2(array, 7);
            stopWatch.Stop();
            Console.WriteLine("Время сортировки 10000000 элементов: " + stopWatch.Elapsed);
        }

        [TestMethod]
        public void DigitFilter3_Perfomance()
        {
            int[] array = Enumerable.Range(1, 7000000).ToArray();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Algorithms.FilterDigit3(array, 7);
            stopWatch.Stop();
            Console.WriteLine("Время сортировки 10000000 элементов: " + stopWatch.Elapsed);
        }
    }
}
