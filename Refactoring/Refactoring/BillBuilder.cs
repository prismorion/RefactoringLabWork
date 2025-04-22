namespace Refactoring
{
    public class BillBuilder
    {
        public BillGenerator CreateBill(TextReader textReader, string fileType, IView view)
        {
            IFileSource content = FileSourceFactory.CreateFileSource(fileType);
            content.SetSource(textReader);
            return BillFactory.Create(content, view);
        }
    }
}
