using System;
using System.IO;

namespace LabExam
{
    internal sealed class EpsonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpsonPrinter"/> class.
        /// </summary>
        public EpsonPrinter() : this("231")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="model">The model.</param>
        public EpsonPrinter(string model) : base(model)
        {
            Name = "Epson";
        }

        public override string Name { get; }

        protected override void PrintRule(Stream stream)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}