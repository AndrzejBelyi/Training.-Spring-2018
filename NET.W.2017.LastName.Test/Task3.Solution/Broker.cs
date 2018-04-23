using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Broker
    {
        public string Name { get; set; }

        public Broker(string name,Stock stock)
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
            if (eventArgs.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }

        public void StopTrade(Stock stock)
        {
            Unregister(stock);
            stock = null;
        }
    }
}
