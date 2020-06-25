using SlotMachine.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlotMachine.Data.Repository
{
    public interface ICardsRepository
    {
        Card[] GetAll { get; }

        Card GetCardById(int id);

        int WildCardId();
    }
}
