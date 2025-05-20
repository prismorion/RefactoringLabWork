namespace ChillBill
{
    public class SaleGoodsStrategy : IGoodsStrategy
    {
        public double GetDiscount(int _quantity, double _price) =>
            _quantity > 3 ? _quantity * _price * 0.01 : 0;

        public int GetBonus(int _quantity, double _price) =>
            (int)(_quantity * _price * 0.01);

        public int GetUsedBonus(Customer _customer, int _quantity, double thisAmount) =>
            0;
    }
}
