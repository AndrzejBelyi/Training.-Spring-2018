using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Library
{
   public class Notation
    {
        /// <summary>
        /// All symbols used in numeration systems from 2 to 16 
        /// </summary>
        private const string BaseTable = "0123456789ABCDEF";

        /// <summary>
        /// Base of numeration system
        /// </summary>
        private int _notationBase;

        /// <summary>
        /// Symbols supported by the system of numeration
        /// </summary>
        public string ActualTable { get; set; }

        /// <summary>
        /// Get or set value of notation base.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public int NotationBase
        {
            get
            {
                return _notationBase;
            }

            private set
            {
                if (value < 2 || value > 16)
                {
                    throw new ArgumentException($"{nameof(_notationBase)}");
                }
                else
                {
                    _notationBase = value;
                }
            }
        }

        /// <summary>
        /// Initializes an instance of the class with base of notation default equals 10
        /// </summary>
        public Notation()
        {
            NotationBase = 10;
        }

        /// <summary>
        /// Initializes an instance of the class.
        /// </summary>
        /// <param name="notationBase">Base of notation</param>
        public Notation(int notationBase)
        {
            NotationBase = notationBase;
            ActualTable = BaseTable.Substring(0, notationBase);
        }
        /// <summary>
        /// Check if number is valid 
        /// </summary>
        /// <param name="number">Number as string</param>
        /// <returns>Return true if data is valid</returns>
        public bool IsValidNumber(string number)
        {
            foreach (char item in number.ToUpper())
            {
                if (!ActualTable.Contains(item.ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
