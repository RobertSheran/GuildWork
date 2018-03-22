using SGBank.Modles.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Modles.Interface
{
    public interface IDeposit
    {
        AccountDepositResponse Deposit(Account account, Decimal amount);
    }
}
