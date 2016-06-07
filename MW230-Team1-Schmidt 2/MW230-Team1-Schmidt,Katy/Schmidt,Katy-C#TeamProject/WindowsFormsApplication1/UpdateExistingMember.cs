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
    public partial class UpdateExistingMember : Form
    {
        Form1 callingForm; 

        public UpdateExistingMember()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This calls the update existing member form 
        /// </summary>
        /// <param name="uem"></param>
        public UpdateExistingMember(Form1 uem)
        {
            callingForm = uem;  
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Member> members = callingForm.members;

            int selNum = callingForm.dgvMember.CurrentCellAddress.Y;
            string firstName;
            int memberID;
            string lastName;
            string address;
            string city;
            int zip;
            string email;
            string phone;
            string honorific;
            DateTime birthDate;
            DateTime abd;
            DateTime ald;
            DateTime membershipDate;
            string gender;
            string memberType;
            string maritalStatus;
            string state;


            memberID = Convert.ToInt32(lblMemberID.Text);
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            address = txtAddress.Text;
            city = txtCity.Text;
            zip = Convert.ToInt32(txtZip.Text);
            email = txtEmail.Text;
            phone = txtPhone.Text;
            honorific = Convert.ToString(lsbHonorific.SelectedItem);
            birthDate = dtpBirthDate.Value;
            abd = dtpABD.Value;
            ald = dtpALD.Value;
            membershipDate = dtpMembershipDate.Value;
            if (radFemale.Checked)
            {
                gender = "Female";

            }
            else
            {
                gender = "Male"; 
            }

            memberType = Convert.ToString(lsbMemberType.SelectedItem);
            maritalStatus = Convert.ToString(lsbMaritalStatus.SelectedItem);
            state = Convert.ToString(lsbState.SelectedItem); 
   

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].MemberID == memberID)
                {
                    members[i].MemberID = memberID;
                    members[i].FirstName = firstName;
                    members[i].LastName = lastName;
                    members[i].Address = address;
                    members[i].City = city;
                    members[i].Zip = zip;
                    members[i].Email = email;
                    members[i].Phone = phone;
                    members[i].Honorific = honorific;
                    members[i].BirthDate = birthDate;
                    members[i].AttendanceBeginDate = abd;
                    members[i].AttendanceLastDate = ald;
                    members[i].MembershipDate = membershipDate;
                    members[i].Gender = gender;
                    members[i].MemberType = memberType;
                    members[i].MaritalStatus = maritalStatus;
                    members[i].State = state; 

                }
            }

            callingForm.dgvMember.DataSource = null;
            callingForm.dgvMember.DataSource = members;
            tssSaved.Visible = true; 
            WriteListToFile(members);


        }

        private void UpdateExistingMember_Load(object sender, EventArgs e)
        {
            LoadExistingInfo();
        }

        /// <summary>
        /// This loads the data associated with the selected row in the data grid
        /// </summary>
        private void LoadExistingInfo()
        {

            int selNum = callingForm.dgvMember.CurrentCellAddress.Y;
            string firstName;
            int memberID;
            string lastName;
            string address;
            string city;
            int zip;
            string email;
            string phone;
            string honorific;
            DateTime birthDate;
            DateTime abd;
            DateTime ald;
            DateTime membershipDate;
            string gender;
            string memberType;
            string maritalStatus;
            string state;

            memberID = Convert.ToInt32(callingForm.dgvMember.Rows[selNum].Cells[0].Value);
            firstName = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[2].Value);
            lastName = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[1].Value);
            address = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[6].Value);
            city = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[7].Value);
            zip = Convert.ToInt32(callingForm.dgvMember.Rows[selNum].Cells[9].Value);
            email = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[11].Value);
            phone = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[10].Value);
            honorific = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[3].Value);
            birthDate = Convert.ToDateTime(callingForm.dgvMember.Rows[selNum].Cells[5].Value);
            abd = Convert.ToDateTime(callingForm.dgvMember.Rows[selNum].Cells[14].Value);
            ald = Convert.ToDateTime(callingForm.dgvMember.Rows[selNum].Cells[15].Value);
            membershipDate = Convert.ToDateTime(callingForm.dgvMember.Rows[selNum].Cells[13].Value);
            gender = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[4].Value);
            memberType = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[12].Value);
            maritalStatus = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[16].Value);
            state = Convert.ToString(callingForm.dgvMember.Rows[selNum].Cells[8].Value);


            if (gender.ToUpper() == "MALE")
            {
                radMale.Select();

            }
            else
            {
                radFemale.Select();

            }

            lsbState.SelectedItem = state;
            lsbMaritalStatus.SelectedItem = maritalStatus;
            lsbMemberType.SelectedItem = memberType;
            dtpABD.Value = abd;
            dtpALD.Value = ald;
            dtpMembershipDate.Value = membershipDate;
            dtpBirthDate.Value = birthDate;
            lblMemberID.Text = memberID.ToString();
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtAddress.Text = address;
            txtCity.Text = city;
            txtZip.Text = Convert.ToString(zip);
            txtEmail.Text = Convert.ToString(email);
            txtPhone.Text = Convert.ToString(phone);
            lsbHonorific.SelectedItem = honorific; 
            lblMemberHeader.Text = firstName + " " + lastName; 
        }
        /// <summary>
        /// This takes in a list and writes to the csv file
        /// </summary>
        /// <param name="members"></param>
        private void WriteListToFile(List<Member> members)
        {
            //Declare FILESTREAM & STREAMWRITER
            FileStream myFile = new FileStream("MemberList2.csv", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(myFile);

            //FOREACH: loop to write the entire list to Writer
            foreach (Member m in members)
            {
                writer.WriteLine(m.MemberID + "," + m.FirstName + "," + m.LastName + "," + m.Honorific + "," + m.Gender + "," + m.BirthDate + ","
                    + m.Address + "," + m.City + "," + m.State + "," + m.Zip + "," + m.Phone + "," + m.Email + "," + m.MemberType + "," +
                   m.MembershipDate + "," + m.AttendanceBeginDate + "," + m.AttendanceLastDate + "," + m.MaritalStatus);
            }

            //Close STREAMWRITER & FILESTREAM 
            writer.Close();
            myFile.Close();

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DateTime dateValue = DateTime.Today;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            lsbState.ClearSelected();
            txtZip.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            lsbHonorific.ClearSelected();
            radFemale.Checked = false;
            radMale.Checked = false;
            dtpBirthDate.Value = dateValue;
            lsbMaritalStatus.ClearSelected();
            lsbMemberType.ClearSelected();
            dtpMembershipDate.Value = dateValue;
            dtpABD.Value = dateValue;
            dtpALD.Value = dateValue; 

        }
    }
}
