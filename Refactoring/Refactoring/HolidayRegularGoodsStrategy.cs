namespace Refactoring
{
    public class HolidayRegularGoodsStrategy : IGoodsStrategy
    {
        public double GetDiscount(int _quantity, double _price) =>
            _quantity > 2 ? _quantity * _price * 0.03 : 0;

        public int GetBonus(int _quantity, double _price)
        {
            double total = _quantity * _price;
            if (total > 5000)
                return (int)(total * 0.07);
            return (int)(_quantity * _price * 0.05);
        }

        public int GetUsedBonus(Customer _customer, int _quantity, double thisAmount) =>
            _quantity > 5 ? _customer.useBonus((int)thisAmount) : 0;
    }
}
