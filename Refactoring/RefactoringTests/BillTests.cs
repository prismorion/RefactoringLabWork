using NUnit.Framework;
using Refactoring;

namespace RefactoringTests
{
    [TestFixture]
    public class BillTests
    {
        [Test]
        public void EmptyCart_NoItems()
        {
            // Нет товаров
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void RegularItem_NoDiscount_LessThanThree()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Regular Item", Goods.REGULAR), 2, 100));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t2\t200\t0\t200\t10\nСумма счета составляет 200\nВы заработали 10 бонусных балов"));
        }

        [Test]
        public void RegularItem_WithDiscount_MoreThanTwo()
        {
            // 3% скидка
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Regular Item", Goods.REGULAR), 3, 100));
            string statement = bill.statement();
            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t3\t300\t9\t291\t15\nСумма счета составляет 291\nВы заработали 15 бонусных балов"));
        }

        [Test]
        public void RegularItem_WithBonusUsage()
        {
            // Учитывает бонус
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Regular Item", Goods.REGULAR), 6, 100));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t6\t600\t18\t482\t30\nСумма счета составляет 482\nВы заработали 30 бонусных балов"));
        }

        [Test]
        public void SpecialOfferItem_NoDiscount_LessThanOrEqualToTen()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Special Item", Goods.SPECIAL_OFFER), 10, 50));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t10\t500\t0\t400\t0\nСумма счета составляет 400\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SpecialOfferItem_WithDiscount_MoreThanTen()
        {
            // 0.5% скидка
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Special Item", Goods.SPECIAL_OFFER), 11, 50));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t11\t550\t2,75\t447,25\t0\nСумма счета составляет 447,25\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SpecialOfferItem_UsesBonus()
        {
            // Бонусы полностью покрывают сумму
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Special Item", Goods.SPECIAL_OFFER), 2, 50));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t2\t100\t0\t0\t0\nСумма счета составляет 0\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SaleItem_NoDiscount_LessThanOrEqualToThree()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Sale Item", Goods.SALE), 3, 30));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t30\t3\t90\t0\t90\t0\nСумма счета составляет 90\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SaleItem_WithDiscount_MoreThanThree()
        {
            // 0.1% скидка
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Sale Item", Goods.SALE), 4, 30));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t30\t4\t120\t1,2\t118,8\t1\nСумма счета составляет 118,8\nВы заработали 1 бонусных балов"));
        }

        [Test]
        public void MixedItems()
        {
            // Несколько товаров
            Customer customer = new Customer("Test Customer", 100);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Regular Item", Goods.REGULAR), 6, 100));
            bill.addGoods(new Item(new Goods("Special Item", Goods.SPECIAL_OFFER), 2, 50));
            bill.addGoods(new Item(new Goods("Sale Item", Goods.SALE), 4, 30));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t6\t600\t18\t482\t30\n\tSpecial Item\t\t50\t2\t100\t0\t100\t0\n\tSale Item\t\t30\t4\t120\t1,2\t118,8\t1\nСумма счета составляет 700,8\nВы заработали 31 бонусных балов"));
        }

        [Test]
        public void NoBonusAvailable_NoDiscountApplied()
        {
            // Бонусов нет, скидка не применяется
            Customer customer = new Customer("Test Customer", 0);
            Bill bill = new Bill(customer);

            bill.addGoods(new Item(new Goods("Special Item", Goods.SPECIAL_OFFER), 2, 50));
            string statement = bill.statement();

            Assert.That(statement, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t2\t100\t0\t100\t0\nСумма счета составляет 100\nВы заработали 0 бонусных балов"));
        }
    }
}
