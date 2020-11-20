using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }

    public class AccountWithUser : Account
    {
        public AccountWithUser(Account account, string userName)
        {
            AccountId = account.AccountId;
            UserId = account.UserId;
            Balance = account.Balance;
            UserName = userName;
        }
        public string UserName { get; set; }
    }
}
