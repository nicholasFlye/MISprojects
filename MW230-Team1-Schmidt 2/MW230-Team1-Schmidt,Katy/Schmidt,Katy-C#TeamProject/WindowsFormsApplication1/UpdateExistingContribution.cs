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
    public partial class UpdateExistingContribution : Form
    {
        Form1 callingForm;

        public UpdateExistingContribution()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This calls the update existing contribution form.
        /// </summary>
        /// <param name="uec"></param>
        public UpdateExistingContribution(Form1 uec)
        {
            callingForm = uec;  
            InitializeComponent();
        }
        private void UpdateExistingContribution_Load(object sender, EventArgs e)
        {
            LoadExistingInfo(); 
        }
        /// <summary>
        /// This loads all the data for the selected row in the data grid
        /// </summary>
        private void LoadExistingInfo()
        {
            int selNum = callingForm.contributionDGV.CurrentCellAddress.Y;
            int contributionNumber;
            int memberID;
            DateTime contributionDate;
            double amount;
            string method;
            string checkNo;
            string designatedFund;
            string note;

            contributionNumber = Convert.ToInt32(callingForm.contributionDGV.Rows[selNum].Cells[0].Value);
            memberID = Convert.ToInt32(callingForm.contributionDGV.Rows[selNum].Cells[1].Value);
            contributionDate = Convert.ToDateTime(callingForm.contributionDGV.Rows[selNum].Cells[2].Value);
            amount = Convert.ToDouble(callingForm.contributionDGV.Rows[selNum].Cells[3].Value);
            method = Convert.ToString(callingForm.contributionDGV.Rows[selNum].Cells[4].Value).ToUpper();
            checkNo = Convert.ToString(callingForm.contributionDGV.Rows[selNum].Cells[5].Value);
            designatedFund = Convert.ToString(callingForm.contributionDGV.Rows[selNum].Cells[6].Value).ToUpper();
            note = Convert.ToString(callingForm.contributionDGV.Rows[selNum].Cells[7].Value);

            lblContributionNumber.Text = Convert.ToString(contributionNumber);
            txtMemberID.Text = Convert.ToString(memberID);
            dtpContributionDate.Value = contributionDate;
            txtAmount.Text = Convert.ToString(amount);
            lsbMethod.SelectedItem = method;
            txtCheckNo.Text = checkNo;
            lsbDesignatedFund.SelectedItem = designatedFund.ToUpper();
            txtNote.Text = note; 

        }

        /// <summary>
        /// This takes in a list and writes the information to a csv file.
        /// </summary>
        /// <param name="contributions"></param>
        private void WriteListToFile(List<Contribution> contributions)
        {
            //Declare FILESTREAM & STREAMWRITER
            FileStream myFile = new FileStream("Sample Data2.csv", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(myFile);

            //FOREACH: loop to write the entire list to Writer
            foreach (Contribution c in contributions)
            {
                writer.WriteLine(c.ContributionNumber + "," + c.MemberID + "," + c.ContributionDate + ","
                    + c.Amount + "," + c.Method + "," + c.DesignatedFund + "," + c.CheckNo + "," + c.Note);
            }

            //Close STREAMWRITER & FILESTREAM 
            writer.Close();
            myFile.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Contribution> contributions = callingForm.contributions;

            int selNum = callingForm.contributionDGV.CurrentCellAddress.Y;
            int contributionNumber;
            int memberID;
            DateTime contributionDate;
            double amount;
            string method;
            string checkNo;
            string designatedFund;
            string note;

            contributionNumber = Convert.ToInt32(lblContributionNumber.Text);
            memberID = int.Parse(txtMemberID.Text);
            contributionDate = dtpContributionDate.Value;
            amount = Convert.ToDouble(txtAmount.Text);
            method = Convert.ToString(lsbMethod.SelectedItem);
            checkNo = txtCheckNo.Text;
            designatedFund = Convert.ToString(lsbDesignatedFund.SelectedItem);
            note = txtNote.Text;

            for (int i = 0; i < contributions.Count; i++)
            {
                if (contributions[i].ContributionNumber == contributionNumber)
                {
                   contributions[i].MemberID = memberID;
                   contributions[i].ContributionDate = contributionDate;
                   contributions[i].Amount = Convert.ToDouble(amount);
                   contributions[i].Method = method;
                   contributions[i].CheckNo = checkNo;
                   contributions[i].DesignatedFund = designatedFund;
                   contributions[i].Note = note;

                }
            }

            callingForm.contributionDGV.DataSource = null;
            callingForm.contributionDGV.DataSource = contributions;
            tsslblSaveNotification.Visible = true;
            WriteListToFile(contributions);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dateValue = DateTime.Today;
            txtMemberID.Text = "";
            
            dtpContributionDate.Value = dateValue; 
            txtAmount.Text = "";
            lsbMethod.ClearSelected();
            txtCheckNo.Text = "";
            lsbDesignatedFund.ClearSelected();
            txtNote.Text = ""; 



        }





    }
}
