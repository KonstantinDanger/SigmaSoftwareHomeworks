namespace Task_7
{
    class Program
    {
        static void Main()
        {
            Storage storage = new Storage();

            string path = @"C:\Users\SerGun\Desktop\SigmaSoftwareHomework\Homeworks\Task_7\Product.txt";

            if (path == null)
            {
                int tries = 3;
                Console.WriteLine("Please, enter a path to the data file");

                while (tries > 0)
                {
                    path = Console.ReadLine();
                    tries--;

                    if (path != null)
                        break;
                }
            }
            else
            {
                storage.AddFromFile(path);
            }

            Console.WriteLine(storage);
        }
    }
}