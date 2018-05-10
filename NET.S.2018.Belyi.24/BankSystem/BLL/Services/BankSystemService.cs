using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Accounts;
using BLL.Interfaces.Interfaces;
using DAL.Interfaces.Interfaces;

namespace BLL.Services
{
    class BankSystemService: IBankSystemService
    {
        private IRepository repository;

        private IAccountFactory accountFactory;
        
        public BankSystemService(IRepository repository, IAccountFactory accountFactory)
        {
            this.repository = repository;
            this.accountFactory = accountFactory;
        }

        public void CreateAccount(AccountType type, Person person, IGenerateId generator)
        {
            accountFactory.Create(type, person, generator);
            repository.Add();
        }

        public void Add(Account account, decimal sum)
        {
            account.Add(sum);
            repository.Update();
        }

        public void Close(Account account)
        {
            account.Close();
            repository.Update();
        }

        public void Withdraw(Account account, decimal sum)
        {
            account.Withdraw(sum);
            repository.Update();
        }
    }
}
