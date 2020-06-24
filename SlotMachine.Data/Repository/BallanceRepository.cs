using System;

namespace SlotMachine.Data.Repository
{
    public class BallanceRepository
    {
        private Double ballance;

        public BallanceRepository()
        {
            this.ballance = 0;
        }
        public Double Ballance
        {
            get
            {
                return this.ballance;
            }
        }

        public double Credit(double amount)
        {
            this.ballance += amount;

            return amount;
        }

        public double Debit(double amount)
        {
            this.ballance -= amount;

            return amount;
        }
    }
}
