using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //����������� ���������
        private PartnersDbContext? db;
        public Form1()
        {
            InitializeComponent();
            //Form1_Load(this, EventArgs.Empty);

        }
        //���������� ��� �������� �����
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.db = new PartnersDbContext();
            //��� �������� ���� ���������
            this.db.TypesOfPartners.Load();
            this.dataGridView1.DataSource = db.TypesOfPartners.Local.ToBindingList();

        }
        //��� �������� �����
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.db?.Dispose();
            this.db = null;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var form2 = new Form2())
            {
                // ���������� Form2 ��� ��������� ����
                form2.ShowDialog(this);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var form3 = new Form3())
            {
                // ���������� Form2 ��� ��������� ����
                form3.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var PartnProdct = new PartnProd())
            {
                // ���������� Form2 ��� ��������� ����
                PartnProdct.ShowDialog(this);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var Product = new Product())
            {
                // ���������� Form2 ��� ��������� ����
                Product.ShowDialog(this);
            }
        }
    }
}
