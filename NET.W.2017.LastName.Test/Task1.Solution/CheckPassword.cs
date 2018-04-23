using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class CheckPassword
    {
        public Tuple<bool, string> Check(string password, IEnumerable<IPasswordChecker> checkers)
        {
            //Неясно,что делать c коллекцией таплов. 
            foreach(var c in checkers)
            {
              return c.Check(password);
            }
            return null;
        }
    }
}
