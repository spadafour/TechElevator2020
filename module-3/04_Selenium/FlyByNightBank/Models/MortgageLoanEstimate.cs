using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyByNightBank.Models
{
    public class MortgageLoanEstimate
    {
        public decimal loanAmount { get; set; }
        public int loanTermInYears { get; set; }
        public decimal interestRate { get; set; }

        public decimal getMonthlyPayment()
        {
            int loanTermInMonths = loanTermInYears * 12;
            interestRate = interestRate / 100;
            decimal monthlyInterestRate = interestRate / 12;
            double temp = Math.Pow((double)(monthlyInterestRate+1m), (double)loanTermInMonths);
            decimal tempDec = (decimal)temp;
            var payment = (loanAmount * (monthlyInterestRate * tempDec)) / (tempDec - 1);
            return payment;
        }
    }
}
