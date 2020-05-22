using System;

namespace SeleniumBasicDemo
{
    public class BankAccount
    {
        decimal amount;

        public BankAccount(decimal initAmount)
        {
            this.Amount = initAmount;
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount can not be negative!");
                }
                else
                {
                    this.amount = value;
                }
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit can not be negative!");
            }
            this.amount += amount;
        }

        public void Withdraw(decimal amount)
        {
            //if (amount > this.amount)
            //{
            //    throw new ArgumentException("Withdraw amount should be...");
            //}
            if (amount < 1000)
            {
                amount += (amount * 0.05m);
                this.amount -= amount;
            }
            else
            {
                amount += (amount * 0.02m);
                this.amount -= amount;
            }
        }

        public static void Main() { }
    }
}