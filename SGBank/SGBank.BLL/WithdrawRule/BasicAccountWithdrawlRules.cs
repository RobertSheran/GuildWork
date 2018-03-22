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
    public class BasicAccountWithdrawlRules : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse accountWithdrawResponse = new AccountWithdrawResponse();

            if (account.Type != AccountType.Basic)
            {
                accountWithdrawResponse.Message = "ERROR: Contact IT";
                accountWithdrawResponse.Success = false;
                return accountWithdrawResponse;
            }
            if (amount > 0)
            {
                accountWithdrawResponse.Success = false;
                accountWithdrawResponse.Message = "ERROR: Withdrawl must be negative";
                return accountWithdrawResponse;
            }
            if (amount < -500)
            {
                accountWithdrawResponse.Message = "ERROR: Withdrawl limited to -$500 per withdrawl";
                accountWithdrawResponse.Success = false;
                return accountWithdrawResponse;
            }
            if (account.Balance + amount < -100)
            {
                accountWithdrawResponse.Message = "ERROR: Basic accounts have -$100 overdraft limit";
                accountWithdrawResponse.Success = false;
                return accountWithdrawResponse;
            }

            accountWithdrawResponse.Success = true;
            accountWithdrawResponse.Amount = amount;
            accountWithdrawResponse.Account = account;
            accountWithdrawResponse.OldBalance = account.Balance;
            accountWithdrawResponse.Account.Balance += amount;

            if (accountWithdrawResponse.Account.Balance < 0)
            {
                accountWithdrawResponse.Account.Balance += -10;
            }
            return accountWithdrawResponse;

        }
    }
}
