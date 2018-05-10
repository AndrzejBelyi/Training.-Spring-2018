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
        void CreateAccount(AccountType type, Person person, IGenerateId generator);
        void Close(Account account);
        void Add(Account account, decimal sum);
        void Withdraw(Account account, decimal sum);

    }
}
