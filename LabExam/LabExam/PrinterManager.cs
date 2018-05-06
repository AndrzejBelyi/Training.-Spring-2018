using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabExam
{
    internal class PrinterManager
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static readonly Lazy<PrinterManager> instance = new Lazy<PrinterManager>(() => new PrinterManager());

        /// <summary>
        /// Initializes a new instance of the <see cref="PrinterManager"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public PrinterManager(ILogger logger = null)
        {
            if(ReferenceEquals(logger,null))
            {
                this.Logger = new CustomLogger();
            }
            else
            {
                this.Logger = logger;
            }

            printers = new List<Printer>();
            
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public PrinterManager Instance => instance.Value;
        
        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public ILogger Logger { get; }

        /// <summary>
        /// The printers
        /// </summary>
        private List<Printer> printers;

        /// <summary>
        /// Gets or sets the printers.
        /// </summary>
        /// <returns>
        /// The printers.
        /// </returns>
        public List<Printer> GetPrinters()
        {
            return printers;
        }

        /// <summary>
        /// Tries the add.
        /// </summary>
        /// <param name="printer">The printer.</param>
        /// <returns></returns>
        public bool TryAdd(Printer printer)
        {
            if (!GetPrinters().Contains(printer))
            {
                printer.StartPrint += (sender, args) => Logger.Log($"Printed by {printer.Name} {printer.Model}");
                printer.EndPrint += (sender, args) => Logger.Log($"Printed by {printer.Name} {printer.Model}");
                printers.Add(printer);
                Logger.Log("Printed added!");
                return true;
            }
            Logger.Log("Printed not added!");
            return false;
        }

        public void Print(Printer printer, string fileName)
        {
            if (ReferenceEquals(printer, null))
            {
                throw new ArgumentNullException("Printer is null!");
            }

            if(!printers.Contains(printer))
            {
                throw new InvalidOperationException("Printer is not exist!");
            }

            using (FileStream stream = File.OpenRead(fileName))
            {
                printers.First(p => p.Equals(printer)).Print(stream);
            }
        }
    }
}