namespace Refactoring
{
    public class TxtView : IView
    {
        public string GetHeader(Customer _customer)
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
                "\t" + each.GetSum().ToString() +
                "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                "\t" + bonus.ToString() + "\n";
        }
    }
}
