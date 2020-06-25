using System;

namespace SlotMachine.Services
{
    public class RandomProvider : IRandomProvider
    {
        Random random;

        public RandomProvider()
        {
            this.random = new Random();
        }

        public double GetNewRandom()
        {
            return this.random.NextDouble();
        }
    }
}
