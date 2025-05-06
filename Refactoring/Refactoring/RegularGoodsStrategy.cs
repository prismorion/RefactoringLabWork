namespace Refactoring
{
    public class RegularGoodsStrategy : IGoodsStrategy
    {
        public double GetDiscount(int _quantity, double _price) =>
            _quantity > 2 ? _quantity * _price * 0.03 : 0;

        public int GetBonus(int _quantity, double _price) =>
            (int)(_quantity * _price * 0.05);        

        public int GetUsedBonus(Customer _customer, int _quantity, double thisAmount) =>
            _quantity > 5 ? _customer.useBonus((int)thisAmount) : 0;
    }
}
