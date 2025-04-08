namespace Refactoring
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;

        public Bill(Customer customer)
        {
            _customer = customer;
            _items = new List<Item>();
        }

        public BillSummary Process(List<Item> items)
        {
            BillSummary billSummary = new BillSummary();            
            List<Item>.Enumerator _items = items.GetEnumerator();

            while (_items.MoveNext())
            {                
                Item each = _items.Current;
                ItemSummary itemSummary = new ItemSummary();

                itemSummary.Name = each.getGoods().getTitle();
                itemSummary.Bonus = each.GetBonus();
                itemSummary.Discount = (decimal)each.GetDiscount();
                itemSummary.Price = (decimal)each.getPrice();
                itemSummary.Quantity = each.getQuantity();

                itemSummary.Sum = (decimal)each.GetSum();
                itemSummary.Sum -= itemSummary.Discount;

                itemSummary.Sum -= each.GetUsedBonus(_customer, (double)itemSummary.Sum); ;

                billSummary.TotalAmount += itemSummary.Sum;
                billSummary.TotalBonus += itemSummary.Bonus;

                billSummary.ItemSummarys.Add(itemSummary);
            }

            _customer.receiveBonus(billSummary.TotalBonus);

            return billSummary;
        }
    }
}