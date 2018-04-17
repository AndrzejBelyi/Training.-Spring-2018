using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Constructor_0()
        {
            
            Queue<int> queue = new Queue<int>();
            Assert.AreEqual(queue.Size , 0);
        }

        [Test]
        public void Constructor_1()
        {
            Queue<int> queue = new Queue<int>(6);
            Assert.AreEqual(queue.Size, 0);
        }

        [Test]
        public void Constructor_InvalidArgument()
        {
            Assert.Throws<ArgumentException>(() => new Queue<int>(-1));
        }

        [Test]
        public void Enqueue_3Elem()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(7);
            queue.Enqueue(7);
            queue.Enqueue(7);

            Assert.AreEqual(queue.Size,3);
        }

        [Test]
        public void ClearQueue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Clear();

            Assert.AreEqual(queue.Size , 0);
        }

        [Test]
        public void GetEnumerator_Test()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            foreach (var item in queue)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
