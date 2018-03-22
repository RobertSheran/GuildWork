using SGBank.UI.Workflow;
using SGBank.Workflow;
using System;

namespace SGBank.UI
{
    internal static class Menu
    {
        internal static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SGBank Application");
                Console.WriteLine("================================");
                Console.WriteLine("1. Lookup Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("\nQ to Quit");
                Console.WriteLine("\nEnter Selection");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AccountLookupWorkflow accountLookupWorkflow = new AccountLookupWorkflow();
                        accountLookupWorkflow.Execute();
                        break;
                    case "2":
                        AccountDepositWorkflow accountDepositWorkflow = new AccountDepositWorkflow();
                        accountDepositWorkflow.Exicute();
                        break;
                    case "3":
                        AccountWithdrawWorkflow accountWithdrawWorkflow = new AccountWithdrawWorkflow();
                        accountWithdrawWorkflow.Exicute();
                        break;
                    case "Q":
                        return;                    
                }

            }
        }
    }
}