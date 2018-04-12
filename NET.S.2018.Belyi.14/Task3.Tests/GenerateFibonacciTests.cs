using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Tests
{
    public class GenerateFibonacciTests
    {
        [Test]
        [TestCase(2, new int[] { 0, 1})]
        [TestCase(8, new int[] { 0, 1, 1, 2, 3, 5, 8, 13})]
        [TestCase(13, new int[] {0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 })]
        public void GenerateFibonacci_Test(int n,int[] expected)
        {
            CollectionAssert.AreEqual(expected, GenerateFibonacci.Generate(n));
        }

        [Test]
        public void GenerateFibonacci_Fail()
        {
            Assert.Throws<ArgumentException>(() => GenerateFibonacci.Generate(-1));
        }
    }
}
