using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_test.task_1
{
    internal class BankAccount
    {
        public string AccountNumber { get; private set; }
        public string AccountHolderName { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, string accountHolderName, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be empty.");

            if (string.IsNullOrWhiteSpace(accountHolderName))
                throw new ArgumentException("Account holder name cannot be empty.");

            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");

            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"Successfully deposited {amount:C}. New balance: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds. Withdrawal denied.");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"Successfully withdrew {amount:C}. New balance: {Balance:C}");
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Balance: {Balance:C}");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();

                Console.Write("Enter account holder name: ");
                string accountHolderName = Console.ReadLine();

                Console.Write("Enter initial balance: ");
                decimal initialBalance = decimal.Parse(Console.ReadLine());

                BankAccount account = new BankAccount(accountNumber, accountHolderName, initialBalance);

                account.DisplayAccountDetails();

                Console.WriteLine("\nTesting deposit and withdrawal...");
                account.Deposit(500);
                account.Withdraw(100);
                account.Withdraw(1000); 

                account.DisplayAccountDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

