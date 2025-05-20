using NUnit.Framework;
using ChillBill;

namespace RefactoringTests
{
    [TestFixture]
    public class SaleGoodsTests
    {
        [Test]
        public void SaleItem_NoDiscount_LessThanOrEqualToThree()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Sale Item", new SaleGoodsStrategy()), 3, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t30\t3\t90\t\t0\t90\t0\nСумма счета составляет 90\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SaleItem_WithDiscount_MoreThanThree()
        {
            // 1% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Sale Item", new SaleGoodsStrategy()), 4, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t30\t4\t120\t\t1,2\t118,8\t1\nСумма счета составляет 118,8\nВы заработали 1 бонусных балов"));
        }

        [Test]
        public void HolidaySaleItem_NoDiscount_LessThanOrEqualTwoThousandRub_LessThanOrEqualToThree()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Sale Item", new HolidaySaleGoodsStrategy()), 3, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t30\t3\t90\t\t0\t90\t0\nСумма счета составляет 90\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void HolidaySaleItem_NoHolidayDiscount_LessThanOrEqualToThree()
        {
            // 1% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Sale Item", new HolidaySaleGoodsStrategy()), 4, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t30\t4\t120\t\t1,2\t118,8\t1\nСумма счета составляет 118,8\nВы заработали 1 бонусных балов"));
        }

        [Test]
        public void HolidaySaleItem_WithHolidayDiscount_MoreThanThree()
        {
            // 3% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Sale Item", new HolidaySaleGoodsStrategy()), 2, 1001));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t1001\t2\t2002\t\t60,06\t1941,94\t20\nСумма счета составляет 1941,94\nВы заработали 20 бонусных балов"));
        }
    }
}
