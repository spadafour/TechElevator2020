namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountHolderName, string accountNumber) 
            : base(accountHolderName, accountNumber)
        {

        }
        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance) 
            : base(accountHolderName, accountNumber, balance)
        {

        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            // Checking account can't be overdrawn by $100.00 or more. If a withdrawal request leaves the account $100 or more overdrawn, it fails and the balance remains the same.
            if (Balance - amountToWithdraw > -100)
            {
                // withdraw the money
                base.Withdraw(amountToWithdraw);

                // if the balance is below zero
                if(Balance < 0)
                {
                    base.Withdraw(10M);
                }
            }
            return Balance;
        }
    }
}
