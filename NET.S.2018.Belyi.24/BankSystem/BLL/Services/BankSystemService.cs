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
    class BankSystemService: BLL.Interfaces.Interfaces.IBankSystemService
    {
        private IRepository repository;
        
        public BankSystemService(IRepository repository)
        {
            this.repository = repository;
        }

        public void CreateAccount(Person person, IGenerateId generator)
        {
            throw new NotImplementedException();
        }

        public void Add(string id, decimal money)
        {
            throw new NotImplementedException();
        }

        public void Add(Account account, decimal money)
        {
            throw new NotImplementedException();
        }

        public void Close(string id)
        {
            throw new NotImplementedException();
        }

        public void Close(Account account)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(string id, decimal money)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(Account account, decimal money)
        {
            throw new NotImplementedException();
        }
    }
}
