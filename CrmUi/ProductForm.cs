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
            Product = product;
            textBox1.Text = Product.Name;
            PriceNumeric.Value = Product.Price;
            CountNumeric.Value = Product.Count;
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var p = Product ?? new Product();
            if(p!=null)
            {
                p.Name = textBox1.Text;
                p.Price = PriceNumeric.Value;
                p.Count = Convert.ToInt32(CountNumeric.Value);
            }
            Close();
        }
    }
}
