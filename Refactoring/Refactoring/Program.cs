namespace Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.yaml";
            if (args.Length == 1)
                filename = args[0];

            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader streamReader = new StreamReader(fs);
            BillBuilder builder = new BillBuilder();

            BillGenerator bill = builder.CreateBill(streamReader, new TxtView());
            string billTxt = bill.GenerateBill();
            Console.WriteLine(billTxt);
        }
    }
}
