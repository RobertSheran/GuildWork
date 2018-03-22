using SGBank.Modles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Modles;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            AccountNumber = "77777",
            Balance = 100M,
            Name = "Premium Account",
            Type = AccountType.Premium
        };

        public Account LoadAccount(string accountNumber)
        {
            if (accountNumber != _account.AccountNumber)
            {
                return null;
            }

            return _account;

        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }

    }
}
