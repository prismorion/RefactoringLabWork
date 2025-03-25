namespace Refactoring
{
    public class RegularGoods : Goods
    {
        public RegularGoods(string title) : base(title)
        {
        }

        public override int GetBonus(int _quantity, double _price)
        {
            int bonus = 0;
            bonus = (int)(_quantity * _price * 0.05);

            return bonus;
        }

        public override double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity > 2)
                discount = _quantity * _price * 0.03;

            return discount;
        }

        public override int GetUsedBonus(Customer _customer, int _quantity, double thisAmount)
        {
            int usedBonus = 0;
            if (_quantity > 5)
                usedBonus = _customer.useBonus((int)thisAmount);
            return usedBonus;
        }
    }
}
