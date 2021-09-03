using System;

namespace KafkaCDC.Domain.Mongo
{
    public class Deposit
    {
        public Deposit(string Name, int Sum)
        {
            this.Name = Name;
            this.Sum = Sum;
        }

        public string Name { get; private set; }

        public int Sum { get; private set; }
    }
}
