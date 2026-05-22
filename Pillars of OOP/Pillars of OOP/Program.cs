
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BankAccount
{
    
    class BankAccount
    {
        //private fields for viewing but not writing directly - encapsulation
        private string _accountNumber;
        private string _holderName;
        private decimal _balance;
        private string _pin;
        private List<string> transactionHistory;

        public BankAccount(string accountNumber, string holderName, decimal initDeposit, string pin    ) //Account Constructor
        {
            _accountNumber = accountNumber;
            _balance = initDeposit;
            _holderName = holderName;
            transactionHistory = new List<string>();
            _pin = pin;
        }

        public string OwnerName => _holderName; 
        public decimal Balance => _balance;
        public string AccountNumber => _accountNumber;

        public bool ValidatePin( string pin ) //pin validation 
        {
            return _pin == pin; // check if pin is correct and return true or false
        }

        public void Deposit(decimal amount) // Deposit method 
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Deposit must be positive");
            }
            _balance += amount;
            transactionHistory.Add($"Deposited R{amount}");
            
        }

        public void Withdraw(decimal amount) // Withdrawal method
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            if (amount > _balance) // amount greater than balance
            {
                throw new InvalidOperationException("Insufficient Funds for withdrawal");
            }
            _balance -= amount;
            transactionHistory.Add($"Withdrew R{amount}");

        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var account = new BankAccount("95676545667", "Ntshuxeko", 1000, "1234");

            try
            {
                Console.WriteLine(account.ValidatePin("0000")); //false
                Console.WriteLine(account.ValidatePin("1234")); //true

                account.Deposit(500);
                Console.WriteLine($"Balance: R{account.Balance}");
                account.Withdraw(200);

                Thread.Sleep(2000);
                Console.WriteLine($"Balance: R{account.Balance}");

                account.Withdraw(6000);
                Console.WriteLine($"Balance: R{account.Balance}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
        }
    }
}
