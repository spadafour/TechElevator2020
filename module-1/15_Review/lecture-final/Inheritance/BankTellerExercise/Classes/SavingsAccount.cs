namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolderName, string accountNumber)
            : base(accountHolderName, accountNumber)
        {

        }
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance)
            : base(accountHolderName, accountNumber, balance)
        {

        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if((Balance - amountToWithdraw) >= 2)
            {
                base.Withdraw(amountToWithdraw);
                if(Balance < 150M)
                {
                    base.Withdraw(2.0M);
                }
            }
            return Balance;

        }

    }
}
