﻿namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber) { }
        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance) { }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if (Balance - amountToWithdraw < -100M)
            {
                return Balance;
            } else if(Balance - amountToWithdraw < 0)
            {
                return base.Withdraw(amountToWithdraw + 10);
            }
            return base.Withdraw(amountToWithdraw);
        }
    }
}
