using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{  
    public partial class Product : Form
    {
        private PartnersDbContext? db;
        public Product()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.db = new PartnersDbContext();
            //для загрузки всех типов продукций
            this.db.Productions.Load();
            this.dataGridView1.DataSource = db.Productions.Local.ToBindingList();

        }
        //при закрытии формы
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.db?.Dispose();
            this.db = null;

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
