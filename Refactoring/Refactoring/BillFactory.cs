namespace Refactoring
{
    public class BillFactory
    {
        public static BillGenerator Create(IFileSource content, IView view)
        {
            Customer customer = content.ReadCustomer();
            BillGenerator bill = new BillGenerator(customer, view);

            int goodsCount = content.ReadGoodsCount();
            Goods[] goods = new Goods[goodsCount];
            for (int i = 0; i < goodsCount; i++)
            {
                goods[i] = content.ReadNextGood();
            }

            int itemsCount = content.ReadItemsCount();
            for (int i = 0; i < itemsCount; i++)
            {
                Item item = content.ReadNextItem(goods);
                bill.addGoods(item);
            }

            return bill;
        }
    }
}
