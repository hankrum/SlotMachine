using System;

namespace SlotMachine.Data.Repository
{
    public class BallanceRepository : IBalanceRepository
    {
        private Decimal balance;

        public BallanceRepository()
        {
            this.Reset();
        }
        public Decimal Balance
        {
            get
            {
                return this.balance;
            }
        }

        public void Credit(decimal amount)
        {
            this.balance += amount;
        }

        public void Debit(decimal amount)
        {
            this.balance -= amount;
        }

        public bool IsValidStake(decimal stake)
        {
            return stake <= this.Balance;
        }

        public bool GameOver()
        {
            return this.balance <= 0;
        }

        public void Reset()
        {
            this.balance = 0;
        }
    }
}
