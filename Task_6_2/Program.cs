namespace Task_6_2
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            string textPath = @"C:\Users\SerGun\Desktop\SigmaSoftwareHomework\Homeworks_temp\Task_6_2\Text.txt";
            string resultPath = @"C:\Users\SerGun\Desktop\SigmaSoftwareHomework\Homeworks_temp\Task_6_2\Result.txt";

            TextHandler handler = new TextHandler();

            handler.GetTextFromFile(textPath);
            Console.WriteLine(handler);

            handler.DivideBySentences();
            Console.WriteLine("\n" + handler);

            handler.PrintResultInFile(resultPath);

            Console.ReadLine();
        }
    }
}