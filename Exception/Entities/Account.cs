using System;
using System.Globalization;
using NewException.Entities.Exception;

namespace NewException.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            if (withdrawLimit <= 0)
            {
                throw new DomainException("Error creating account: The withdraw limit less than zero!");
            }

            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            if(amount <= 0)
            {
                throw new DomainException("Deposit error: The amount less than or equal to zero!");
            }

            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new DomainException("Withdraw error: The amount less than or equal to zero!");
            }

            if(amount > WithdrawLimit)
            {
                throw new DomainException("Withdraw error: The amount exceeds withdraw limit!");
            }

            if (amount > Balance)
            {
                throw new DomainException("Withdraw error: Not enough balance!");
            }

            Balance -= amount;
        }

        public string NewBalance()
        {
            return "New balance: $ " +
                    Balance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
