using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using Refactoring;
using System.IO;
using System.Reflection.Emit;

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
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void RegularItem_NoDiscount_LessThanThree()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new RegularGoods("Regular Item"), 2, 100));
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

            bill.addGoods(new Item(new RegularGoods("Regular Item"), 3, 100));
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

            bill.addGoods(new Item(new RegularGoods("Regular Item"), 6, 100));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t6\t600\t18\t482\t30\nСумма счета составляет 482\nВы заработали 30 бонусных балов"));
        }

        [Test]
        public void SpecialOfferItem_NoDiscount_LessThanOrEqualToTen()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new SpecialGoods("Special Item"), 10, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t10\t500\t0\t400\t0\nСумма счета составляет 400\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SpecialOfferItem_WithDiscount_MoreThanTen()
        {
            // 0.5% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new SpecialGoods("Special Item"), 11, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t11\t550\t2,75\t447,25\t0\nСумма счета составляет 447,25\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SpecialOfferItem_UsesBonus()
        {
            // Бонусы полностью покрывают сумму
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new SpecialGoods("Special Item"), 2, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t2\t100\t0\t0\t0\nСумма счета составляет 0\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SaleItem_NoDiscount_LessThanOrEqualToThree()
        {
            // Нет скидки
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new SaleGoods("Sale Item"), 3, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t30\t3\t90\t0\t90\t0\nСумма счета составляет 90\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void SaleItem_WithDiscount_MoreThanThree()
        {
            // 0.1% скидка
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new SaleGoods("Sale Item"), 4, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSale Item\t\t30\t4\t120\t1,2\t118,8\t1\nСумма счета составляет 118,8\nВы заработали 1 бонусных балов"));
        }

        [Test]
        public void MixedItems()
        {
            // Несколько товаров
            Customer customer = new Customer("Test Customer", 100);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new RegularGoods("Regular Item"), 6, 100));
            bill.addGoods(new Item(new SpecialGoods("Special Item"), 2, 50));
            bill.addGoods(new Item(new SaleGoods("Sale Item"), 4, 30));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tRegular Item\t\t100\t6\t600\t18\t482\t30\n\tSpecial Item\t\t50\t2\t100\t0\t100\t0\n\tSale Item\t\t30\t4\t120\t1,2\t118,8\t1\nСумма счета составляет 700,8\nВы заработали 31 бонусных балов"));
        }

        [Test]
        public void NoBonusAvailable_NoDiscountApplied()
        {
            // Бонусов нет, скидка не применяется
            Customer customer = new Customer("Test Customer", 0);
            IView view = new TxtView();
            BillGenerator bill = new BillGenerator(customer, view);

            bill.addGoods(new Item(new SpecialGoods("Special Item"), 2, 50));
            string GenerateBill = bill.GenerateBill();

            Assert.That(GenerateBill, Is.EqualTo("Счет для Test Customer\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tSpecial Item\t\t50\t2\t100\t0\t100\t0\nСумма счета составляет 100\nВы заработали 0 бонусных балов"));
        }

        [Test]
        public void CreateBill_FromYamlInput_ShouldBuildCorrectBill()
        {
            string yamlInput = @"
CustomerName: Test
CustomerBonus: 10
GoodsTotalCount: 3
# ID: NAME TYPE(REG/SAL/SPO)
1: Cola REG
2: Pepsi SAL
3: Fanta SPO
ItemsTotalCount: 3
# ID: GID PRICE QTY
1: 1 65 6
2: 2 50 3
3: 3 35 1";

            yamlInput = yamlInput.TrimStart();

            StringReader stringReader = new StringReader(yamlInput);
            BillBuilder builder = new BillBuilder();
            BillGenerator bill = builder.CreateBill(stringReader, ".yaml", new TxtView());

            string billTxt = bill.GenerateBill();

            Assert.That(billTxt, Is.EqualTo("Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных балов"));
        }

        [Test]
        public void CreateBill_FromJsonInput_ShouldBuildCorrectBill()
        {
            string jsonInput = @"
{
  ""Customer"": { ""Name"": ""Test"", ""Bonus"": 10 },
  ""Goods"": [
    { ""Id"": 1, ""Name"": ""Cola"", ""Type"": ""REG"" },
    { ""Id"": 2, ""Name"": ""Pepsi"", ""Type"": ""SAL"" },
    { ""Id"": 3, ""Name"": ""Fanta"", ""Type"": ""SPO"" }
  ],
  ""Items"": [
    { ""Id"": 1, ""GID"": 1, ""Price"": 65, ""Qty"": 6 },
    { ""Id"": 2, ""GID"": 2, ""Price"": 50, ""Qty"": 3 },
    { ""Id"": 3, ""GID"": 3, ""Price"": 35, ""Qty"": 1 }
  ]
}";

            jsonInput = jsonInput.TrimStart();

            StringReader stringReader = new StringReader(jsonInput);

            BillBuilder builder = new BillBuilder();
            BillGenerator bill = builder.CreateBill(stringReader, ".json", new TxtView());

            string billTxt = bill.GenerateBill();

            Assert.That(billTxt, Is.EqualTo("Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных балов"));
        }

    }
}
