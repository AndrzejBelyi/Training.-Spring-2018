using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities.Accounts;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IBankSystemService
    {
        void CreateAccount(Person person, IGenerateId generator);
        void Close(string id);
        void Close(Account account);
        void Add(string id, decimal money);
        void Add(Account account, decimal money);
        void Withdraw(string id, decimal money);
        void Withdraw(Account account, decimal money);

    }
}
