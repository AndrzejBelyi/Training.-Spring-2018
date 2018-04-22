using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public SquareMatrix(int size = 10) : base(size, size)
        {

        }
    }
}
