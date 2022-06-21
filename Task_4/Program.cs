using System;

namespace Task_4
{
    public class ClientClass
    {
        static void Main()
        {
            Console.WriteLine("\n----Task 4----\n");

            Vector _vector = new Vector(10);

            _vector.InitRandom(-10, 10);
            Console.WriteLine(_vector);

            _vector.QuickSort();
            Console.WriteLine(_vector);
        }
    }
}