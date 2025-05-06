using NUnit.Framework;
using Refactoring;

namespace RefactoringTests
{
    [TestFixture]
    public class RegularGoodsTests
    {
        [Test]
        public void RegularItem_NoDiscount_LessThanThree()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Regular Item", new RegularGoodsStrategy()), 2, 100));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t2\t200\t0\t200\t10\nСумма счета составляет 200\nВы заработали 10 бонусных балов"));
        }

        [Test]
        public void RegularItem_WithDiscount_MoreThanTwo()
        {
            // 3% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Regular Item", new RegularGoodsStrategy()), 3, 100));
            string GenerateBill = bill.GenerateBill();
            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t3\t300\t9\t291\t15\nСумма счета составляет 291\nВы заработали 15 бонусных балов"));
        }

        [Test]
        public void RegularItem_WithBonusUsage()
        {
            // Учитывает бонус
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Regular Item", new RegularGoodsStrategy()), 6, 100));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t6\t600\t18\t482\t30\nСумма счета составляет 482\nВы заработали 30 бонусных балов"));
        }

        [Test]
        public void HolidayRegularItem_NoHolidayBonus_LessThanOrEqualFiveThousandRub()
        {
            // 5% бонус
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Regular Item", new HolidayRegularGoodsStrategy()), 5, 1000));
            string GenerateBill = bill.GenerateBill();
            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t1000\t5\t5000\t150\t4850\t250\nСумма счета составляет 4850\nВы заработали 250 бонусных балов"));
        }

        [Test]
        public void HolidayRegularItem_WithHolidayBonus_MoreThanFiveThousandRub()
        {
            // 7% бонус
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new Goods("Regular Item", new HolidayRegularGoodsStrategy()), 5, 1001));
            string GenerateBill = bill.GenerateBill();
            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t1001\t5\t5005\t150,15\t4854,85\t350\nСумма счета составляет 4854,85\nВы заработали 350 бонусных балов"));
        }
    }
}
