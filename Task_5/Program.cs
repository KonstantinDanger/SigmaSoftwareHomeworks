namespace Task_5
{
    class Program
    {
        static void Main()
        {
            #region Subtask 1

            Vector _vector1 = new Vector(10);
            Vector _vector2 = new Vector(10);

            try
            {                         
                _vector1.QuickSort();                                       //якщо метод викликається без параметрів, то сортується масив чисел з текстового документа
                Console.WriteLine("vector1: " + _vector1);
                                                                            //якщо метод викликається з масивом як параметром,
                _vector2.QuickSort(new int[] { 1, 5, 2, 6, 7, 8, 11 });     //та довжина масива дорівнює половині кількості елементів в текстовому документі,
                Console.WriteLine("vector2: " + _vector2);                  //то він сортується, у противному випадку - помилка
                                                                            
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("file not found");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("array length must be equal to a half of elements amount in the text file");
            }

            Console.WriteLine("\n--------------------------------------\n");
            #endregion

            #region Subtask 2

            Vector _vector = new Vector(10);
            Console.WriteLine("Pyramid sort: ");

            _vector.InitRandom(-10, 10);
            Console.WriteLine("Input: " + _vector);

            _vector.PyramidSort();
            Console.WriteLine("Output: " + _vector);

            Console.ReadLine();

            #endregion
        }
    }
}
