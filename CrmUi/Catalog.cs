using System;
using System.Data.Entity;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUi
{
    public partial class Catalog<T> : Form where T : class
    {
        private CrmContext db;
        public Catalog(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            this.db = db;
            set.Load();
            //dataGridView.DataSource = db.Set<T>().Local.ToBindingList();
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                //var form = new CustomerForm();
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    db.Customers.Add(form.Customer);
                //    db.SaveChanges();
                //}
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

        }
    }
}
