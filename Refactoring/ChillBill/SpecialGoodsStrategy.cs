namespace ChillBill
{
    public class SpecialGoodsStrategy : IGoodsStrategy
    {
        public double GetDiscount(int _quantity, double _price) =>
            _quantity > 10 ? _quantity * _price * 0.005 : 0;

        public int GetBonus(int _quantity, double _price) =>
            0;

        public int GetUsedBonus(Customer _customer, int _quantity, double thisAmount) =>
            _quantity > 1 ? _customer.useBonus((int)thisAmount) : 0;
    }
}
