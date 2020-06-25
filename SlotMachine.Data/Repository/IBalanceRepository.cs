using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachine.Data.Repository
{
    public interface IBalanceRepository
    {
        decimal Ballance { get;  }

        void Credit(decimal amount);

        void Debit(decimal amount);
    }
}
