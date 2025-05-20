namespace ChillBill
{
    public class HolidaySpecialGoodsStrategy : IGoodsStrategy
    {
        public double GetDiscount(int _quantity, double _price)
        {
            double total = _quantity * _price;
            if (total > 3000)
                return total * 0.05;
            else if (_quantity > 10)
                return total * 0.005;
            return 0;
        }

        public int GetBonus(int _quantity, double _price) =>
            0;        

        public int GetUsedBonus(Customer _customer, int _quantity, double thisAmount) =>
            _quantity > 1 ? _customer.useBonus((int)thisAmount) : 0;
    }
}
