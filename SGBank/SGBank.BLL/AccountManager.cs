using SGBank.BLL.DepositRule;
using SGBank.BLL.WithdrawRule;
using SGBank.Modles;
using SGBank.Modles.Interface;
using SGBank.Modles.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class AccountManager
    {
        private IAccountRepository _accountRepository;
        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountLookupResponse Lookup(string accountNumber)
        {
            AccountLookupResponse accountLookupResponse = new AccountLookupResponse
            {
                Account = _accountRepository.LoadAccount(accountNumber)
            };
            if (accountLookupResponse.Account == null)
            {
                accountLookupResponse.Message=(accountNumber + " is not an account number.");
            }
            else
            {
                accountLookupResponse.Success = true;
            }
            return accountLookupResponse;
        }
        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {
            AccountDepositResponse accountDepositResponse = new AccountDepositResponse
            {
                Account = _accountRepository.LoadAccount(accountNumber)
            };
            if (accountDepositResponse.Account == null)
            {
                Console.WriteLine(accountNumber + " is not an account number.");
                return accountDepositResponse;
            }
            else
            {
                accountDepositResponse.Amount = amount;
                accountDepositResponse.Success = true;
            }
            
            IDeposit depositRule = DepositRulesFactory.Create(accountDepositResponse.Account.Type);
            accountDepositResponse = depositRule.Deposit(accountDepositResponse.Account, amount);

            if (accountDepositResponse.Success)
            {
                _accountRepository.SaveAccount(accountDepositResponse.Account);
            }

            return accountDepositResponse;
        }
        public AccountWithdrawResponse Withdraw(string accountNumber, decimal amount)
        {
            AccountWithdrawResponse accountWithdrawResponse = new AccountWithdrawResponse
            {
                Account = _accountRepository.LoadAccount(accountNumber)
            };

            if (accountWithdrawResponse.Account == null)
            {
                accountWithdrawResponse.Success = false;
                accountWithdrawResponse.Message = "Error: Account number DNE";
                return accountWithdrawResponse;
            }

            IWithdraw withdraw = WithdrawRulesFactory.Create(accountWithdrawResponse.Account.Type);

            accountWithdrawResponse = withdraw.Withdraw(accountWithdrawResponse.Account, amount);

            if (accountWithdrawResponse.Success)
            {
                _accountRepository.SaveAccount(accountWithdrawResponse.Account);
            }

            return accountWithdrawResponse;
        }


    }
}
