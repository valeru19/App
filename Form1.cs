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


        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.White;   // ����� ���� ������
            richTextBox1.BackColor = Color.DarkGray;    // �����-����� ���
            menuStrip1.BackColor = Color.DarkGray;  // �����-����� ��� ����
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black; // ������ ���� ������
            richTextBox1.BackColor = Color.White;   // ����� ���
            menuStrip1.BackColor = Color.PapayaWhip;    // ������-������� ��� ����
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog myFont = new FontDialog();   // ������� ������ ������ ������
            if (myFont.ShowDialog() == DialogResult.OK) // ���� ������������ �������� ����� � �������� "��", ����� ����������� � richTextBox1
            {
                richTextBox1.Font = myFont.Font;
            }
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now;
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Fdialog = new OpenFileDialog();  // ������� ������ �������� �����
            Fdialog.Filter = "all (*.*) | *.*"; // ��������� �������� ����� ������ ����
            if (Fdialog.ShowDialog() == DialogResult.OK) // ���� ������������ �������� ����, ��� ���������� ����������� � richTextBox1
            {
                richTextBox1.Text = File.ReadAllText(Fdialog.FileName);
                _openFile = Fdialog.FileName;
            }
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sldialog = new SaveFileDialog(); // ������� ������ ���������� �����
            Sldialog.Filter = "all (*.*)|*.*";  //  ��������� ������� ����� ������ ����
            if (Sldialog.ShowDialog() == DialogResult.OK)   // ���� ������������ �������� ���� � ��� �����, ���������� richTextBox1 ����������� � ���� ����
            {
                File.WriteAllText(Sldialog.FileName, richTextBox1.Text);
                _openFile = Sldialog.FileName;
            }
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)  // ���� ���� �� ��� ������, ������� ��������� �� ������.
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

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
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
