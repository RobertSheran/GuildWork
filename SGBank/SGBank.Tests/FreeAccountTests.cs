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
    public class FreeAccountTests
    {
        [Test]
        [TestCase("12345", "Free Account",100,AccountType.Free,250,false)]
        [TestCase("12345","Free Account",100,AccountType.Free,- 100,false)]
        [TestCase("12345","Free Account",100,AccountType.Basic,50,false)]
        [TestCase("12345","Free Account",100,AccountType.Free,50,true)]

        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new FreeAccountDepositRules();
            Account account = new Account()
            {
                AccountNumber = accountNumber,
                Balance = balance,
                Name = name,
                Type = accountType
            };

            AccountDepositResponse accountDepositResponse = deposit.Deposit(account,amount);
            Assert.AreEqual(expectedResult, accountDepositResponse.Success);
        }

        [Test]
        [TestCase("12345", "Free Account", 50, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -10, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, false)]
        [TestCase("12345", "Free Account", 200, AccountType.Free, 150, false)]

        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new FreeAccountWithdrawlRules();
            Account account = new Account()
            {
                AccountNumber = accountNumber,
                Balance = balance,
                Name = name,
                Type = accountType
            };

            AccountWithdrawResponse accountDepositResponse = withdraw.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, accountDepositResponse.Success);           

        }

        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager accountManager = AccountManagerFactory.Create();
            AccountLookupResponse accountLookupResponse = accountManager.Lookup("12345");
            Assert.IsNotNull(accountLookupResponse.Account);
            Assert.IsTrue(accountLookupResponse.Success);
            Assert.AreEqual("12345", accountLookupResponse.Account.AccountNumber);

            accountLookupResponse = accountManager.Lookup("1");
            Assert.IsNull(accountLookupResponse.Account);
        }
    }
}
