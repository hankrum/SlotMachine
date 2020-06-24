using SlotMachine.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachine.Data.Repository
{
    public class CardsRepository
    {
        private readonly Card[] repository = new Card[]
        {
               new Card
               {
                   Id = 0,
                   Name = "Apple",
                   Symbol = "A",
                   Probability = 0.45,
                   Coefficient = 0.4,
               },
               new Card
               {
                   Id = 1,
                   Name = "Banana",
                   Symbol = "B",
                   Probability = 0.35,
                   Coefficient = 0.6,
               },
               new Card
               {
                   Id = 2,
                   Name = "Pineapple",
                   Symbol = "P",
                   Probability = 0.15,
                   Coefficient = 0.8,
               },
               new Card
               {
                   Id = 3,
                   Name = "WildCard",
                   Symbol = "*",
                   Probability = 0.05,
                   Coefficient = 0,
               },
        };

        public Card[] Repository
        {
            get
            {
                return this.repository;
            }
        }
    }
}
