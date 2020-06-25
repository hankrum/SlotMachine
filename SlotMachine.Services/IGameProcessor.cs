using SlotMachine.Data.Model;

namespace SlotMachine.Services
{
    public interface IGameProcessor
    {
        Row[] GetTable();

        decimal CalculateWin(decimal stake, Row[] table);
    }
}
