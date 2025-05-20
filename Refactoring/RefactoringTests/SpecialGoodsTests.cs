using NUnit.Framework;
using ChillBill;

namespace RefactoringTests
{
    [TestFixture]
    public class SpecialGoodsTests
    {
        [Test]
        public void SpecialOfferItem_NoDiscount_LessThanOrEqualToTen()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Special Item", new SpecialGoodsStrategy()), 10, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t10\t500\t\t0\t400\t0\nСумма счета составляет 400\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SpecialOfferItem_WithDiscount_MoreThanTen()
        {
            // 0.5% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Special Item", new SpecialGoodsStrategy()), 11, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t11\t550\t\t2,75\t447,25\t0\nСумма счета составляет 447,25\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void HolidaySpecialOfferItem_NoDiscount_LessThanOrEqualThreeThousandRub_LessThanOrEqualToTen()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Special Item", new HolidaySpecialGoodsStrategy()), 10, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t30\t10\t300\t\t0\t200\t0\nСумма счета составляет 200\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void HolidaySpecialOfferItem_WithDiscount_MoreThanTen()
        {
            // 0.5% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Special Item", new HolidaySpecialGoodsStrategy()), 11, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t11\t550\t\t2,75\t447,25\t0\nСумма счета составляет 447,25\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void HolidaySpecialOfferItem_WithHolidayDiscount_MoreThanThreeThousandRub()
        {
            // 5% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Special Item", new HolidaySpecialGoodsStrategy()), 3, 1001));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t1001\t3\t3003\t\t150,15\t2752,85\t0\nСумма счета составляет 2752,85\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SpecialOfferItem_UsesBonus()
        {
            // Бонусы полностью покрывают сумму
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Special Item", new SpecialGoodsStrategy()), 2, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t2\t100\t\t0\t0\t0\nСумма счета составляет 0\nВы заработали 0 бонусных балов"));
        }
    }
}
