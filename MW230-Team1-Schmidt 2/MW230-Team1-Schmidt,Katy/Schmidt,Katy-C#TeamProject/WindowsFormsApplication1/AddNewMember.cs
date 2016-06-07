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
    public partial class AddNewMember : Form
    {
        Form1 callingForm; 

        List<Member> members = new List<Member>();

        /// <summary>
        /// This allows this form and form1 to share information with each other
        /// </summary>
        /// <param name="anm"></param>
        public AddNewMember(Form1 anm)
        {
            callingForm = anm;  
            InitializeComponent();
        }
        public AddNewMember()
        {
            InitializeComponent();
            lbMemberState.SelectionMode = SelectionMode.One;
            lbMemberHonorific.SelectionMode = SelectionMode.One;
            lbMarital.SelectionMode = SelectionMode.One;
            lbMemberType.SelectionMode = SelectionMode.One;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Member m = new Member();
            m.MemberID = Convert.ToInt32(lblNewMemberID.Text);
            m.FirstName = txtFirstName.Text;
            m.LastName = txtMemberLastName.Text;
            m.Address = txtMemberAddress.Text;
            m.City = txtMemberCity.Text;
            m.State = lbMemberState.SelectedItem.ToString();
            m.Zip = Convert.ToInt32(txtZip.Text);
            m.Email = txtEmail.Text;
            m.Phone = txtPhone.Text;
            m.Honorific = lbMemberHonorific.SelectedItem.ToString();
            if (rbFemale.Checked)
            {
                m.Gender = "Female"; 
            }
            else
            {
                m.Gender = "Male";
            }
            m.BirthDate = Convert.ToDateTime(dtpMemberBday.Value);
            m.MaritalStatus = lbMarital.SelectedItem.ToString();
            m.MemberType = lbMemberType.SelectedItem.ToString();
            m.MembershipDate = Convert.ToDateTime(dtpMembershipDate.Value);
            m.AttendanceBeginDate = Convert.ToDateTime(dtpABD.Value);
            m.AttendanceLastDate = Convert.ToDateTime(dtpALD.Value);


            /*DisplayPlayerInReport(p);*/
            members.Add(m);

            WriteListToFile(m);
            BindingSource bindMember = new BindingSource();
            bindMember.DataSource = members;
            callingForm.bindingNavigatorMembers.BindingSource = bindMember;
            callingForm.dgvMember.DataSource = null;
            callingForm.dgvMember.DataSource = bindMember;

            callingForm.dgvMember.AutoResizeColumns();
            callingForm.dgvMember.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.AllCells;
            callingForm.dgvMember.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.None;

            tssSubmitted.Visible = true;

            this.Close();
            callingForm.dgvMember.Refresh();
        }

        /// <summary>
        /// This writes to the csv file based on user input
        /// </summary>
        private void WriteListToFile(Member m)
        {

            FileStream myFile = new FileStream("MemberList2.csv", FileMode.Append, FileAccess.Write);

            StreamWriter writer = new StreamWriter(myFile);

            writer.WriteLine(m.MemberID + "," + m.FirstName + "," + m.LastName + "," + m.Honorific  + "," + m.Gender + "," + m.BirthDate + ","
                + m.Address + "," + m.City + "," + m.State + "," + m.Zip + "," + m.Phone + "," + m.Email + "," + m.MemberType + ","  +
                m.MembershipDate + "," + m.AttendanceBeginDate + "," + m.AttendanceLastDate + "," + m.MaritalStatus); 

            writer.Close();
            myFile.Close();

        }

        private void btnMemberClearAll_Click(object sender, EventArgs e)
        {
            DateTime dateValue = DateTime.Today;
            txtFirstName.Text = "";
            txtMemberLastName.Text = "";
            txtMemberAddress.Text = "";
            txtMemberCity.Text = "";
            lbMemberState.ClearSelected();
            lbMarital.ClearSelected();
            lbMemberType.ClearSelected();
            lbMemberHonorific.ClearSelected(); 
            txtZip.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            rbMale.Checked = false;
            rbFemale.Checked = false;
            dtpMembershipDate.Value = dateValue;
            dtpMemberBday.Value = dateValue; 
            dtpABD.Value = dateValue;
            dtpALD.Value = dateValue; 
        }

        private void AddNewMember_Load(object sender, EventArgs e)
        {
            int newID; 
            int totalRows; 
           
            totalRows = Convert.ToInt32(callingForm.dgvMember.Rows.Count - 1);

            newID = (1 + Convert.ToInt32(callingForm.dgvMember.Rows[totalRows - 1].Cells[0].Value));
            lblNewMemberID.Text = Convert.ToString(newID);

            //preload
            DateTime membershipDate = new DateTime(2014, 3, 13);
            DateTime birthDate = new DateTime(1992, 12, 16);
            DateTime abd = new DateTime(2013, 7, 30);
            DateTime ald = new DateTime(2016, 1, 12); 

            txtFirstName.Text = "Casey";
            txtMemberLastName.Text = "Cook";
            txtMemberAddress.Text = "301 5th Street";
            txtMemberCity.Text = "Waco";
            lbMemberState.SelectedItem = "TX";
            lbMarital.SelectedItem = "Married";
            lbMemberType.SelectedItem = "Member";
            lbMemberHonorific.SelectedItem = "Mrs.";
            txtZip.Text = "78921";
            txtEmail.Text = "casey_cook@aol.com";
            txtPhone.Text = "8172839281";
            rbMale.Checked = false;
            rbFemale.Checked = true;
            dtpMembershipDate.Value = membershipDate;
            dtpMemberBday.Value = birthDate;
            dtpABD.Value = abd;
            dtpALD.Value = ald; 



        }

    }
}
