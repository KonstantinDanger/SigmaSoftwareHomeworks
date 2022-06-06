using System;

namespace Task_2_1
{
    public class Buy
    {
        public int TotalAmount { get; set; }
        private float TotalPurchasePrice { get; set; }
        private float TotalWeight { get; set; }
        private List<Product> productList = new List<Product>();

        public Buy()
        {
            TotalAmount = 0;
            TotalPurchasePrice = 0;
            TotalPurchasePrice = 0;
            TotalWeight = 0;
            productList = new List<Product>();
        }

        public Buy(Product product, int amount = 1)
        {
            AddProduct(product, amount);
        }

        public void AddProduct(Product product, int amount = 1)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException();

            if (product == null)
                throw new ArgumentNullException();

            TotalAmount += amount;
            TotalPurchasePrice += product.Price * amount;
            TotalWeight += product.Weight * amount;
            productList.Add(product);
        }

        public override string ToString()
        {
            if (productList.Count == 0)
                return String.Format("there are no chosen products");

            string[] lines = new string[productList.Count];
            for (int i = 0; i < productList.Count; i++)
            {
                lines[i] = $"{i+1}) {productList[i]}\n";
            }
            return String.Format("Your purchased products:\n " + String.Join(' ', lines) + $" Total bought products amount: {TotalAmount},\n Total purchase price: {TotalPurchasePrice},\n Total weight: {TotalWeight}.\n");
        }
    }
} 
