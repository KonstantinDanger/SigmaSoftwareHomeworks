using System;

namespace Task_2_1
{
    public class DairyProduct : Product
    {
        public DateTime ExpirationDate { get; set; }

        public DairyProduct() : this(default, default, default, default) {}

        public DairyProduct(DateTime expirationDate, string name, float price, float weight) : base(name, price, weight) 
        {
            this.ExpirationDate = expirationDate;
        }

        public override void ChangePrice(float percentage)
        {
            if (percentage < 0)
                throw new ArgumentOutOfRangeException("percentage must be bigger or equal to zero!");

            Price *= (percentage / 100);

            if (DateTime.Now < ExpirationDate)
                Price += (Price * 0.1f);
            else
                Price -= (Price * 0.25f);
        }

        public override string ToString()
        {
            return String.Format($"Name: {Name}, Price: {Price}, Weight: {Weight}, expiration date: {ExpirationDate} days");
        }
    }
}
