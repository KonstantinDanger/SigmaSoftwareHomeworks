using System;

namespace Task_2_1
{
    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }

        public Product() : this(default, default, default) {}

        public Product(string name, float price, float weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }

        public virtual void ChangePrice(float percentage)
        {
            if (percentage < 0)
                throw new ArgumentOutOfRangeException("percentage must be bigger or equal to zero!");

            Price *= (percentage / 100);
        }

        public void Parse(string input)
        {
            if(input == null) 
                throw new ArgumentNullException("input is null");

            string[] arr = input.Split(' ');
            Name = arr[0];

            Price = float.Parse(arr[1]);
            Weight = float.Parse(arr[2]);

            if (arr[0] == null)
                throw new ArgumentNullException("name can not be null");

            if (arr[1] == null) 
                throw new ArgumentNullException("price can not be null");

            if (arr[2] == null)
                throw new ArgumentNullException("weight can not be null");
        }

        public override string ToString()
        {
            return String.Format($"Name: {Name}, Price: {Price}, Weight: {Weight}");
        }
    }
}
