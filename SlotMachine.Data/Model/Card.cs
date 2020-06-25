namespace SlotMachine.Data.Model
{
    public class Card
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public decimal Probability { get; set; }

        public decimal Coefficient { get; set; }
    }
}
