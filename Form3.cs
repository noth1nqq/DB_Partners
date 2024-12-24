using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Form3 : Form
    {
        private PartnersDbContext? db;
        public Form3()
        {
            InitializeComponent();

            this.dataGridView1.SelectionChanged += DataGridViewChanges;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.db = new PartnersDbContext();
            //для загрузки всех типов продукций
            this.db.Partners.Load();
            this.dataGridView1.DataSource = db.Partners.Local.ToBindingList();

            var partners = this.db.Partners
                .Select(p=> new
                {
                    p.Id,
                    p.NameOfPartner
                })
                .ToList();
           

        }
        //при закрытии формы
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.db?.Dispose();
            this.db = null;

        }

        private void DataGridViewChanges(object sender, EventArgs e)
        {
            if (this.db != null && this.dataGridView1.CurrentRow != null)
            {
               
                var partner = (Partner)this.dataGridView1.CurrentRow.DataBoundItem;
                if (partner != null)
                {
                    
                    this.db.Entry(partner).Collection(p => p.PartnersProductions).Load();

                   
                    this.dataGridView2.DataSource = partner.PartnersProductions.ToList();
                    this.dataGridView2.Refresh(); 
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
