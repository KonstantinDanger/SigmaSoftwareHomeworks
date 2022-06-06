using System;

namespace Task_1
{
    public class ClientClass
    {
        public static void Main()
        {
            Product iron = new Product("Iron", 120f, 1.5f);
            Check.CheckProduct(iron);


            Buy buy1 = new Buy();
            buy1.AddProduct(iron, 2);

            Buy buy2 = new Buy(iron, 3);

            Check.CheckPurchase(buy1);
            Check.CheckPurchase(buy2);

        }
    }
}
