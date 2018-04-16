using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] queue;
        public int Size { get; private set;}
        private int tail;
        private int head;
        private int version;

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"{nameof(capacity)} < 0 !");
            }

            this.queue = new T[capacity];
            this.Size = 0;
            this.head = 0;
            this.tail = 0;
            this.version = 0;
        }

        public T this[int index]
        {
            get
            {
                return queue[index];
            }
            set
            {
                queue[index] = value;
            }
        }

        public void Clear()
        {            
            Array.Clear(this.queue, 0, Size);
            head = 0;
            tail = 0;
            Size = 0;
            version++;
        }

        public void Enqueue(T obj)
        {
            if (ReferenceEquals(obj, null))
            {
                throw new ArgumentNullException($"{nameof(obj)} is null");
            }

            if (this.Size == queue.Length)
            {
                Array.Resize(ref queue, queue.Length * 2);
            }

            queue[tail] = obj;
            tail = (tail + 1) % queue.Length;
            Size++;
            version++;
        }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Count of elements in the queue is 0");
            }

            T removed = queue[head];
            queue[head] = default(T);
            head = (head + 1) % queue.Length;
            Size--;
            version++;
            return removed;
        }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new ArgumentException("Size is 0!");
            }

            return queue[head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private struct QueueEnumerator : IEnumerator
        {
            private readonly Queue<T> queue;
            private int current;
            private int version;

            public QueueEnumerator(Queue<T> queue)
            {
                this.current = -1;
                this.queue = queue;
                this.version = queue.version;
            }

            public bool MoveNext()
            {
                if (this.version != queue.version)
                {
                    throw new InvalidOperationException($"{nameof(queue)} changed!");
                }

                //if (current < 0)
                //{
                //    return false;
                //}

                //currentElement = _q.GetElement(_index);
                //_index++;

                //if (_index == _q._size)
                //    _index = -1;
                //return true;
            }

            public void Reset()
            {
                current = -1;
            }

            object IEnumerator.Current => Current;

            public T Current
            {
                get
                {
                    if (current == -1 || current == queue.Count)
                    {
                        throw new InvalidOperationException($"{nameof(current)} is wrong");
                    }

                    return queue[current];
                }
            }

            void IDisposable.Dispose()
            {
            }


        }
    }
}
