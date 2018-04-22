using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public DiagonalMatrix(int size) : base(size)
        {        
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        public DiagonalMatrix() : base()
        {
        }
        /// <summary>
        /// Changes the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="System.InvalidOperationException">Only diagonal elements can be changed</exception>
        protected override void ChangeElement(T value, int i, int j)
        {
            if(i == j)
            {
               this[i, i] = value;
            }
            else
            {
                throw new InvalidOperationException("Only diagonal elements can be changed");
            }
        }
    }
}
