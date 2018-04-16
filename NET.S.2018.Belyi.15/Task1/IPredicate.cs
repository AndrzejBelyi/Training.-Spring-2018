using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IPredicate<T>
    {
        bool Predicate(T value);
    }
}
