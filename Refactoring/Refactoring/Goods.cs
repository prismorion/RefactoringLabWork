namespace Refactoring
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        protected String _title;

        public Goods(String title)
        {
            _title = title;
        }

        public String getTitle()
        {
            return _title;
        }

        public virtual int GetBonus(int _quantity, double _price)
        {
            return 0;
        }

        public virtual double GetDiscount(int _quantity, double _price)
        {
            return 0;
        }

        public virtual int GetUsedBonus(Customer _customer, int _quantity, double thisAmount)
        {
            return 0;
        }
    }
}