using System.Globalization;

namespace ChillBill
{
    public class YamlFileSource : IFileSource
    {
        private TextReader reader;
        private DateTime date;

        public void SetSource(TextReader reader)
        {
            this.reader = reader;
            ReadDate();
        }

        private void ReadDate()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            date = DateTime.ParseExact(result[1].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        public DateTime GetDate()
        {            
            return date;
        }

        public Customer ReadCustomer()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();

            line = GetNextLine();
            result = line.Split(':');
            int bonus = int.Parse(result[1].Trim());

            return new Customer(name, bonus);
        }

        public int ReadGoodsCount()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            return int.Parse(result[1].Trim());
        }

        public Goods ReadNextGood()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            string[] data = result[1].Trim().Split();

            string name = data[0];
            string type = data[1];

            return GoodsFactory.Create(name, type, date);
        }

        public int ReadItemsCount()
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            return int.Parse(result[1].Trim());
        }

        public Item ReadNextItem(Goods[] goods)
        {
            string line = GetNextLine();
            string[] result = line.Split(':');
            string[] data = result[1].Trim().Split();

            int gid = int.Parse(data[0]);
            double price = double.Parse(data[1]);
            int qty = int.Parse(data[2]);

            return new Item(goods[gid - 1], qty, price);
        }

        public string GetNextLine()
        {
            string line;
            do
            {
                line = reader.ReadLine();
                if (line == null)
                    throw new EndOfStreamException("Неожиданный конец файла при чтении данных.");
            } while (line.StartsWith("#"));

            return line;
        }
    }
}
