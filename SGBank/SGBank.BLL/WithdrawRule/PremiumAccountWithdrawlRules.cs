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
    public class PremiumAccountWithdrawlRules : IWithdraw

    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse accountWithdrawResponse = new AccountWithdrawResponse();

            if (account.Type != AccountType.Premium)
            {
                accountWithdrawResponse.Message = "ERROR: contact IT";
                accountWithdrawResponse.Success = false;
                return accountWithdrawResponse;
            }

            if (amount > 0)
            {
                accountWithdrawResponse.Message = "ERROR: Withdrawl must be a negative number";
                accountWithdrawResponse.Success = false;
                return accountWithdrawResponse;
            }

            if (account.Balance+amount < -500)
            {
                accountWithdrawResponse.Message = "Sorry, Overdrafting is limited to -$500";
                accountWithdrawResponse.Success = false;
                return accountWithdrawResponse;
            }

            accountWithdrawResponse.Success = true;
            accountWithdrawResponse.Message = "Success";
            accountWithdrawResponse.Account = account;
            accountWithdrawResponse.OldBalance = account.Balance;
            accountWithdrawResponse.Account.Balance += amount;

            return accountWithdrawResponse;

        }
    }
}
