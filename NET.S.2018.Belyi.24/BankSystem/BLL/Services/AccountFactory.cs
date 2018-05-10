using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Accounts;
using BLL.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountFactory : IAccountFactory
    {
        public Account Create(AccountType type, Person owner,IGenerateId generator)
        {
            Account newAccount = null;

            switch (type)
            {
                case AccountType.Base:
                    newAccount = new BaseAccount(owner,generator);
                    break;
                case AccountType.Gold:
                    newAccount = new GoldAccount(owner, generator);
                    break;
                case AccountType.Platinum:
                    newAccount = new PlatinumAccount(owner, generator);
                    break;
            }

            return newAccount;
        }
    }
}
