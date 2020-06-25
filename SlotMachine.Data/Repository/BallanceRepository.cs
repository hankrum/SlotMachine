using System;

namespace SlotMachine.Data.Repository
{
    public class BallanceRepository : IBalanceRepository
    {
        private Decimal ballance;

        public BallanceRepository()
        {
            this.ballance = 0;
        }
        public Decimal Ballance
        {
            get
            {
                return this.ballance;
            }
        }

        public void Credit(decimal amount)
        {
            this.ballance += amount;
        }

        public void Debit(decimal amount)
        {
            this.ballance -= amount;
        }
    }
}
