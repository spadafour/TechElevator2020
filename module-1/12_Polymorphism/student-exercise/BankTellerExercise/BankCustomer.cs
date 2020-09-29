using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    public class BankCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<IAccountable> Accounts { get; private set; } = new List<IAccountable>();
        public bool IsVip
        {
            get
            {
                int accountTotal = 0;
                foreach (IAccountable account in Accounts)
                {
                    accountTotal += account.Balance;
                }
                bool isVip = accountTotal >= 25000;
                return isVip;
            }
        }


        public void AddAccount(IAccountable newAccount)
        {
            Accounts.Add(newAccount);
        }

        public IAccountable[] GetAccounts()
        {
            return Accounts.ToArray();
        }
    }
}
