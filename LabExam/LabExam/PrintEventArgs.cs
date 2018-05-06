using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class PrintEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrintEventArgs"/> class.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <exception cref="ArgumentNullException">printer is empty!</exception>
        public PrintEventArgs(Printer printer)
        {
            if(ReferenceEquals(printer, null))
            {
                throw new ArgumentNullException("printer is empty!");
            }

            this.Name = printer.Name;
            this.Model = printer.Model;
           
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public string Model { get; }
    }
}
