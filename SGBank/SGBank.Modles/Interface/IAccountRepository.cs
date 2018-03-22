﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Modles.Interface
{
    public interface IAccountRepository
    {
        Account LoadAccount(string accountNumber);
        void SaveAccount(Account account);
    }
}
