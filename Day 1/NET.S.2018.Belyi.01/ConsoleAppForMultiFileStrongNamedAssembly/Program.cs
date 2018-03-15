using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiFileStrongNamedAssembly;

namespace ConsoleAppForMultiFileStrongNamedAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Character char1 = new Character();
            char1.ShowInfo();
            Paladin pal1 = new Paladin();
            pal1.ShowInfo();
            Console.ReadLine();
        }
    }
}
