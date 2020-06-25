using SlotMachine.Data.Model;
using SlotMachine.Infrastructure;
using System;

namespace SlotMachine.Data.Repository
{
    public class CardsRepository : ICardsRepository
    {
        private readonly Card[] cards = new Card[]
        {
               new Card
               {
                   Id = 0,
                   Name = "Apple",
                   Symbol = "A",
                   Probability = 0.45m,
                   Coefficient = 0.4m,
               },
               new Card
               {
                   Id = 1,
                   Name = "Banana",
                   Symbol = "B",
                   Probability = 0.35m,
                   Coefficient = 0.6m,
               },
               new Card
               {
                   Id = 2,
                   Name = "Pineapple",
                   Symbol = "P",
                   Probability = 0.15m,
                   Coefficient = 0.8m,
               },
               new Card
               {
                   Id = 3,
                   Name = "WildCard",
                   Symbol = GlobalConstants.WildCardSymbol,
                   Probability = 0.05m,
                   Coefficient = 0m,
               },
        };

        public Card[] GetAll
        {
            get
            {
                return this.cards;
            }
        }

        public Card GetCardById(int id)
        {
            return this.cards[id];
        }

        public int WildCardId()
        {
            Card wildCard = Array.Find(this.cards, c => c.Symbol == GlobalConstants.WildCardSymbol);
            return wildCard.Id;
        }
    }
}
