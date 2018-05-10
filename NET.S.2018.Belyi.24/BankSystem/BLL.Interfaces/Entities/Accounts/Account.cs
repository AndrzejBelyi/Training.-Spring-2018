using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Interfaces;

namespace BLL.Interfaces.Entities.Accounts
{
    public abstract class Account
    {              
        public Account(Person owner, IGenerateId generator, bool isClosed = false)
        {
            this.Id = generator.Generate();
            this.IsClosed = isClosed;
            this.Owner = owner;
        }

        public string Id { get; }

        public Person Owner { get; }

        public decimal Sum { get; }

        public bool IsClosed { get; private set; }

        public void Withdraw(decimal sum)
        {
            if (!IsClosed)
            {
                throw new InvalidOperationException("Account is closed");
            }

            WithdrawMoney();
            WithdrawBonuses();
        }

        public void Add(decimal sum)
        {
            if(!IsClosed)
            {
                throw new InvalidOperationException("Account is closed");
            }

            AddMoney();
            AddBonuses();
        }

        public void Close()
        {
            if (!CanBeClosed())
            {
                throw new InvalidOperationException("Account can't be closed");
            }

            IsClosed = true;
        }

        protected abstract bool CanBeClosed();

        protected abstract void WithdrawBonuses();

        protected abstract void WithdrawMoney();

        protected abstract void AddBonuses();

        protected abstract void AddMoney();
    }
}
