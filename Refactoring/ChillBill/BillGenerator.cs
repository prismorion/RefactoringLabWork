namespace ChillBill
{
    public class BillGenerator
    {
        private List<Item> _items;
        private Customer _customer;
        private Bill _bill;
        public IView View { get; set; }

        public BillGenerator(Customer customer, IView view)
        {
            _customer = customer;
            _items = new List<Item>();
            View = view;
            _bill = new Bill(_customer);
        }

        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }

        public string GenerateBill()
        {
            BillSummary billSummary = _bill.Process(_items);

            List<ItemSummary>.Enumerator items = billSummary.ItemSummarys.GetEnumerator();

            string result = View.GetHeader(_customer);

            while (items.MoveNext())
            {
                result += View.GetItemString(items.Current);
            }

            result += View.GetFooter((double)billSummary.TotalAmount, billSummary.TotalBonus);

            return result;
        }
    }
}
