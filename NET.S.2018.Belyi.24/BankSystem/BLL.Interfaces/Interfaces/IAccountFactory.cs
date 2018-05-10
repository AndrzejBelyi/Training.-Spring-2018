using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Interfaces
{
    public interface IAccountFactory
    {
        Account Create(AccountType type, Person owner,IGenerateId generator);
    }
}
