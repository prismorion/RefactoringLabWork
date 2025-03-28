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

        public string GetItemString(Item each, double discount, double thisAmount, int bonus)
        {
            return "\t\t<tr>\n" +
                   "\t\t\t<td>" + each.getGoods().getTitle() + "</td>\n" +
                   "\t\t\t<td>" + each.getPrice().ToString("F2") + "</td>\n" +
                   "\t\t\t<td>" + each.getQuantity() + "</td>\n" +
                   "\t\t\t<td>" + each.GetSum().ToString("F2") + "</td>\n" +
                   "\t\t\t<td>" + discount.ToString("F2") + "</td>\n" +
                   "\t\t\t<td>" + thisAmount.ToString("F2") + "</td>\n" +
                   "\t\t\t<td>" + bonus + "</td>\n" +
                   "\t\t</tr>\n";
        }
    }
}
