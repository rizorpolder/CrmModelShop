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

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product = new Product()
            {
                Name=textBox1.Text,
                Price = PriceNumeric.Value,
                Count = Convert.ToInt32(CountNumeric.Value)
            };
            Close();
        }
    }
}
