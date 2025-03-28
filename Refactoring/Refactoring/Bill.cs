namespace Refactoring
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public IView View { get; set; }

        public Bill(Customer customer, IView view)
        {
            _customer = customer;
            _items = new List<Item>();
            View = view;
        }

        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }        

        public double GetSum(Item each)
        {
            double sum = each.getQuantity() * each.getPrice();
            return sum;
        }

        public string GenerateBill()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();

            string result = View.GetHeader(_customer);

            while (items.MoveNext())
            {
                Item each = (Item)items.Current;

                //определить сумму для каждой строки
                int bonus = each.GetBonus();
                double discount = each.GetDiscount();

                // сумма
                double thisAmount = GetSum(each);

                // учитываем скидку
                thisAmount -= discount;
                int usedBonus = each.GetUsedBonus(_customer, thisAmount);
                thisAmount -= usedBonus;

                //показать результаты
                result += View.GetItemString(each, discount, thisAmount, bonus);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }

            //добавить нижний колонтитул
            result += View.GetFooter(totalAmount, totalBonus);

            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }
    }
}