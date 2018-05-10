using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Interfaces;

namespace BLL.Interfaces.Entities.Accounts
{
    public sealed class PlatinumAccount : Account
    {
        public PlatinumAccount(IGenerateId generator, Person owner, bool isClosed = false) : base(generator, owner, isClosed)
        {
        }

        protected override void AddBonuses()
        {
            throw new NotImplementedException();
        }

        protected override void AddMoney()
        {
            throw new NotImplementedException();
        }

        protected override bool CanBeClosed()
        {
            throw new NotImplementedException();
        }

        protected override void WithdrawBonuses()
        {
            throw new NotImplementedException();
        }

        protected override void WithdrawMoney()
        {
            throw new NotImplementedException();
        }
    }
}
