using SGBank.Modles;
using SGBank.Modles.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRule
{
    public class WithdrawRulesFactory
    {
        public static IWithdraw Create(AccountType type)
        {
            switch (type)
            {
                case AccountType.Free:
                    return new FreeAccountWithdrawlRules();                  
                case AccountType.Basic:
                    return new BasicAccountWithdrawlRules();                  
                case AccountType.Premium:
                    return new PremiumAccountWithdrawlRules();
                    
                default:
                    Console.WriteLine("Type Not Supported");
                    break;
            }
            throw new NotImplementedException();
        }  
    }
}
