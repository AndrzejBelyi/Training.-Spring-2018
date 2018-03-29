using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Client clientOne= new Client("Вася","Пупкин",Gender.Man);
            Account accClientOne = new Account(clientOne,AccountType.Silver);
            Console.WriteLine(" "+clientOne.FirstName+" "+clientOne.LastName+" "+clientOne.ClientGender);
            Console.WriteLine("Бонусов : " + accClientOne.BonusPoints);
            accClientOne.Put(100);
            Console.WriteLine("Сумма на счету : " + accClientOne.Sum);
            Console.WriteLine("Бонусов : " + accClientOne.BonusPoints);
            accClientOne.Put(1000);
            Console.WriteLine("Сумма на счету : " + accClientOne.Sum);
            Console.WriteLine("Бонусов : " + accClientOne.BonusPoints);
            accClientOne.Put(1297);
            Console.WriteLine("Сумма на счету : " + accClientOne.Sum);
            Console.WriteLine("Бонусов : " + accClientOne.BonusPoints);
            accClientOne.Withdraw(2397);
            Console.WriteLine("Сумма на счету : " + accClientOne.Sum);
            Console.WriteLine("Бонусов : " + accClientOne.BonusPoints);
            accClientOne.Put(100);
            Console.WriteLine("Сумма на счету : " + accClientOne.Sum);
            Console.WriteLine("Бонусов : " + accClientOne.BonusPoints);

        }
    }
}
