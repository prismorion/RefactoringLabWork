namespace Refactoring
{
    public interface IView
    {
        public string GetHeader(Customer _customer);
        public string GetFooter(double totalAmount, int totalBonus);
        public string GetItemString(Item each, double discount, double thisAmount, int bonus);
    }
}
