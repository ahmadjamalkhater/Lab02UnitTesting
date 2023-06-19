using System;
using System.Collections.Generic;

namespace Lab02UnitTesting
{
    public class Program
    {
        public static decimal Balance { get; set; }
        public static List<string> TransactionHistory { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            // Application logic goes here
        }

        public static decimal ViewBalance()
        {
            return Balance;
        }

        public static decimal Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                TransactionHistory.Add($"Withdrawal of {amount:C}. New Balance: {Balance:C}");
            }
            return Balance;
        }

        public static decimal Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                TransactionHistory.Add($"Deposit of {amount:C}. New Balance: {Balance:C}");
            }
            return Balance;
        }

        public static List<string> GetTransactionHistory()
        {
            return TransactionHistory;
        }
    }
}
