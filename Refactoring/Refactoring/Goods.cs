namespace Refactoring
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;

        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int getPriceCode()
        {
            return _priceCode;
        }

        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }

        public String getTitle()
        {
            return _title;
        }

        public int GetBonus(int _quantity, double _price)
        {
            int bonus = 0;
            switch (getPriceCode())
            {
                case Goods.REGULAR:
                    bonus = (int)(_quantity * _price * 0.05);
                    break;
                case Goods.SALE:
                    bonus = (int)(_quantity * _price * 0.01);
                    break;
                default:
                    bonus = 0;
                    break;
            }
            return bonus;
        }

        public double GetDiscount(int _quantity, double _price)
        {
            double discount = 0;
            switch (getPriceCode())
            {
                case Goods.REGULAR:
                    if (_quantity > 2)
                        discount = _quantity * _price * 0.03;
                    break;
                case Goods.SPECIAL_OFFER:
                    if (_quantity > 10)
                        discount = _quantity * _price * 0.005;
                    break;
                case Goods.SALE:
                    if (_quantity > 3)
                        discount = _quantity * _price * 0.01;
                    break;
            }
            return discount;
        }
    }
}