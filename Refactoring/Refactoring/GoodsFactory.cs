namespace Refactoring
{
    public static class GoodsFactory
    {
        public static Goods Create(string name, string type)
        {
            switch (type)
            {
                case "REG":
                    return new RegularGoods(name);
                case "SAL":
                    return new SaleGoods(name);
                case "SPO":
                    return new SpecialGoods(name);
                default:
                    throw new ArgumentException($"Неизвестный тип товара: {type}");
            }
        }
    }
}
