using SGBank.BLL;
using SGBank.Modles.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflow
{
    public class AccountLookupWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();
            Console.WriteLine("Lookup an account");
            Console.WriteLine("===============================");
            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();
            AccountLookupResponse accountLookupResponse = accountManager.Lookup(accountNumber);
            Console.Clear();
            if (accountLookupResponse.Success)
            {
                ConsoleUI.DisplayAccountDetails(accountLookupResponse.Account);
            }
            else
            {
                Console.WriteLine(accountLookupResponse.Message);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
                



        }
    }
}
