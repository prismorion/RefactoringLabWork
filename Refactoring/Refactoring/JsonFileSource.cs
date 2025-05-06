using System.Globalization;
using System.Text.Json;

namespace Refactoring
{
    public class JsonFileSource : IFileSource
    {
        private JsonDocument jsonDoc;
        private int currentGoodIndex = 0;
        private int currentItemIndex = 0;
        private DateTime date;

        public void SetSource(TextReader reader)
        {
            string jsonString = reader.ReadToEnd();
            jsonDoc = JsonDocument.Parse(jsonString);
            ReadDate();
        }

        private void ReadDate()
        {
            string dateStr = jsonDoc.RootElement.GetProperty("Date").GetString();
            date = DateTime.ParseExact(dateStr, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        public DateTime GetDate()
        {
            return date;
        }

        public Customer ReadCustomer()
        {
            var customerElem = jsonDoc.RootElement.GetProperty("Customer");
            string name = customerElem.GetProperty("Name").GetString();
            int bonus = customerElem.GetProperty("Bonus").GetInt32();
            return new Customer(name, bonus);
        }

        public int ReadGoodsCount()
        {
            return jsonDoc.RootElement.GetProperty("Goods").GetArrayLength();
        }

        public Goods ReadNextGood()
        {
            var goodElem = jsonDoc.RootElement.GetProperty("Goods")[currentGoodIndex++];
            string name = goodElem.GetProperty("Name").GetString();
            string type = goodElem.GetProperty("Type").GetString();
            return GoodsFactory.Create(name, type, date);
        }

        public int ReadItemsCount()
        {
            return jsonDoc.RootElement.GetProperty("Items").GetArrayLength();
        }
        
        public Item ReadNextItem(Goods[] goods)
        {
            var itemElem = jsonDoc.RootElement.GetProperty("Items")[currentItemIndex++];
            int gid = itemElem.GetProperty("GID").GetInt32();
            double price = itemElem.GetProperty("Price").GetDouble();
            int qty = itemElem.GetProperty("Qty").GetInt32();

            return new Item(goods[gid - 1], qty, price);
        }
    }
}
