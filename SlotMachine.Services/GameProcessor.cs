using SlotMachine.Data.Model;
using SlotMachine.Data.Repository;
using SlotMachine.Infrastructure;
using System;
using System.Linq;

namespace SlotMachine.Services
{
    public class GameProcessor : IGameProcessor
    {
        IRandomProvider random;
        ICardsRepository cardsRepository;

        public GameProcessor(IRandomProvider random, ICardsRepository cardsRepository)
        {
            Validated.NotNull(random, nameof(random));
            Validated.NotNull(cardsRepository, nameof(cardsRepository));

            this.random = random;
            this.cardsRepository = cardsRepository;
        }

        public Row[] GetTable()
        {
            int count = GlobalConstants.NumberOfRows;
            Row[] table = new Row[count];

            for (int i=0; i<count; i++)
            {
                table[i] = this.GetRandomRow();
            }

            return table;
        }

        public decimal CalculateWin(decimal stake, Row[] table)
        {
            decimal tableWinCoef = this.TableWinCoefficient(table);
            decimal result = stake * tableWinCoef;

            return result;
        }

        private Card GetRandomCard()
        {
            decimal randomNumber = (decimal) random.GetNewRandom();

            Card[] cards = this.cardsRepository.GetAll;
            int count = cards.Length;
            decimal oldRange = 0;
            decimal newRange = 0;

            for (int i = 0; i < count; i++)
            {
                newRange = newRange + cards[i].Probability;

                if (oldRange <= randomNumber && randomNumber <= newRange)
                {
                    return cards[i];
                }

                oldRange = newRange;
            }

            throw new ArgumentOutOfRangeException(nameof(this.GetRandomCard));
        }

        private Row GetRandomRow()
        {
            var row = new Row();

            for (int i = 0; i < row.Cards.Length; i++)
            {
                row.Cards[i] = this.GetRandomCard();
            }

            return row;
        }

        private bool RowWins(Row row)
        {
            int wildCardId = this.cardsRepository.WildCardId();
            int firstCardId = row.Cards.First().Id;

            foreach (var card in row.Cards)
            {
                var isEqualsOrWildCard = card.Id == firstCardId || card.Id == wildCardId;

                if(!isEqualsOrWildCard)
                {
                    return false;
                }
            }

            return true;
        }

        private decimal RowWinCoefficient(Row row)
        {
            if (this.RowWins(row))
            {
                decimal sum = row.Cards.Select(c => c.Coefficient).Sum();
                return sum;
            }

            return 0m;
        }

        private decimal TableWinCoefficient(Row[] table)
        {
            decimal sum = table.Select(row => RowWinCoefficient(row)).Sum();

            return sum;
        }
    }
}
