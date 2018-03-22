using SGBank.Modles;
using SGBank.Modles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositRule
{
    public class DepositRulesFactory
    {
        public static IDeposit Create(AccountType type)
        {
            switch (type)
            {
                case AccountType.Free:
                    return new FreeAccountDepositRules();
                case AccountType.Basic:
                    return new NoLimitDepositRules();
                case AccountType.Premium:
                    return new NoLimitDepositRules();
            }
            throw new Exception("AccountType not supported!");
        }
    }
}
