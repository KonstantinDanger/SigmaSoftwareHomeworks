namespace Task_6
{
    class Program
    {
        static void Main()
        {
            string dataPath = @"C:\Users\SerGun\Desktop\SigmaSoftwareHomework\Push\SigmaSoftwareHomeworks\Task_6\Data.txt";
            string reportPath = @"C:\Users\SerGun\Desktop\SigmaSoftwareHomework\Push\SigmaSoftwareHomeworks\Task_6\Report.txt";

            ElectricityMetering metering = new ElectricityMetering();
            metering.GetDataFromFile(dataPath);
            Console.WriteLine(metering + "\n");

            Console.WriteLine(string.Join(", ", metering.GetFlatByNumber(4)));

            Console.WriteLine("Biggest debtor: " + metering.FindBiggestDebtor() + "\n");

            Console.WriteLine("Number of the flat that is not using energy: " + String.Join(", ", metering.FindFlatsNotUsingEnergy()) + "\n");

            Console.WriteLine($"Flats cost sum: {string.Join(", ", metering.GetFlatsCostSum())}");
            metering.CreateReport(reportPath);
            Console.ReadLine();
        }
    }
}