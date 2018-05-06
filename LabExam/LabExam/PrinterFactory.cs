using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public static class PrinterFactory
    {
        public static Printer CreatePrinter(string name, string model)
        {
            if(String.IsNullOrWhiteSpace(name) && String.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("field is empty!");
            }

            switch(name)
            {
                case "Epson":
                    return new EpsonPrinter(model);
                case "Canon":
                    return new CanonPrinter(model);
                default: throw new ArgumentException();
            }
        }

    }
}
