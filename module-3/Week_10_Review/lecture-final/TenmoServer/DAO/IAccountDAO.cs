using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        List<Account> GetAccountsByUserId(int userId);
        Account GetAccountByAccountId(int accountId);
        List<AccountWithUser> GetAccountWithUsers();


    }
}
