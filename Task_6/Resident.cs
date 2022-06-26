namespace Task_6
{
    public class Resident
    {
        public int FlatNumber { get; set; }
        public string Surname { get; set; }
        public int InputMeter { get; set; }
        public int OutputMeter { get; set; }
        public DateOnly ReadingDate { get; set; }

        public Resident()
        {
            FlatNumber = 0;
            Surname = null;
            InputMeter = 0;
            OutputMeter = 0;
            ReadingDate = default;
        }

        public Resident(int flatNumber, string surname, int inputMeter, int outputMeter, DateOnly readingDate)
        {
            FlatNumber = flatNumber;
            Surname = surname;
            InputMeter = inputMeter;
            OutputMeter = outputMeter;
            ReadingDate = readingDate;
        }

        public override string ToString()
        {
            return String.Format("| Flat number: {0,-3} | Surname: {1,-9} | Input meter: {2,-6} | Output meter: {3,-6} | Reading date {4, -4}", FlatNumber, Surname, InputMeter, OutputMeter, ReadingDate);
        }
    }
}
