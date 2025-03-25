namespace Refactoring
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }

        public string GetHeader()
        {
            return "Счет для " + _customer.getName() + "\n" + "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }

        public string GetFooter(double totalAmount, int totalBonus)
        {
            return "Сумма счета составляет " + totalAmount.ToString() + "\n" + 
                "Вы заработали " + totalBonus.ToString() + " бонусных балов";
        }

        public string GetItemString(Item each, double discount, double thisAmount, int bonus)
        {
            return "\t" + each.getGoods().getTitle() + "\t" +
                "\t" + each.getPrice() + "\t" + each.getQuantity() +
                "\t" + GetSum(each).ToString() +
                "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                "\t" + bonus.ToString() + "\n";
        }

        public int GetBonus(Item each)
        {
            int bonus = 0;
            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    bonus = (int)(GetSum(each) * 0.05);
                    break;
                case Goods.SALE:
                    bonus =  (int)(GetSum(each) * 0.01);
                    break;
                default:
                    bonus = 0;
                    break;
            }
            return bonus;
        }

        public double GetDiscount(Item each)
        {
            double discount = 0;
            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (each.getQuantity() > 2)
                        discount = GetSum(each) * 0.03; // 3%
                    break;
                case Goods.SPECIAL_OFFER:                    
                    if (each.getQuantity() > 10)
                        discount = GetSum(each) * 0.005; // 0.5%
                    break;
                case Goods.SALE:
                    if (each.getQuantity() > 3)
                        discount = GetSum(each) * 0.01; // 0.1%
                    break;
            }            

            return discount;
        }

        public int GetUsedBonus(Item each, double thisAmount)
        {
            int usedBonus = 0;
            switch (each.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (each.getQuantity() > 5)
                        usedBonus = _customer.useBonus((int)thisAmount);
                    break;
                case Goods.SPECIAL_OFFER:
                    if (each.getQuantity() > 1)
                        usedBonus = _customer.useBonus((int)thisAmount);
                    break;
            }
            return usedBonus;
        }

        public double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }

        public string statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();

            string result = GetHeader();

            while (items.MoveNext())
            {
                Item each = (Item)items.Current;

                //определить сумму для каждой строки
                int bonus = GetBonus(each);
                double discount = GetDiscount(each);

                // сумма
                double thisAmount = GetSum(each);

                // учитываем скидку
                thisAmount -= discount;
                int usedBonus = GetUsedBonus(each, thisAmount);
                thisAmount -= usedBonus;

                //показать результаты
                result += GetItemString(each, discount, thisAmount, bonus);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }

            //добавить нижний колонтитул
            result += GetFooter(totalAmount, totalBonus);

            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }
    }
}