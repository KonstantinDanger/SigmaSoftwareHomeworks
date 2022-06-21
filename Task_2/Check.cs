using System;

namespace Task_2_1
{
    class Check : IPrint
    {
        public static void CheckProduct(Product product)
        {
            Console.WriteLine(product);
        }

        public static void CheckPurchase(Buy buy)
        {
            Console.WriteLine(buy);
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            Console.WriteLine("Check");
        }

        public void ViewerBuy(Buy buy)
        {
            Console.WriteLine("View buy");
        }
    }
}
