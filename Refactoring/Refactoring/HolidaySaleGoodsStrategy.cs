namespace Refactoring
{
    public class HolidaySaleGoodsStrategy : IGoodsStrategy
    {
        public double GetDiscount(int _quantity, double _price)
        {
            double total = _quantity * _price;
            if (total > 2000)
                return total * 0.03;
            else if (_quantity > 3)
                return total * 0.01;
            return 0;
        }

        public int GetBonus(int _quantity, double _price) =>
            (int)(_quantity * _price * 0.01);

        public int GetUsedBonus(Customer _customer, int _quantity, double thisAmount) =>
            0;
    }
}
