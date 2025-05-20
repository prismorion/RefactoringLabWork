namespace BillApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            filePath = new TextBox();
            generateBtn = new Button();
            textBox = new RichTextBox();
            copyBtn = new Button();
            label1 = new Label();
            txtView = new RadioButton();
            htmlView = new RadioButton();
            SuspendLayout();
            // 
            // filePath
            // 
            filePath.AllowDrop = true;
            filePath.Location = new Point(14, 36);
            filePath.Margin = new Padding(3, 4, 3, 4);
            filePath.Name = "filePath";
            filePath.Size = new Size(541, 27);
            filePath.TabIndex = 0;
            filePath.DragDrop += filePath_DragDrop;
            filePath.DragEnter += filePath_DragEnter;
            // 
            // generateBtn
            // 
            generateBtn.Location = new Point(562, 36);
            generateBtn.Margin = new Padding(3, 4, 3, 4);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(137, 31);
            generateBtn.TabIndex = 1;
            generateBtn.Text = "Сгенерировать чек";
            generateBtn.UseVisualStyleBackColor = true;
            generateBtn.Click += generateBtn_Click;
            // 
            // textBox
            // 
            textBox.Location = new Point(14, 141);
            textBox.Margin = new Padding(3, 4, 3, 4);
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            textBox.Size = new Size(685, 399);
            textBox.TabIndex = 4;
            textBox.Text = "";
            // 
            // copyBtn
            // 
            copyBtn.Location = new Point(585, 103);
            copyBtn.Margin = new Padding(3, 4, 3, 4);
            copyBtn.Name = "copyBtn";
            copyBtn.Size = new Size(114, 31);
            copyBtn.TabIndex = 5;
            copyBtn.Text = "Копировать";
            copyBtn.UseVisualStyleBackColor = true;
            copyBtn.Click += copyBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 6;
            label1.Text = "Путь к файлу";
            // 
            // txtView
            // 
            txtView.AutoSize = true;
            txtView.Checked = true;
            txtView.Location = new Point(14, 75);
            txtView.Margin = new Padding(3, 4, 3, 4);
            txtView.Name = "txtView";
            txtView.Size = new Size(209, 24);
            txtView.TabIndex = 7;
            txtView.TabStop = true;
            txtView.Text = "Текстовое представление";
            txtView.UseVisualStyleBackColor = true;
            // 
            // htmlView
            // 
            htmlView.AutoSize = true;
            htmlView.Location = new Point(14, 108);
            htmlView.Margin = new Padding(3, 4, 3, 4);
            htmlView.Name = "htmlView";
            htmlView.Size = new Size(178, 24);
            htmlView.TabIndex = 8;
            htmlView.Text = "HTML представление";
            htmlView.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 557);
            Controls.Add(htmlView);
            Controls.Add(txtView);
            Controls.Add(label1);
            Controls.Add(copyBtn);
            Controls.Add(textBox);
            Controls.Add(generateBtn);
            Controls.Add(filePath);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Генератор чеков";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox filePath;
        private Button generateBtn;
        private RichTextBox textBox;
        private Button copyBtn;
        private Label label1;
        private RadioButton txtView;
        private RadioButton htmlView;
    }
}
