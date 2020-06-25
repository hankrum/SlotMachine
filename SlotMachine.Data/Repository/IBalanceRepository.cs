using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachine.Data.Repository
{
    public interface IBalanceRepository
    {
        decimal Balance { get;  }

        void Credit(decimal amount);

        void Debit(decimal amount);

        bool IsValidStake(decimal stake);

        bool GameOver();

        void Reset();
    }
}
