namespace Refactoring
{
    public class TxtViewTest : IView
    {
        public string GetHeader(Customer _customer)
        {
            return "Счет для " + _customer.getName() + "\\n" + "\\t" + "Название" + "\\t" + "Цена" +
            "\\t" + "Кол-во" + "Стоимость" + "\\t" + "Скидка" +
            "\\t" + "Сумма" + "\\t" + "Бонус" + "\\n";
        }

        public string GetFooter(double totalAmount, int totalBonus)
        {
            return "Сумма счета составляет " + totalAmount.ToString() + "\\n" +
                "Вы заработали " + totalBonus.ToString() + " бонусных балов";
        }

        public string GetItemString(ItemSummary itemSummary)
        {
            return "\\t" + itemSummary.Name + "\\t" +
                "\\t" + itemSummary.Price + "\\t" + itemSummary.Quantity +
                "\\t" + ((double)itemSummary.Price * itemSummary.Quantity) + "\\t" +
                itemSummary.Discount + "\\t" + itemSummary.Sum + "\\t" + itemSummary.Bonus + "\\n";
        }
    }
}
