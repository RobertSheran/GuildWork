using SGBank.Modles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Modles;
using SGBank.Modles.Response;

namespace SGBank.BLL.WithdrawRule
{
    public class FreeAccountWithdrawlRules:IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse accountWithdrawResponse = new AccountWithdrawResponse();
            if (account.Type != AccountType.Free)
            {
                accountWithdrawResponse.Success = false;
                accountWithdrawResponse.Message="Error: a non - free account hit the Free Withdraw Rule.Contact IT";
                accountWithdrawResponse.Account = null;
                return accountWithdrawResponse;
            }
            if (amount >= 0)
            {
                accountWithdrawResponse.Success = false;
                accountWithdrawResponse.Message = "Amount must be negative";
                return accountWithdrawResponse;
            }
            if (amount < -100)
            {
                accountWithdrawResponse.Success = false;
                accountWithdrawResponse.Message = "Free accounts cannot withdraw more than $100 at a time";
                return accountWithdrawResponse;
            }
            if (amount+account.Balance < 0)
            {
                accountWithdrawResponse.Success = false;
                accountWithdrawResponse.Message = "Free accounts cannot overdraft";
                return accountWithdrawResponse;
            }
            accountWithdrawResponse.Success = true;
            accountWithdrawResponse.Amount = amount;
            accountWithdrawResponse.Account = account;
            accountWithdrawResponse.OldBalance = account.Balance;
            accountWithdrawResponse.Account.Balance += amount;

            return accountWithdrawResponse;


        }


    }
}
