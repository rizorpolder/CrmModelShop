using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUi
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }

        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(Product product) : this()
        {
            Product = product ?? new Product();
            textBox1.Text = Product.Name;
            PriceNumeric.Value = Product.Price;
            CountNumeric.Value = Product.Count;
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();
            if (Product != null)
            {
                Product.Name = textBox1.Text;
                Product.Price = PriceNumeric.Value;
                Product.Count = Convert.ToInt32(CountNumeric.Value);
            }
            Close();
        }
    }
}
