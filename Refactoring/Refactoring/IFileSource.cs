namespace Refactoring
{
    public interface IFileSource
    {
        public void SetSource(TextReader reader);
        public DateTime GetDate();
        public Customer ReadCustomer();
        public int ReadGoodsCount();
        public Goods ReadNextGood();
        public int ReadItemsCount();
        public Item ReadNextItem(Goods[] goods);
    }
}
