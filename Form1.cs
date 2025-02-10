using System;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Text;


namespace Note
{
    public partial class Form1 : Form
    {
        private string _openFile;
        public Form1()
        {
            InitializeComponent();
        }


        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.White;   // белый цвет текста
            richTextBox1.BackColor = Color.DarkGray;    // темно-серый фон
            menuStrip1.BackColor = Color.DarkGray;  // темно-серый фон меню
        }

        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black; // черный цвет текста
            richTextBox1.BackColor = Color.White;   // белый фон
            menuStrip1.BackColor = Color.PapayaWhip;    // светло-бежевый фон меню
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog myFont = new FontDialog();   // создает диалог выбора шрифта
            if (myFont.ShowDialog() == DialogResult.OK) // Если пользователь выбирает шрифт и нажимает "ОК", шрифт применяется к richTextBox1
            {
                richTextBox1.Font = myFont.Font;
            }
        }

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now;
        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Fdialog = new OpenFileDialog();  // создает диалог открытия файла
            Fdialog.Filter = "all (*.*) | *.*"; // позволяет выбирать файлы любого типа
            if (Fdialog.ShowDialog() == DialogResult.OK) // Если пользователь выбирает файл, его содержимое загружается в richTextBox1
            {
                richTextBox1.Text = File.ReadAllText(Fdialog.FileName);
                _openFile = Fdialog.FileName;
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sldialog = new SaveFileDialog(); // создает диалог сохранения файла
            Sldialog.Filter = "all (*.*)|*.*";  //  позволяет выбрать файлы любого типа
            if (Sldialog.ShowDialog() == DialogResult.OK)   // Если пользователь выбирает путь и имя файла, содержимое richTextBox1 сохраняется в этот файл
            {
                File.WriteAllText(Sldialog.FileName, richTextBox1.Text);
                _openFile = Sldialog.FileName;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)  // Если файл не был открыт, выводит сообщение об ошибке.
        {
            try
            {
                File.WriteAllText(_openFile, richTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("save error");
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pDocument = new PrintDocument();
            pDocument.PrintPage += PrintPageH;
            PrintDialog pDialog = new PrintDialog();
            pDialog.Document = pDocument;
            if(pDialog.ShowDialog() == DialogResult.OK)
            {
                pDialog.Document.Print();
            }
        }

        public void PrintPageH(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 0, 0);
        }
    }
}
