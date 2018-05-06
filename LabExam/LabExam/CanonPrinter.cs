using System;
using System.IO;

namespace LabExam
{
    internal sealed class CanonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        public CanonPrinter() : this("123x")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonPrinter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="model">The model.</param>
        public CanonPrinter(string model) : base(model)
        {
            Name = "Canon";
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