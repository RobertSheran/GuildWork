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
    public class BasicAccountTests
    {
        [Test]
        public void CanLoadBasicAccountTestData()
        {
            AccountManager accountManager = AccountManagerFactory.Create();
            AccountLookupResponse accountLookupResponse = accountManager.Lookup("33333");
            Assert.IsNotNull(accountLookupResponse.Account);
            Assert.IsTrue(accountLookupResponse.Success);
            Assert.AreEqual("33333", accountLookupResponse.Account.AccountNumber);

            accountLookupResponse = accountManager.Lookup("1");
            Assert.IsNull(accountLookupResponse.Account);
        }

        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 50, false)]

        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRules();
            Account account = new Account()
            {
                AccountNumber = accountNumber,
                Balance = balance,
                Name = name,
                Type = accountType
            };

            AccountDepositResponse accountDepositResponse = deposit.Deposit(account, amount);
            Assert.AreEqual(expectedResult, accountDepositResponse.Success);
        }

        [TestCase("33333", "Basic Account", 50, AccountType.Basic, -100, true)]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -10, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 50, false)]
        [TestCase("33333", "Basic Account", 500, AccountType.Basic, -501, false)]

        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new BasicAccountWithdrawlRules();
            Account account = new Account()
            {
                AccountNumber = accountNumber,
                Balance = balance,
                Name = name,
                Type = accountType
            };

            AccountDepositResponse accountDepositResponse = withdraw.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, accountDepositResponse.Success);
        }
    }
}
