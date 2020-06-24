namespace SlotMachine.Data.Model
{
    public class Card
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double Probability { get; set; }

        public double Coefficient { get; set; }
    }
}
