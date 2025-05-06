namespace Refactoring
{
    public interface IGoodsStrategy
    {
        double GetDiscount(int quantity, double price);
        int GetBonus(int quantity, double price);          
        int GetUsedBonus(Customer customer, int quantity, double amount);
    }
}
