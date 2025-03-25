namespace Refactoring
{
    public class SpecialGoods : Goods
    {
        public SpecialGoods(string title) : base(title)
        {
        }

        public override double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity > 10)
                discount = _quantity * _price * 0.005;

            return discount;
        }

        public override int GetUsedBonus(Customer _customer, int _quantity, double thisAmount)
        {
            int usedBonus = 0;
            if (_quantity > 1)
                usedBonus = _customer.useBonus((int)thisAmount);
            return usedBonus;
        }
    }
}
