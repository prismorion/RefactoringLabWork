using NUnit.Framework;
using ChillBill;

namespace RefactoringTests
{
    [TestFixture]
    public class BillBuilderTests
    {
        [Test]
        public void CreateBill_FromYamlInput_ShouldBuildCorrectBill()
        {
            string yamlInput = @"
Date: 06.05.2025
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

            Assert.That(billTxt, Is.EqualTo("Счет для Test\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t\t0\t150\t1\n\tFanta\t\t35\t1\t35\t\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных балов"));
        }

        [Test]
        public void CreateBill_FromJsonInput_ShouldBuildCorrectBill()
        {
            string jsonInput = @"
{
  ""Date"": ""06.05.2025"",  
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

            Assert.That(billTxt, Is.EqualTo("Счет для Test\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t\t0\t150\t1\n\tFanta\t\t35\t1\t35\t\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных балов"));
        }

        [Test]
        public void CreateHolidayBill_FromYamlInput_ShouldBuildCorrectBill()
        {
            string yamlInput = @"
Date: 20.12.2025
CustomerName: Test
CustomerBonus: 10
GoodsTotalCount: 3
# ID: NAME TYPE(REG/SAL/SPO)
1: Cola REG
2: Pepsi SAL
3: Fanta SPO
ItemsTotalCount: 3
# ID: GID PRICE QTY
1: 1 65 80
2: 2 50 50
3: 3 35 90";

            yamlInput = yamlInput.TrimStart();

            StringReader stringReader = new StringReader(yamlInput);
            BillBuilder builder = new BillBuilder();
            BillGenerator bill = builder.CreateBill(stringReader, ".yaml", new TxtView());

            string billTxt = bill.GenerateBill();

            Assert.That(billTxt, Is.EqualTo("Счет для Test\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t80\t5200\t\t156\t5034\t364\n\tPepsi\t\t50\t50\t2500\t\t75\t2425\t25\n\tFanta\t\t35\t90\t3150\t\t157,5\t2992,5\t0\nСумма счета составляет 10451,5\nВы заработали 389 бонусных балов"));
        }

        [Test]
        public void CreateHolidayBill_FromJsonInput_ShouldBuildCorrectBill()
        {
            string jsonInput = @"
{
  ""Date"": ""20.12.2025"",  
  ""Customer"": { ""Name"": ""Test"", ""Bonus"": 10 },
  ""Goods"": [
    { ""Id"": 1, ""Name"": ""Cola"", ""Type"": ""REG"" },
    { ""Id"": 2, ""Name"": ""Pepsi"", ""Type"": ""SAL"" },
    { ""Id"": 3, ""Name"": ""Fanta"", ""Type"": ""SPO"" }
  ],
  ""Items"": [
    { ""Id"": 1, ""GID"": 1, ""Price"": 65, ""Qty"": 80 },
    { ""Id"": 2, ""GID"": 2, ""Price"": 50, ""Qty"": 50 },
    { ""Id"": 3, ""GID"": 3, ""Price"": 35, ""Qty"": 90 }
  ]
}";

            jsonInput = jsonInput.TrimStart();

            StringReader stringReader = new StringReader(jsonInput);

            BillBuilder builder = new BillBuilder();
            BillGenerator bill = builder.CreateBill(stringReader, ".json", new TxtView());

            string billTxt = bill.GenerateBill();

            Assert.That(billTxt, Is.EqualTo("Счет для Test\n\tНазвание\tЦена\tКол-во\tСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t80\t5200\t\t156\t5034\t364\n\tPepsi\t\t50\t50\t2500\t\t75\t2425\t25\n\tFanta\t\t35\t90\t3150\t\t157,5\t2992,5\t0\nСумма счета составляет 10451,5\nВы заработали 389 бонусных балов"));
        }
    }
}
