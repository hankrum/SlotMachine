using SlotMachine.Data.Repository;
using SlotMachine.Infrastructure;

namespace SlotMachine.Data.Model
{
    public class Row
    {
        public Row()
        {
            this.Cards = new Card[GlobalConstants.NumberInARow];
        }

        public Card[] Cards { get; set; }
    }
}
