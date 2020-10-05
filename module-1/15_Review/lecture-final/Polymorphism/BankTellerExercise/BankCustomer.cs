using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    public class BankCustomer
    {
        private List<IAccountable> accounts { get; set; } = new List<IAccountable>();
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVip
        {
            get
            {
                int total = 0;
                foreach(IAccountable account in accounts)
                {
                    total += account.Balance;
                }
                return total >= 25000;
            }
        }

        public void AddAccount(IAccountable newAccount)
        {
            accounts.Add(newAccount);
        }

        public IAccountable[] GetAccounts()
        {
            return accounts.ToArray();
        }
    }
}
