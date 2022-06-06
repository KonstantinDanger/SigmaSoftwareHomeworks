using System;

public enum Category
{
    firstClass,
    secondClass
}

public enum MeatType
{
    mutton,
    veal,
    pork,
    chicken
}

namespace Task_2_1
{
    public class Meat : Product
    {
        public Category Category { get; }
        public MeatType Type { get; }

        public Meat() : this(default, default, default, default, default) {}

        public Meat(MeatType meatType, Category category, string name, float price, float weight) : base(name, price, weight)
        {
            this.Category = category;
            this.Type = meatType;
            this.Name = "Meat";
        }

        public override void ChangePrice(float percentage)
        {
            if (percentage < 0)
                throw new ArgumentOutOfRangeException("percentage must be bigger or equal to zero!");

            Price *= (percentage / 100);

            switch(Category)
            {
                case Category.firstClass:
                    Price += (Price * 0.25f);
                    break;

                case Category.secondClass:
                    Price -= (Price * 0.25f);
                    break;
            }
        }

        public override string ToString()
        {
            return String.Format($"Meat type: {Type}, Price: {Price}, Weight: {Weight}, Meat category: {Category}");
        }
    }
}
