namespace KafkaCDC.Domain.Elastic
{
    public class Account
    {
        public Account(string name, decimal sum)
        {
            Name = name;
            Sum = sum;
        }

        public string Name { get; private set; }

        public decimal Sum { get; private set; }
    }
}
