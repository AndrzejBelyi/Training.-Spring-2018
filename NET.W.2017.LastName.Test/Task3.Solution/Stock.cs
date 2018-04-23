using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Stock
    {

        public event EventHandler<StockInfoEventArgs> ChangePrice = delegate { };

        public Stock()
        {            
        }

        public void Market()
        {
            Random rnd = new Random();
            StockInfoEventArgs eventArgs = new StockInfoEventArgs();
            eventArgs.USD = rnd.Next(20, 40);
            eventArgs.Euro = rnd.Next(30, 50);
            OnChangePrice(this, eventArgs);
          
        }

        private void OnChangePrice(object sender, StockInfoEventArgs e)
        {
            ChangePrice?.Invoke(sender, e);
        }
    }
}
