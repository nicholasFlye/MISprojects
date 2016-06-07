using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace WindowsFormsApplication1
{
    public partial class AddNewContribution : Form
    {
        Form1 callingForm; 

        List<Contribution> contributions = new List<Contribution>();

        public AddNewContribution()
        {
            InitializeComponent();
            lsbMethod.SelectionMode = SelectionMode.One;
            lsbDesignatedFund.SelectionMode = SelectionMode.One;
        }

        /// <summary>
        /// This allows this form and form1 to share information
        /// </summary>
        /// <param name="anc"></param>
        public AddNewContribution(Form1 anc)
        {
            callingForm = anc;  
            InitializeComponent();
        }



        private void btnSaved_Click(object sender, EventArgs e)
        {
            Contribution c = new Contribution();
            c.ContributionNumber = Convert.ToInt32(lblContributionNo.Text);
            c.MemberID = Convert.ToInt32(txtMemberID.Text);
            c.ContributionDate = Convert.ToDateTime(dtpContributionDate.Value);
            c.Amount = Convert.ToDouble(txtAmount.Text);
            c.Method = lsbMethod.Text;
            c.CheckNo = txtCheckNo.Text.ToString();
            c.DesignatedFund = lsbDesignatedFund.Text;
            c.Note = rtbNote.Text;


            contributions.Add(c);

            WriteListToFile(c);
            BindingSource bindContribution = new BindingSource();
            bindContribution.DataSource = contributions;
            callingForm.bindingNavigatorContributions.BindingSource = bindContribution;
            callingForm.contributionDGV.DataSource = null;
            callingForm.contributionDGV.DataSource = bindContribution;

            callingForm.contributionDGV.AutoResizeColumns();
            callingForm.contributionDGV.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.AllCells;
            callingForm.contributionDGV.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.None;

            tssSubmitted.Visible = true;

            this.Close();
            callingForm.contributionDGV.Update();
            callingForm.contributionDGV.Refresh();
            
           
        }


        /// <summary>
        /// This updates the csv file based on user input
        /// </summary>
        private void WriteListToFile(Contribution c)
        {
            FileStream myFile = new FileStream("Sample Data2.csv", FileMode.Append, FileAccess.Write);

            StreamWriter writer = new StreamWriter(myFile);


            writer.WriteLine(c.ContributionNumber + "," + c.MemberID + "," + c.ContributionDate + ","
                + c.Amount + "," + c.Method + "," + c.DesignatedFund + "," + c.CheckNo + "," + c.Note);

            writer.Close();
            myFile.Close();

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DateTime dateValue = DateTime.Today;
            txtMemberID.Text = "";

            dtpContributionDate.Value = dateValue;
            txtAmount.Text = "";
            lsbMethod.ClearSelected();
            txtCheckNo.Text = "";
            lsbDesignatedFund.ClearSelected();
            rtbNote.Text = ""; 
        }

        private void AddNewContribution_Load(object sender, EventArgs e)
        {
            int newID;
            int totalRows;

            totalRows = Convert.ToInt32(callingForm.contributionDGV.Rows.Count - 1);

            newID = (1 + Convert.ToInt32(callingForm.contributionDGV.Rows[totalRows - 1].Cells[0].Value));
            lblContributionNo.Text = Convert.ToString(newID);

            DateTime dateValue = new DateTime(2014, 12, 18);
            txtMemberID.Text = "10001";
            dtpContributionDate.Value = dateValue;
            txtAmount.Text = "500";
            lsbMethod.SelectedItem = "Cash";
            txtCheckNo.Text = "13421";
            lsbDesignatedFund.SelectedItem = "Food Bank";
            rtbNote.Text = "In honor of Mary Gibbons."; 

        }






    }
}
