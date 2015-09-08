using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountCalculator = new AccountCalculator();
            Console.WriteLine("Your deposit will grow up to ${0:.00}", accountCalculator.GetDepositResult(25000, 5, 12));
        }
    }

    class AccountCalculator
    {
        const int monthsInYear = 12;
        public double GetDepositResult(double amount, double annualInterest, int months)
        {
            if (amount < 0 || annualInterest < 0 || months < 0)
                throw new ArgumentException();
            return amount * Math.Pow(((100 + annualInterest / monthsInYear) / 100), months);
            //return Enumerable.Range(1, months)
            //    .Aggregate(amount, (x, y) => x * (100 + annualInterest / monthsInYear) / 100);

        }
    }
}
