using SGBank.Modles.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Modles.Interface
{
    public interface IWithdraw
    {
        AccountWithdrawResponse Withdraw(Account account,decimal amount);
    }
}
