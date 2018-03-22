using SGBank.Modles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Modles;
using SGBank.Modles.Response;

namespace SGBank.BLL.DepositRule
{
    public class NoLimitDepositRules : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse accountDepositResponse = new AccountDepositResponse();

            if ((account.Type != AccountType.Basic)&&account.Type!=AccountType.Premium)
            {
                accountDepositResponse.Message = "Error: contact IT";
                accountDepositResponse.Success = false;
                return accountDepositResponse;
            }

            if (amount <= 0)
            {
                accountDepositResponse.Message = "Deposit must be > 0";
                accountDepositResponse.Success = false;
                return accountDepositResponse;
            }

            accountDepositResponse.OldBalance = account.Balance;
            accountDepositResponse.Account = account;
            accountDepositResponse.Account.Balance += amount;
            accountDepositResponse.Success = true;
            accountDepositResponse.Message = "Success";

            return accountDepositResponse;
        }
    }
}
