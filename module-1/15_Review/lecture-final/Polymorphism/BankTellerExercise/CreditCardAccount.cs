using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    public class CreditCardAccount : IAccountable
    {
        public int Debt
        {
            get; private set;
        }
        public int Balance
        {
            get
            {
                return -Debt;
            }
        }
        public string AccountHolderName { get; }
        public string AccountNumber { get; }
        public CreditCardAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
        }

        public int Pay(int amountToPay)
        {
            Debt -= amountToPay;
            return Debt;
        }

        public int Charge(int amountToCharge)
        {
            Debt += amountToCharge;
            return Debt;
        }
    }
}
