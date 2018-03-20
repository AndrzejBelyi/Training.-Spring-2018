using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindRootLibrary;
namespace FindRootLibrary.Tests
{
    [TestFixture]
    public class RootFindersTests
    {
        [Test]
        [TestCase(1, 5, 0.1, 1)]
        [TestCase(8, 1, 0.1, 8)]
        [TestCase(1, 6, 0.1, 1)]
        //[TestCase(0.001, 3, 0.1, 0.1)]
        //[TestCase(0.04100625, 4, 0.01, 0.45)]
        //[TestCase(8, 3, 0.0001, 2)]
        //[TestCase(0.0279936, 7, 0.0001, 0.6)]
        //[TestCase(0.0081, 4, 0.1, 0.3)]
        //[TestCase(-0.008, 3, 0.1, -0.2)]
        //[TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_ValidDataTest(double number, int rank, double precision, double expected)
        {          
            Assert.AreEqual(expected, RootFinders.FindNthRoot(number, rank, precision));
        }

        [Test]
        [TestCase(8, 15, -7, -5)]
        [TestCase(8, 15, -0.6, -0.1)]
        public void FindNthRoot_Degree_Precision_ArgumentOutOfRangeException(double number, int rank, double eps, double expected)
            => Assert.Throws<ArgumentOutOfRangeException>(() => RootFinders.FindNthRoot(number, rank, eps));
    }
}
