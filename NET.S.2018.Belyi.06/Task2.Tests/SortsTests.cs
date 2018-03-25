using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    public class SortsTests
    {
        [Test]
        [TestCase(new int[] { 1, 99, 6, 2, 7},
                  new int[] { 0, -3, 12 }, 
                  new int[] { -777,0 },
                  new int[] { int.MaxValue, int.MinValue })]
        public void SortBySumOfElementsIncreasing(int[] array1, int[] array2, int[] array3, int[] array4)
        {
            int[][] actualArray = new int[7][];
            actualArray[0] = array1;
            actualArray[1] = array2;
            actualArray[2] = null;
            actualArray[3] = null;
            actualArray[4] = null;
            actualArray[5] = array3;
            actualArray[6] = array4;

            int[][] expectedArray = new int[7][];
            expectedArray[0] = array3;
            expectedArray[1] = array4;
            expectedArray[2] = array2;
            expectedArray[3] = array1;
            expectedArray[4] = null;
            expectedArray[5] = null;
            expectedArray[6] = null;
            Sorts.SortBySumOfElements(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        [TestCase(new int[] { 1, 99, 6, 2, 7 },
                 new int[] { 0, -3, 12 },
                 new int[] { -777, 0 },
                 new int[] { int.MaxValue, int.MinValue })]
        public void SortBySumOfElementsDecreasing(int[] array1, int[] array2, int[] array3, int[] array4)
        {
            int[][] actualArray = new int[7][];
            actualArray[0] = array1;
            actualArray[1] = array2;
            actualArray[2] = null;
            actualArray[3] = null;
            actualArray[4] = null;
            actualArray[5] = array3;
            actualArray[6] = array4;

            int[][] expectedArray = new int[7][];
            expectedArray[0] = array1;
            expectedArray[1] = array2;
            expectedArray[2] = array4;
            expectedArray[3] = array3;
            expectedArray[4] = null;
            expectedArray[5] = null;
            expectedArray[6] = null;
            Sorts.SortBySumOfElements(actualArray,true);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        [TestCase(new int[] { 1, 99, 6, 2, 7 },
                 new int[] { 0, -3, 12 },
                 new int[] { -777, 0 },
                 new int[] { int.MaxValue, int.MinValue })]
        public void SortByMaxIncreasing(int[] array1, int[] array2, int[] array3, int[] array4)
        {
            int[][] actualArray = new int[7][];
            actualArray[0] = array1;
            actualArray[1] = array2;
            actualArray[2] = null;
            actualArray[3] = null;
            actualArray[4] = null;
            actualArray[5] = array3;
            actualArray[6] = array4;

            int[][] expectedArray = new int[7][];
            expectedArray[0] = array3;
            expectedArray[1] = array2;
            expectedArray[2] = array1;
            expectedArray[3] = array4;
            expectedArray[4] = null;
            expectedArray[5] = null;
            expectedArray[6] = null;
            Sorts.SortByMax(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        [TestCase(new int[] { 1, 99, 6, 2, 7 },
                 new int[] { 0, -3, 12 },
                 new int[] { -777, 0 },
                 new int[] { int.MaxValue, int.MinValue })]
        public void SortByMaxDecreasing(int[] array1, int[] array2, int[] array3, int[] array4)
        {
            int[][] actualArray = new int[7][];
            actualArray[0] = array1;
            actualArray[1] = array2;
            actualArray[2] = null;
            actualArray[3] = null;
            actualArray[4] = null;
            actualArray[5] = array3;
            actualArray[6] = array4;

            int[][] expectedArray = new int[7][];
            expectedArray[0] = array4;
            expectedArray[1] = array1;
            expectedArray[2] = array2;
            expectedArray[3] = array3;
            expectedArray[4] = null;
            expectedArray[5] = null;
            expectedArray[6] = null;
            Sorts.SortByMax(actualArray,true);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        [TestCase(new int[] { 1, 99, 6, 2, 7 },
                 new int[] { 0, -3, 12 },
                 new int[] { -777, 0 },
                 new int[] { int.MaxValue, int.MinValue })]
        public void SortByMinIncreasing(int[] array1, int[] array2, int[] array3, int[] array4)
        {
            int[][] actualArray = new int[7][];
            actualArray[0] = array1;
            actualArray[1] = array2;
            actualArray[2] = null;
            actualArray[3] = null;
            actualArray[4] = null;
            actualArray[5] = array3;
            actualArray[6] = array4;

            int[][] expectedArray = new int[7][];
            expectedArray[0] = array4;
            expectedArray[1] = array3;
            expectedArray[2] = array2;
            expectedArray[3] = array1;
            expectedArray[4] = null;
            expectedArray[5] = null;
            expectedArray[6] = null;
            Sorts.SortByMin(actualArray);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        [TestCase(new int[] { 1, 99, 6, 2, 7 },
                 new int[] { 0, -3, 12 },
                 new int[] { -777, 0 },
                 new int[] { int.MaxValue, int.MinValue })]
        public void SortByMinDecreasing(int[] array1, int[] array2, int[] array3, int[] array4)
        {
            int[][] actualArray = new int[7][];
            actualArray[0] = array1;
            actualArray[1] = array2;
            actualArray[2] = null;
            actualArray[3] = null;
            actualArray[4] = null;
            actualArray[5] = array3;
            actualArray[6] = array4;

            int[][] expectedArray = new int[7][];
            expectedArray[0] = array1;
            expectedArray[1] = array2;
            expectedArray[2] = array3;
            expectedArray[3] = array4;
            expectedArray[4] = null;
            expectedArray[5] = null;
            expectedArray[6] = null;
            Sorts.SortByMin(actualArray,true);
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }
    }
}
