using ChillBill;

namespace BillApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            if (filePath.Text.Length > 0)
            {
                try
                {
                    string fileType = Path.GetExtension(filePath.Text).ToLower();

                    FileStream fs = new FileStream(filePath.Text, FileMode.Open);
                    StreamReader streamReader = new StreamReader(fs);
                    BillBuilder builder = new BillBuilder();

                    IView view = new TxtViewTest();
                    if (txtView.Checked)
                        view = new TxtView();
                    if (htmlView.Checked)
                        view = new HtmlView();
                    BillGenerator bill = builder.CreateBill(streamReader, fileType, view);
                    string billTxt = bill.GenerateBill().Replace("\n", "\r\n");

                    textBox.Text = billTxt;
                    streamReader.Close();
                }
                catch { }
            }
        }

        private void filePath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files != null && files.Length > 0)
                    filePath.Text = files[0];
            }
        }

        private void filePath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox.Text);
            MessageBox.Show("Скопировано", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
