namespace ChillBill
{
    public class BillSummary
    {
        public decimal TotalAmount;
        public decimal TotalDiscount;
        public string CustomerName;
        public int TotalBonus;
        public List<ItemSummary> ItemSummarys = new List<ItemSummary>();
    }
}
