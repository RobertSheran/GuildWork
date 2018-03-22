using SGBank.BLL;
using SGBank.Modles;
using SGBank.Modles.Response;
using SGBank.UI.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Workflow
{
    public class AccountWithdrawWorkflow
    {
        public void Exicute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();
            Console.WriteLine("Withdraw amount to an account");
            Console.WriteLine("===============================");      
            Console.Write("Enter an account number: ");
            string userInputAccountNumber = Console.ReadLine();
            Console.Write("Enter a negative decimal amount: ");      
            decimal userInputAmount = ConsoleUI.GetValid();
            
            AccountWithdrawResponse accountWithdrawResponse = accountManager.Withdraw(userInputAccountNumber, userInputAmount);
            if (accountWithdrawResponse.Success)
            {
                Console.Clear();
                Console.WriteLine("Withdraw Compleated");
                Console.WriteLine("Account Number: " + accountWithdrawResponse.Account.AccountNumber);
                Console.WriteLine("Account Name: " + accountWithdrawResponse.Account.Name);
                Console.WriteLine("Old Balance: " + "$" + accountWithdrawResponse.OldBalance);
                Console.WriteLine("Amount withdrawn: " + "$" + userInputAmount);
                if (accountWithdrawResponse.Account.Balance - userInputAmount < 0&&accountWithdrawResponse.Account.Type!=AccountType.Premium)
                {
                    Console.WriteLine("A $10 overdraft fee has been applied.");
                    Console.WriteLine("New Balance: " + "$" + ((accountWithdrawResponse.OldBalance + userInputAmount)-10));
                }
                else
                {
                    Console.WriteLine("New Balance: " + "$" + (accountWithdrawResponse.OldBalance + userInputAmount));

                }
            }
            else
            {
                Console.WriteLine(accountWithdrawResponse.Message);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


        }
    }
}
