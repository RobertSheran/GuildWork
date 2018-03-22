using NUnit.Framework;
using SGBank.BLL;
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

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [Test]
        public void CanLoadPremiumAccount()
        {
            AccountManager accountManager = AccountManagerFactory.Create();
            AccountLookupResponse accountLookupResponse = accountManager.Lookup("77777");
            Assert.IsNotNull(accountLookupResponse.Account);
            Assert.IsTrue(accountLookupResponse.Success);
            Assert.AreEqual("77777", accountLookupResponse.Account.AccountNumber);
            accountLookupResponse = accountManager.Lookup("1");
            Assert.IsNull(accountLookupResponse.Account);
        }

        [TestCase("77777","Premium Account", AccountType.Premium, 500,-300,true)]
        [TestCase("77777", "Premium Account", AccountType.Free, 500, -300, false)]
        [TestCase("77777", "Premium Account", AccountType.Premium, 100, -300, true)]
        [TestCase("77777", "Premium Account", AccountType.Premium, 0, -600, false)]
        [TestCase("77777", "Premium Account", AccountType.Premium, 0, 600, false)]
        public void CanWithdrawlFromPremiumAccount(string accountNumber,string accountName, AccountType accountType,decimal balance, decimal withdrawl, bool expected)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawlRules();
            Account account = new Account
            {
                AccountNumber = accountNumber,
                Balance = balance,
                Name = accountName,
                Type = accountType
            };

            AccountWithdrawResponse accountWithdrawResponse = withdraw.Withdraw(account, withdrawl);
            Assert.AreEqual(expected, accountWithdrawResponse.Success);
        }
        
        [TestCase("77777", "Premium Account", AccountType.Free, 500, -300, false)]
        [TestCase("77777", "Premium Account", AccountType.Premium, -100, 300, true)]
        [TestCase("77777", "Premium Account", AccountType.Premium, 0, 600, true)]

        public void CanDepositToPremiumAccount(string accountNumber, string accountName, AccountType accountType, decimal balance, decimal amount, bool expected)
        {
            IDeposit depost= new NoLimitDepositRules();
            Account account = new Account
            {
                AccountNumber = accountNumber,
                Balance = balance,
                Name = accountName,
                Type = accountType
            };

            AccountDepositResponse accountDepositResponse = depost.Deposit(account, amount);
            Assert.AreEqual(expected, accountDepositResponse.Success);
        }

    }
}
