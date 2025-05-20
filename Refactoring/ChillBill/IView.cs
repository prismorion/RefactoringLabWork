namespace ChillBill
{
    public interface IView
    {
        public string GetHeader(Customer _customer);
        public string GetFooter(double totalAmount, int totalBonus);
        public string GetItemString(ItemSummary itemSummary);
    }
}
