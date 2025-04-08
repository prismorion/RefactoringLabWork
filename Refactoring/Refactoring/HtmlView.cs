namespace Refactoring
{
    public class HtmlView : IView
    {
        public string GetHeader(Customer _customer)
        {
            return "<html>\n<head>\n\t<title>Счет</title>\n</head>\n<body>\n" +
                   "\t<h1>Счет для " + _customer.getName() + "</h1>\n" +
                   "\t<table border='1'>\n\t\t<tr>\n\t\t\t<th>Название</th>\n\t\t\t<th>Цена</th>\n\t\t\t<th>Кол-во</th>\n" +
                   "\t\t\t<th>Стоимость</th>\n\t\t\t<th>Скидка</th>\n\t\t\t<th>Сумма</th>\n\t\t\t<th>Бонус</th>\n\t\t</tr>\n";
        }

        public string GetFooter(double totalAmount, int totalBonus)
        {
            return "\t</table>\n" +
                   "\t<p><strong>Сумма счета составляет: " + totalAmount.ToString("F2") + "</strong></p>\n" +
                   "\t<p>Вы заработали <strong>" + totalBonus + "</strong> бонусных баллов</p>\n" +
                   "</body>\n</html>\n";
        }

        public string GetItemString(ItemSummary itemSummary)
        {
            return "\t\t<tr>\n" +
                   "\t\t\t<td>" + itemSummary.Name + "</td>\n" +
                   "\t\t\t<td>" + itemSummary.Price.ToString("F2") + "</td>\n" +
                   "\t\t\t<td>" + itemSummary.Quantity + "</td>\n" +
                   "\t\t\t<td>" + ((double)itemSummary.Price * itemSummary.Quantity).ToString("F2") + "</td>\n" +
                   "\t\t\t<td>" + itemSummary.Discount.ToString("F2") + "</td>\n" +
                   "\t\t\t<td>" + itemSummary.Sum.ToString("F2") + "</td>\n" +
                   "\t\t\t<td>" + itemSummary.Bonus + "</td>\n" +
                   "\t\t</tr>\n";
        }
    }
}
