//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch3Ex6_OrderReceiptGUI
{
    public partial class Form1 : Form
    {

        const double BLENDER_PRICE = 39.95;
        double salesTax = 0;
        double beforeTax = 0;
        double netDue = 0;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtOrder.Text != "")
            {
                beforeTax = Convert.ToInt32(txtOrder.Text) * BLENDER_PRICE;

                if (beforeTax > 0 && txtZip.Text != "")
                {
                    salesTax = beforeTax * 0.07;
                    netDue = beforeTax + salesTax;

                    lblBeforeTaxC.Text = beforeTax.ToString("C");
                    lblSalesTaxC.Text = salesTax.ToString("C");
                    lblNetDueC.Text = netDue.ToString("C");

                    lblOrderCompletionStatus.ForeColor = Color.Green;
                    lblOrderCompletionStatus.Text = "COMPLETED ORDER";

                }
            }
            else
            {
                lblOrderCompletionStatus.ForeColor = Color.Red;
                lblOrderCompletionStatus.Text = "ORDER NOT COMPLETE";
            }
        }
    }
}
