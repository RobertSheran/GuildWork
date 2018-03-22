using System;
using SGBank.Modles;

namespace SGBank.UI.Workflow
{
    internal class ConsoleUI
    {
        internal static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine("Account name: " + account.Name);
            Console.WriteLine("Account number: " + account.AccountNumber);
            Console.WriteLine("Account balance: " + "$" + account.Balance);
        }

        internal static decimal GetValid()
        {
            decimal result;
            string userInputAmountAsString = Console.ReadLine();
            while (!decimal.TryParse(userInputAmountAsString, out result))
            {
                Console.WriteLine("Entry must be a negative decimal");
                userInputAmountAsString = Console.ReadLine();
            }
            return result;
        }
    }
}