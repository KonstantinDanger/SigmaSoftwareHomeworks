namespace Task_6
{
    public class ElectricityMetering
    {
        private List<Resident> _residents;
        public int FlatsAmount { get; set; }    
        public int Quarter { get; set; }
        public int EnergyCost { get; set; }

        public Resident this[int index]
        {
            get
            {
                if (index >= 0 && index < _residents.Count)
                    return _residents[index];
                else
                    throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < _residents.Count)
                    _residents[index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ElectricityMetering()
        {
            Quarter = 1;
            EnergyCost = 100;
            _residents = new List<Resident>();
        }

        public ElectricityMetering(int quarter, int energyCost, params Resident[] residents)
        {
            Quarter = quarter;
            EnergyCost = energyCost;
            _residents.AddRange(residents);
        } 

        public void GetDataFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string[] firstLine = reader.ReadLine().Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] lines = reader.ReadToEnd().Split(new char[] { '\n' });

                FlatsAmount = int.Parse(firstLine[0]);
                Quarter = int.Parse(firstLine[1]);


                for (int i = 0; i < lines.Length; i++)
                {
                    string[] subLines = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int.TryParse(subLines[0], out int flatNumber);
                    int.TryParse(subLines[2], out int inputMeter);
                    int.TryParse(subLines[3], out int outputMeter);
                    DateOnly.TryParse(subLines[4], out DateOnly date);

                    if (inputMeter > outputMeter)
                        throw new Exception("Input meter can't be bigger than output meter!");

                    _residents.Add(new Resident(flatNumber, subLines[1], inputMeter, outputMeter, date));
                }
            }
        } 

        public void CreateReport(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                for (int i = 0; i < _residents.Count; i++)
                {
                    writer.WriteLine(_residents[i]);
                }
            }
        }
        
        public void Add(params Resident[] residents) => _residents.AddRange(residents); 

        public Resident FindBiggestDebtor()
        {
            int biggest = _residents[0].OutputMeter - _residents[0].InputMeter;
            int index = 0;

            for (int i = 0; i < _residents.Count; i++)
            {
                if (_residents[i].OutputMeter - _residents[i].InputMeter > biggest)
                {
                    biggest = _residents[i].OutputMeter - _residents[i].InputMeter;
                    index = i;
                }
            }

            return _residents[index];
        }

        public int[] GetFlatByNumber(int number)
        {
            List<int> numbers = new List<int>();

            foreach (Resident resident in _residents)
            {
                if (resident.FlatNumber == number)
                    Console.WriteLine(resident);
            }

            return numbers.ToArray();
        }

        public int[] GetFlatsCostSum()
        {
            List<int> costs = new List<int>();

            foreach (Resident resident in _residents)
            {
                costs.Add((resident.OutputMeter - resident.InputMeter) * EnergyCost);
            }

            return costs.ToArray(); 
        }

        public int[] FindFlatsNotUsingEnergy()
        {
            List<int> flats = new List<int>();

            for (int i = 0; i < _residents.Count; i++)
            {
                if (_residents[i].OutputMeter - _residents[i].InputMeter == 0)
                    flats.Add(_residents[i].FlatNumber);
            }

            return flats.ToArray();
        }

        public override string ToString() => String.Format($"{string.Join("\n", _residents)}\nQuarter: {Quarter}");
    }
}
