using System;

namespace Task_2_1
{
    public class Storage
    {
        private static List<Product> products = new List<Product>();
        private static List<Meat> meat = new List<Meat>();

        public Storage()
        {
            products = new List<Product>();
        }

        public Storage(params Product[] _products)
        {
            AddPurchase(_products);
        }

        public Product this[int index]
        {
            get { 

                if(index > products.Count)
                    throw new ArgumentOutOfRangeException();

                return products[index-1];
            }
        }


        public void AddPurchase(params Product[] _products)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                products.Add(_products[i]);
            }
        }

        public void FindAllMeatProducts()
        {
            foreach(Meat meatProduct in products)
            {
                if (meat != null)
                    meat.Add(meatProduct);
            }
        }

        public void ChangeAllPrices(float percentage)
        {
            if (percentage < 0)
                throw new ArgumentOutOfRangeException("percentage must be bigger or equal to zero!");
         
            foreach (Product product in products)
            {
                product.Price *= (percentage / 100);
            }
        }

        public override string ToString()
        {
            string[] lines = new string[products.Count];
            for (int i = 0; i < products.Count; i++)
            {
                lines[i] = $"{i+1}) Name: {products[i].Name}, Price: {products[i].Price}, Weight: {products[i].Weight}\n";
            }
            return String.Format("Products in stock:\n " + String.Join(' ', lines));
        }
    }
}
