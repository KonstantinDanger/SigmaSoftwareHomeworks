using System;

namespace Task_2_1
{
    public class ClientClass
    {
        public static void Main()
        {
            //#region
            //Product iron = new Product("Iron", 120f, 1.5f);
            //Check.CheckProduct(iron);

            //Meat meat = new Meat(MeatType.pork, Category.firstClass, "", 120f, 2.4f);
            //Check.CheckProduct(meat);

            //Buy buy1 = new Buy();
            //buy1.AddProduct(iron);
            //buy1.AddProduct(meat, 2);

            //Buy buy2 = new Buy(meat, 1);

            //Check.CheckPurchase(buy1);
            //Check.CheckPurchase(buy2);

            //Storage storage = new Storage(iron, meat);
            //Console.WriteLine(storage);

            //Console.Write("Input an index of the product you want to get: ");
            //int index = int.Parse(Console.ReadLine());
            //Product tmp = storage[index];
            //Console.WriteLine(storage[index]);

            //Console.Write("Enter amount of the chosen product to buy: ");
            //int amount = int.Parse(Console.ReadLine());
            //Buy buy3 = new Buy(tmp, amount);
            //Console.WriteLine(buy3);
            //#endregion

            Buy buy = new Buy(new Product("Name", 5, 5));

            IPrint viewer = new Check();

            viewer.ViewerBuy(buy);

            viewer = new CheckDecor();
            viewer.ViewerBuy(buy);

            Product product1 = new Product("Milk", 5, 5);
            Product product2 = new Product("Chocolate", 10, 3.5f);
            Console.WriteLine(product2.CompareTo(product2));

            List<Product> products = new List<Product>() 
            {
                new Product("Apple", 5, 0.5f),
                new Product("Cotton", 2, 0.1f),
                new Product("Iron", 15, 5f)
            };

            foreach(Product product in products)
                Console.WriteLine(product);

            products.Sort();
            Console.WriteLine("*******************");
            foreach (Product product in products)
                Console.WriteLine(product);
            
            ComparerByPrice comparer = new ComparerByPrice();
            products.Sort(comparer);
            Console.WriteLine("*******************");
            foreach (Product product in products)
                Console.WriteLine(product);
        }
    }
}
