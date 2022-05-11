using MyLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class BankAccount
    {
        private readonly ILoggerGeneral _loggerGeneral;

        public int Balance { get; set; }
        public BankAccount(ILoggerGeneral loggerGeneral)
        {
            Balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Deposit(int amount)
        {
            _loggerGeneral.Message("You're making a deposit of: " + amount);
            Balance += amount;
            return true;
        }

        public bool Withdrawal(int amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
