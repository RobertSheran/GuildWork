using SGBank.BLL;
using SGBank.Modles.Response;
using SGBank.UI.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Workflow
{
    public class AccountDepositWorkflow
    {
        public void Exicute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();
            Console.WriteLine("Deposit amount to an account");
            Console.WriteLine("===============================");
            Console.Write("Enter an account number: ");
            string userInputAccountNumber = Console.ReadLine();
            Console.Write("Enter a decimal amount: ");
            decimal userInputAmount = ConsoleUI.GetValid();

            AccountLookupResponse accountLookupResponse = new AccountLookupResponse();
            
            AccountDepositResponse accountDepositResponse = accountManager.Deposit(userInputAccountNumber, userInputAmount);
            if (accountDepositResponse.Success)
            {
                Console.Clear();
                Console.WriteLine("Deposit Compleated");
                Console.WriteLine("Account Number: " + userInputAccountNumber);
                Console.WriteLine("Account Name: " + accountDepositResponse.Account.Name);
                Console.WriteLine("Old Balance: " + "$" + accountDepositResponse.OldBalance);
                Console.WriteLine("Amount Deposited: " + "$" + userInputAmount);               
                Console.WriteLine("New Balance: " + "$" + (accountDepositResponse.Account.Balance));          
            }

            else
            {
                Console.WriteLine("Error: " + accountDepositResponse.Message);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
