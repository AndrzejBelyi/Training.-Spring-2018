using System;
using MultiFileStrongNamedAssembly;

namespace ConsoleAppForMultiFileStrongNamedAssembly
{
   public class Program
    {
       public static void Main(string[] args)
        {
            Character char1 = new Character();
            char1.ShowInfo();
            Paladin pal1 = new Paladin();
            pal1.ShowInfo();
            Console.ReadLine();
        }
    }
}
