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
    public partial class PartnProd : Form
    {
        private PartnersDbContext? db;
        public PartnProd()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.db = new PartnersDbContext();
            //для загрузки всех типов продукций
            this.db.PartnersProductions.Load();
            this.dataGridView1.DataSource = db.PartnersProductions.Local.ToBindingList();

        }
        //при закрытии формы
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.db?.Dispose();
            this.db = null;

        }
    }
}
