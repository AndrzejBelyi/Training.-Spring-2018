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
        /// <summary>
        /// The queue of <T>
        /// </summary>
        private T[] queue;

        /// <summary>
        /// The tail
        /// </summary>
        private int tail;

        /// <summary>
        /// The head
        /// </summary>
        private int head;

        /// <summary>
        /// The version
        /// </summary>
        private int version;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue() : this(10)
        {      
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <exception cref="ArgumentException">capacity</exception>
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

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="T"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {            
            Array.Clear(this.queue, 0, Size);
            head = 0;
            tail = 0;
            Size = 0;
            version++;
        }

        /// <summary>
        /// Enqueues the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="ArgumentNullException">obj</exception>
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

        /// <summary>
        /// Dequeue this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Count of elements in the queue is 0</exception>
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

        /// <summary>
        /// Peeks this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Size is 0!</exception>
        public T Peek()
        {
            if (Size == 0)
            {
                throw new ArgumentException("Size is 0!");
            }

            return queue[head];
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Iterator struct
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
        private struct QueueEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// The queue
            /// </summary>
            private readonly Queue<T> queue;

            /// <summary>
            /// The current
            /// </summary>
            private int current;

            /// <summary>
            /// The version
            /// </summary>
            private int version;

            /// <summary>
            /// Initializes a new instance of the <see cref="QueueEnumerator"/> struct.
            /// </summary>
            /// <param name="queue">The queue.</param>
            public QueueEnumerator(Queue<T> queue)
            {
                this.current = -1;
                this.queue = queue;
                this.version = queue.version;
            }

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            object IEnumerator.Current => Current;

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="InvalidOperationException">queue</exception>
            public bool MoveNext()
            {
                if (this.version != queue.version)
                {
                    throw new InvalidOperationException($"{nameof(queue)} changed!");
                }

                if (current < 0)
                {
                    return false;
                }

                current++;

                if (current == queue.Size)
                {
                    current = -1;
                }

                return true;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                current = -1;
            }

            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>
            /// The current.
            /// </value>
            /// <exception cref="InvalidOperationException">current</exception>
            public T Current
            {
                get
                {
                    if (current == -1 || current == queue.Size)
                    {
                        throw new InvalidOperationException($"{nameof(current)} is wrong");
                    }

                    return queue[current];
                }
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            void IDisposable.Dispose()
            {              
            }
        }
    }
}
