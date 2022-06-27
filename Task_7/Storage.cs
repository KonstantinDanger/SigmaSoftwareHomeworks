namespace Task_7
{
    public class Storage
    {
        private static List<Product> products = new List<Product>();

        public Storage()
        {
            products = new List<Product>();
        }

        public Storage(params Product[] _products)
        {
            AddPurchase(_products);
        }

        public Product this[int index]
        {
            get { 

                if(index > products.Count)
                    throw new ArgumentOutOfRangeException();

                return products[index-1];
            }
        }

        public void AddPurchase(params Product[] _products)
        {
            products.AddRange(_products);
        }

        public void AddFromFile(string path)
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string[] lines = reader.ReadToEnd().Split(new char[] {'\n'});

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] subLines = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if(!float.TryParse(subLines[1], out float price))
                    {
                        ReportError(new Exception("Parse error. Data was written wrong!"));
                        throw new Exception("Parse error. Data was written wrong!");
                    }

                    if(!float.TryParse(subLines[2], out float weight))
                    {
                        ReportError(new Exception("Parse error. Data was written wrong!"));
                        throw new Exception("Parse error. Data was written wrong!");
                    }

                    if (subLines[0] == null)
                    {
                        ReportError(new Exception("Argument error. Name of the product can not be null!"));
                        throw new Exception("Argument error. Name of the product can not be null!");
                    }

                    string name = char.ToUpper(subLines[0][0]) + subLines[0].Substring(1);

                    AddPurchase(new Product(name, price, weight));
                }
            }
        }

        private void ReportError(Exception exception = null, string path = @"C:\Users\SerGun\Desktop\SigmaSoftwareHomework\Homeworks\Task_7\ErrorReports.txt")
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{exception} - {DateTime.Now}");
            }
        }

        public void ChangeAllPrices(float percentage)
        {
            if (percentage <= 0)
                throw new ArgumentOutOfRangeException("percentage must be bigger then zero!");
         
            foreach (Product product in products)
            {
                product.Price *= (percentage / 100);
            }
        }

        public override string ToString()
        {
            string[] lines = new string[products.Count];
            for (int i = 0; i < products.Count; i++)
            {
                lines[i] = $"{i+1}) Name: {products[i].Name} | Price: {products[i].Price} | Weight: {products[i].Weight}\n";
            }
            return String.Format("Products in stock:\n" + String.Join("", lines));
        }
    }
}
