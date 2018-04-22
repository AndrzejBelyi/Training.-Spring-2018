using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Matrix<T>
    {
        /// <summary>
        /// The matrix
        /// </summary>
        private T[,] matrix;

        /// <summary>
        /// The n columns
        /// </summary>
        private int nColumns;

        /// <summary>
        /// The n rows
        /// </summary>
        private int nRows;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="ArgumentException">
        /// Invalid count of rows!
        /// or
        /// Invalid count of columns!
        /// </exception>
        public Matrix(int i = 10, int j = 10)
        {
            if (i < 1)
            {
                throw new ArgumentException("Invalid count of rows!");
            }

            if (i < 1)
            {
                throw new ArgumentException("Invalid count of columns!");
            }

            this.matrix = new T[i, j];
            this.nRows = i;
            this.nColumns = j;
        }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public int Rows => this.nRows;

        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <value>
        /// The columns.
        /// </value>
        public int Columns => this.nColumns;

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Index must be greater than 0
        /// or
        /// </exception>
        public T this[int i, int j]
        {
            get
            {
                ValidateChanging(i, j);
                return this.matrix[i, j];
            }

            set
            {
                this.ChangeElement(value, i, j);
            }
        }

        /// <summary>
        /// Validates the changing.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <exception cref="ArgumentException">
        /// Index must be greater than 0
        /// or
        /// </exception>
        private void ValidateChanging(int i, int j)
        {
            if (i < 0 || j < 0)
            {
                throw new ArgumentException("Index must be greater than 0");
            }

            if (i > this.nRows || j > this.nColumns)
            {
                throw new ArgumentException($"Indexes must be in range 0:{i} 0:{j}!");
            }
        }

        /// <summary>
        /// Occurs when [element changed].
        /// </summary>
        public event EventHandler<ChangedElementEventArgs> ElementChanged = delegate { };

        /// <summary>
        /// Changes the element.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        protected virtual void ChangeElement(T value, int i, int j)
        {
            ValidateChanging(i, j);
            this.matrix[i, j] = value;
            OnChangeElement(this, new ChangedElementEventArgs(i,j));
        }

        /// <summary>
        /// Raises the <see cref="E:ChangeElement" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ChangedElementEventArgs"/> instance containing the event data.</param>
        protected void OnChangeElement(object sender, ChangedElementEventArgs e)
        {
            ElementChanged?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Custom event class
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public sealed class ChangedElementEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        public int  Row { get; }

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public int Column { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangedElementEventArgs{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="Row">The row.</param>
        /// <param name="Column">The column.</param>
        public ChangedElementEventArgs(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
        }

    }
}
