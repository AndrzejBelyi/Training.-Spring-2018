using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Bank
    { 

        public string Name { get; set; }

        public Bank(string name, Stock stock)
        {
            this.Name = name;
            Register(stock);
        }

        public void Register(Stock stock)
        {
            stock.ChangePrice += Update;
        }

        public void Unregister(Stock stock)
        {
            stock.ChangePrice -= Update;
        }

        public void Update(object sender,StockInfoEventArgs eventArgs)
        {
            if (eventArgs.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, eventArgs.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, eventArgs.Euro);
        }
    }
}
