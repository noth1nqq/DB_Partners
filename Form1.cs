using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //отслеживает изменени€
        private PartnersDbContext? db;
        public Form1()
        {
            InitializeComponent();
            //Form1_Load(this, EventArgs.Empty);

        }
        //вызываетс€ при загрузке формы
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.db = new PartnersDbContext();
            //дл€ загрузки всех партнеров
            this.db.TypesOfPartners.Load();
            this.dataGridView1.DataSource = db.TypesOfPartners.Local.ToBindingList();

        }
        //при закрытии формы
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
                // ќтображаем Form2 как модальное окно
                form2.ShowDialog(this);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var form3 = new Form3())
            {
                // ќтображаем Form2 как модальное окно
                form3.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var PartnProdct = new PartnProd())
            {
                // ќтображаем Form2 как модальное окно
                PartnProdct.ShowDialog(this);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var Product = new Product())
            {
                // ќтображаем Form2 как модальное окно
                Product.ShowDialog(this);
            }
        }
    }
}
