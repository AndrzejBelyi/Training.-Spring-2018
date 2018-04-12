using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Tests
{   public class Cat : IComparable, IComparable<Cat>
    {
       public int mass;
       public string name;

        public Cat(int mass,string name)
        {
            this.mass = mass;
            this.name = name;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Cat other)
        {
            return this.mass - other.mass;
        }
    }

    public class CustomCatsComparer : IComparer<Cat>
    {
        public int Compare(Cat x, Cat y)
        {
            return x.name.Length - y.name.Length;
        }
    }

    public class SearchingTests
    {
        [Test]
        [TestCase(7, new int[] { 1, 3, 5, 7, 9 }, 3)]
        [TestCase(7, new int[] { 1, 3, 5, 7, 7, 7}, 3)]
        public void BinarySearching_DefaultCompare(int f , int[] array,int expectedResult)
        {
            Assert.AreEqual(expectedResult, Searching.BinarySearch(f, array));
        }

        [Test]
        public void BinarySearching_CustomIComparable()
        {
           Cat[] cats = new Cat[] { new Cat(1, "Кыса"), new Cat(3, "Кыса2"), new Cat(2, "Искомая") };
            Assert.AreEqual(1, Searching.BinarySearch(new Cat(3,"Кыcа4"), cats));
        }

        [Test]
        public void BinarySearching_CustomComparer()
        {
            Cat[] cats = new Cat[] { new Cat(1, "Кыса"), new Cat(1, "Кот"), new Cat(2, "Искомая") };
            Assert.AreEqual(2, Searching.BinarySearch(new Cat(6,"Искомая"), cats, new CustomCatsComparer()));
        }


        [Test]
        public void BinarySearching_ArgumentNullException1()
        {
            Cat nullcat = null;
            Cat[] cats = new Cat[] { new Cat(1, "Кошка"), new Cat(1, "Кот"), new Cat(2, "Искомая") };
            Assert.Throws<ArgumentNullException>(() => Searching.BinarySearch(nullcat,cats));
        }

        [Test]
        public void BinarySearching_ArgumentNullException2()
        {
            Cat cat1 = new Cat(1, "www");
            Cat[] cats = null;
            Assert.Throws<ArgumentNullException>(() => Searching.BinarySearch(cat1, cats));
        }

        [Test]
        public void BinarySearching_ArgumentNullException3()
        {
            CustomCatsComparer customcomparer = null;
            Cat cat1 = new Cat(1, "www");
            Cat[] cats = new Cat[] { new Cat(1, "Кошка"), new Cat(1, "Кот"), new Cat(2, "Искомая") };
            Assert.Throws<ArgumentNullException>(() => Searching.BinarySearch(cat1, cats,customcomparer));
        }
    }
}
