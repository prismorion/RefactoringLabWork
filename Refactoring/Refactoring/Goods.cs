namespace Refactoring
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        protected string _title;
        protected IGoodsStrategy _strategy;

        public Goods(string title, IGoodsStrategy strategy)
        {
            _title = title;
            _strategy = strategy;
        }

        public string getTitle() => _title;

        public virtual double GetDiscount(int quantity, double price) =>
            _strategy.GetDiscount(quantity, price);

        public virtual int GetBonus(int quantity, double price) =>
            _strategy.GetBonus(quantity, price);

        public virtual int GetUsedBonus(Customer customer, int quantity, double amount) =>
            _strategy.GetUsedBonus(customer, quantity, amount);
    }
}