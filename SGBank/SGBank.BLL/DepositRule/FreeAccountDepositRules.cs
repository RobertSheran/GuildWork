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
    public class FreeAccountDepositRules : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse accountDepositResponse = new AccountDepositResponse();
            if (account.Type != AccountType.Free)
            {
                accountDepositResponse.Message = "Error: contact IT";
                accountDepositResponse.Success = false;
                return accountDepositResponse;
            }
            if(amount>100)
            {
                accountDepositResponse.Message = "Free accounts cannot deposit more than $100 at once";
                accountDepositResponse.Success = false;
                return accountDepositResponse;
            }
            if (amount <0)
            {
                accountDepositResponse.Message = "Free accounts cannot deposit negative amounts";
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
