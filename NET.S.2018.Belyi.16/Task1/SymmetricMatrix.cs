using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SymmetricMatrix(int size) : base(size)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        public SymmetricMatrix() : base()
        {

        }

        /// <summary>
        /// Changes the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected override void ChangeElement(T value, int i, int j)
        {
            this[i, j] = value;
            this[j, i] = value;
        }
    }
}
