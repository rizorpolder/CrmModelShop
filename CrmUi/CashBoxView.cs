using System;
using CrmBl.Model;
using System.Windows.Forms;
namespace CrmUi
{
    class CashBoxView
    {
        private CashDesk cashDesk;

        public Label Label { get; set; }

        public NumericUpDown NumericUpDown { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;
            Label = new Label();
            NumericUpDown= new NumericUpDown();

            Label.AutoSize = true;
            Label.Location = new System.Drawing.Point(x, y);
            Label.Name = cashDesk.ToString();
            Label.Size = new System.Drawing.Size(35, 13);
            Label.TabIndex = number;
            Label.Text = cashDesk.ToString();
            // 
            // numericUpDown1
            // 
            NumericUpDown.Location = new System.Drawing.Point(x + 70, y);
            NumericUpDown.Name = "numericUpDown" + number;
            NumericUpDown.Size = new System.Drawing.Size(120, 20);
            NumericUpDown.TabIndex = number;
            NumericUpDown.Maximum = 1000000000;
            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            NumericUpDown.Invoke((Action) delegate { NumericUpDown.Value += e.Price; });
        }
    }
}
