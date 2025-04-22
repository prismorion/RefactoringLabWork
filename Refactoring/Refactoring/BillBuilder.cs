namespace Refactoring
{
    public class BillBuilder
    {
        public BillGenerator CreateBill(TextReader textReader, IView view)
        {
            ContentFile content = new ContentFile();
            content.SetSource(textReader);
            return BillFactory.Create(content, view);
        }
    }
}
