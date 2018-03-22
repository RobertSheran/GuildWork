using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Modles.Response
{
    public class AccountLookupResponse:Response
    {
        public Account Account { get; set; }
    }
}
