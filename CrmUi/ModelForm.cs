using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;


namespace CrmUi
{



    public partial class ModelForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();
        public ModelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var cashBoxes = new List<CashBoxView>();

            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var box = new CashBoxView(model.CashDesks[i], i, 20, 26 * i);
                cashBoxes.Add(box);
                Controls.Add(box.Label);
                Controls.Add(box.NumericUpDown);

            }
            model.Start();
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }
    }
}
