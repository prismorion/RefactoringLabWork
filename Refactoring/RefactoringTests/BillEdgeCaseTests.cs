using NUnit.Framework;
using ChillBill;

namespace RefactoringTests
{
    [TestFixture]
    public class BillEdgeCaseTests
    {
        [Test]
        public void EmptyCart_NoItems()
        {
            // Нет товаров
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void MixedItems()
        {
            // Несколько товаров
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Regular Item", new RegularGoodsStrategy()), 6, 100));
            bill.addGoods(new Item(new Goods("Special Item", new SpecialGoodsStrategy()), 2, 50));
            bill.addGoods(new Item(new Goods("Sale Item", new SaleGoodsStrategy()), 4, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t6\t600\t\t18\t482\t30\n\tSpecial Item\t\t50\t2\t100\t\t0\t100\t0\n\tSale Item\t\t30\t4\t120\t\t1,2\t118,8\t1\nСумма счета составляет 700,8\nВы заработали 31 бонусных балов"));
        }

        [Test]
        public void NoBonusAvailable_NoDiscountApplied()
        {
            // Бонусов нет, скидка не применяется
            Customer customer = new Customer("Test Customer", 0);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Special Item", new SpecialGoodsStrategy()), 2, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t2\t100\t\t0\t100\t0\nСумма счета составляет 100\nВы заработали 0 бонусных балов"));
        }
    }
}
