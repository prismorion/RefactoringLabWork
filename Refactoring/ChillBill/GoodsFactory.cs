namespace ChillBill
{
    public static class GoodsFactory
    {
        public static Goods Create(string name, string type, DateTime currentDate)
        {
            bool isHoliday = IsHolidaySeason(currentDate);

            switch (type)
            {
                case "REG":
                    return new Goods(name,
                        isHoliday ? new HolidayRegularGoodsStrategy() : new RegularGoodsStrategy());
                case "SAL":
                    return new Goods(name,
                        isHoliday ? new HolidaySaleGoodsStrategy() : new SaleGoodsStrategy());
                case "SPO":
                    return new Goods(name,
                        isHoliday ? new HolidaySpecialGoodsStrategy() : new SpecialGoodsStrategy());
                default:
                    throw new ArgumentException($"Неизвестный тип товара: {type}");
            }
        }

        private static bool IsHolidaySeason(DateTime date)
        {
            var start = new DateTime(date.Year, 12, 18);
            var end = new DateTime(date.Year, 12, 31);
            return date >= start && date <= end;
        }
    }
}
