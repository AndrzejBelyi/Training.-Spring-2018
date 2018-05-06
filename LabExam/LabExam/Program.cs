using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExam
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            PrinterManager printerManager = new PrinterManager();
            while (true)
            {
                ShowMenu(printerManager);
                Analyzer(printerManager);
            }

        }

        /// <summary>
        /// Shows the menu.
        /// </summary>
        /// <param name="printerManager">The printer manager.</param>
        public static void ShowMenu(PrinterManager printerManager)
        {
            Console.Clear();
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");
            int i = 4;
            foreach(var item in printerManager.GetPrinters())
            {
                Console.WriteLine($"{i++} Print on {item.Name} {item.Model}");
            }
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <returns></returns>
        public static string OpenFile()
        {
                var o = new OpenFileDialog();
                o.ShowDialog();
                return o.FileName;            
        }

        /// <summary>
        /// Analyze input.
        /// </summary>
        /// <param name="printerManager">The printer manager.</param>
        public static void Analyzer(PrinterManager printerManager)
        {
            var UserInput = Console.ReadKey();
            int bowl = 0;

            if (char.IsNumber(UserInput.KeyChar))
            {
                bowl = int.Parse(UserInput.KeyChar.ToString());
                Console.WriteLine("\nВыбран пункт : {0}", bowl);
            }
            else
            {
                bowl = -1;
            }

            switch (bowl)
            {
                case -1:
                    {                        
                        Console.Clear();
                        Console.WriteLine("Ошибка ввода");
                        Console.ReadKey();
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Enter printer name");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Enter printer model");
                        string Model = Console.ReadLine();
                        printerManager.TryAdd(PrinterFactory.CreatePrinter(Name, Model));
                        break;
                    }
                case 2:
                    {
                        new CanonPrinter().Print(File.OpenRead(OpenFile()));
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        new EpsonPrinter().Print(File.OpenRead(OpenFile()));
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        bowl = bowl - 4;
                        if (bowl<= printerManager.GetPrinters().Count)
                        {
                            printerManager.Print(printerManager.GetPrinters().ElementAt(bowl), OpenFile());
                        }
                        else
                        {
                            Console.WriteLine("Пункт меню отсутствует!" + printerManager.GetPrinters().Count);
                        }
                        Console.ReadKey();
                        break;
                    }
            }
        }
    }
}
