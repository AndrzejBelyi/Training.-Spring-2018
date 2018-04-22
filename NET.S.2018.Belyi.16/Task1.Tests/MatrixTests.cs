using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestFixture]
    class MatrixTests
    {
        [Test]
        public void MatrixConstructorsTests()
        {
            Matrix<int> matrix = new Matrix<int>();
            Matrix<int> matrix2 = new Matrix<int>(10);
            Assert.AreEqual(matrix.Columns, matrix2.Columns);
        }

        [Test]
        public void SquareMatrixConstructorsTests()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>();
            SquareMatrix<int> matrix2 = new SquareMatrix<int>(10);
            Assert.AreEqual(matrix.Columns, matrix2.Rows);
        }

        [Test]
        public void DiagonalMatrixConstructorsTests()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>();
            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(10);
            Assert.AreEqual(matrix.Columns, matrix2.Rows);
        }

        [Test]
        public void SymmetricMatrixConstructorsTests()
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>();
            SymmetricMatrix<int> matrix2 = new SymmetricMatrix<int>(10);
            Assert.AreEqual(matrix.Columns, matrix2.Rows);
        }

    }
}
