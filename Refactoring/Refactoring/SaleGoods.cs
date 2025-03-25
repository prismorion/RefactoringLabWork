namespace Refactoring
{
    public class SaleGoods : Goods
    {
        public SaleGoods(string title) : base(title)
        {
        }

        public override int GetBonus(int _quantity, double _price)
        {
            int bonus = 0;
            bonus = (int)(_quantity * _price * 0.01);
                    
            return bonus;
        }

        public override double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            if (_quantity > 3)
                discount = _quantity * _price * 0.01;

            return discount;
        }
    }
}
