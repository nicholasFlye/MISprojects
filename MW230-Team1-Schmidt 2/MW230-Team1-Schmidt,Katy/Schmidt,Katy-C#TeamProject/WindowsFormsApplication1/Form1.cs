//Software Name: Hope Inc., Church Software Management System
//Description: This application will allow churches to maintain member and contribution data. Church staff 
//will be able to view statistics along with necessary tax information for deductions. 
//Developers: Schmidt, Katy (Project Leader); Fabac, Collin; Zheng, Grace; Briggs, Bryan; Flye, Nicholas 
//Semester: Spring 2016
//Last Updated: April 24, 2016
//Additional Functionality: The tax form on form1 - tab4. This will allow the church to see what amount certain members can deduct for
//tax purchases. 


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
using System.Windows.Forms.DataVisualization.Charting; 
using System.Net.Mail; 
using System.Net; 
using System.Net.Security;
using System.Security.Cryptography.X509Certificates; 




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Declare lists
        public List<Contribution> contributions = new List<Contribution>();
        public List<Member> members = new List<Member>();
        public List<Member> loadedMembers = new List<Member>();
        public List<Contribution> loadedContributions = new List<Contribution>(); 

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This gets the information from a csv files and loads it into a list
        /// </summary>
        private void LoadContributionsFromFile()
        {
            
            FileStream myFile = new FileStream("Sample Data2.csv", FileMode.OpenOrCreate, FileAccess.Read);

            StreamReader reader = new StreamReader(myFile);

            string[] contributionRec = new string[8];

            string inputStr = reader.ReadLine();

            while (inputStr != null)
            {
                contributionRec = inputStr.Split(','); 

                if (contributionRec[0] != "") 
                {
                    Contribution c = new Contribution();
                    c.ContributionNumber = Convert.ToInt32(contributionRec[0]);
                    c.MemberID = Convert.ToInt32(contributionRec[1]);
                    c.ContributionDate = Convert.ToDateTime(contributionRec[2]);
                    c.Amount = Convert.ToDouble(contributionRec[3]);
                    c.Method = contributionRec[4];
                    c.CheckNo = contributionRec[6];
                    c.DesignatedFund = contributionRec[5];
                   
                    c.Note = contributionRec[7];

                    

                    contributions.Add(c);
                }


                inputStr = reader.ReadLine();
            }

            LoadContributionListToGrid(contributions);

            reader.Close();
            myFile.Close();
        }

        /// <summary>
        /// This takes a list and loads the data into the data grid
        /// </summary>
        /// <param name="anyContributionList"></param>
        private void LoadContributionListToGrid(List<Contribution> anyContributionList)
        {

            BindingSource bindContribution = new BindingSource();
            bindContribution.DataSource = anyContributionList;
            bindingNavigatorContributions.BindingSource = bindContribution;
            contributionDGV.DataSource = null;
            contributionDGV.DataSource = bindContribution;

            contributionDGV.AutoResizeColumns();
            contributionDGV.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.AllCells;
            contributionDGV.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.None;
            loadedContributions = anyContributionList;

        }

        /// <summary>
        /// This takes information from the csv file and puts it into a list
        /// </summary>
        private void LoadMembersFromFile()
        {

            FileStream memberFile = new FileStream("MemberList2.csv", FileMode.OpenOrCreate, FileAccess.Read);

            StreamReader reader = new StreamReader(memberFile);

            string[] memberRec = new string[17];

            string inputStr = reader.ReadLine();

            while (inputStr != null)
            {
                memberRec = inputStr.Split(','); 

                if (memberRec[0] != "") 
                {
                    Member m = new Member();
                    m.MemberID = Convert.ToInt32(memberRec[0]);
                    m.FirstName = memberRec[1];
                    m.LastName = memberRec[2];
                    m.Honorific = memberRec[3];
                    m.Gender = memberRec[4];
                    m.BirthDate = DateTime.Parse(memberRec[5]);
                    m.Address = memberRec[6];
                    m.City = memberRec[7];
                    m.State = memberRec[8];
                    m.Zip = Convert.ToInt32(memberRec[9]);
                    m.Phone = memberRec[10];
                    m.Email = memberRec[11];
                    m.MemberType = memberRec[12];
                    m.MembershipDate = DateTime.Parse(memberRec[13]);
                    m.AttendanceBeginDate = Convert.ToDateTime(DateTime.Parse(memberRec[14]));
                    m.AttendanceLastDate = DateTime.Parse(memberRec[15]);
                    m.MaritalStatus = memberRec[16]; 

                    

                    members.Add(m);
                }


                inputStr = reader.ReadLine();
            }

            LoadMemberListToGrid(members);


            reader.Close();
            memberFile.Close();
       

        }

        /// <summary>
        /// This takes a list and loads it into the member data grid
        /// </summary>
        /// <param name="anyMemberList"></param>
        private void LoadMemberListToGrid(List<Member> anyMemberList)
        {

            BindingSource bindMember = new BindingSource();
            bindMember.DataSource = anyMemberList;
            bindingNavigatorMembers.BindingSource = bindMember;
            dgvMember.DataSource = null;
            dgvMember.DataSource = bindMember;

            dgvMember.AutoResizeColumns();
            dgvMember.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMember.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.None;
            loadedMembers = anyMemberList;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMemberIDTaxForm.Text = "10002"; 
            Login login = new Login();
            login.ShowDialog(); 
            LoadContributionsFromFile();
            LoadMembersFromFile();
            TotalPopulation();
            ContributeOften();
            statusNumbers();
            GoalFunds();
            WaysToTithe();
            MaleAndFemale();
            MaritalStatus();
            ContributionsByAgeGroup();
            TotalFundsGraph();
        }

        private void updateContributionButton_Click(object sender, EventArgs e)
        {
            UpdateExistingContribution uec = new UpdateExistingContribution(this);
            uec.ShowDialog(); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddNewContribution anc = new AddNewContribution(this);
            anc.ShowDialog(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewMember anm = new AddNewMember(this);
            anm.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selNum = dgvMember.CurrentCellAddress.Y;
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete this member?", "Delete Member", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dgvMember.Rows.RemoveAt(selNum);

                FileStream myFile = new FileStream("MemberList2.csv", FileMode.Create, FileAccess.Write);

                StreamWriter writer = new StreamWriter(myFile);

                foreach (Member m in members)
                {
                    writer.WriteLine(m.MemberID + "," + m.FirstName + "," + m.LastName + "," + m.Honorific + "," + m.Gender + "," + m.BirthDate + ","
                        + m.Address + "," + m.City + "," + m.State + "," + m.Zip + "," + m.Phone + "," + m.Email + "," + m.MemberType + "," +
                       m.MembershipDate + "," + m.AttendanceBeginDate + "," + m.AttendanceLastDate + "," + m.MaritalStatus);
                }

                writer.Close();
                myFile.Close();
            }
            
        }

        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            UpdateExistingMember uem = new UpdateExistingMember(this); 
            uem.ShowDialog();
        }

        /// <summary>
        /// This loads the tax form data grid
        /// </summary>
        private void loadTaxForm()
        {
            int memberTaxForm = Convert.ToInt32(txtMemberIDTaxForm.Text);
            int totalRows = contributionDGV.Rows.Count - 1;
            int totalRowsMember = dgvMember.Rows.Count - 1;
            double totalAmount  = 0; 
            for (int i = 0; i < totalRowsMember; i++)
            {
                int rowMemberIDList = Convert.ToInt32(dgvMember.Rows[i].Cells[0].Value);
                if (rowMemberIDList == memberTaxForm)
                {
                    lblMemberName.Text += Convert.ToString(dgvMember.Rows[i].Cells[2].Value);
                    lblMemberName.Text += " ";
                    lblMemberName.Text += Convert.ToString(dgvMember.Rows[i].Cells[1].Value); 
                }


            }

            for (int i = 0; i < totalRows; i++)
            {
                int rowMemberID = Convert.ToInt32(contributionDGV.Rows[i].Cells[1].Value);

                if (rowMemberID == memberTaxForm)
                {
                    
                    DateTime taxDate = Convert.ToDateTime(contributionDGV.Rows[i].Cells[2].Value);
                    string taxMethod = Convert.ToString(contributionDGV.Rows[i].Cells[4].Value);
                    string taxNote = Convert.ToString(contributionDGV.Rows[i].Cells[7].Value);
                    string taxDesignatedFund = Convert.ToString(contributionDGV.Rows[i].Cells[6].Value);
                    double taxAmount = Convert.ToDouble(contributionDGV.Rows[i].Cells[3].Value);
                    int recNum = dgvTaxForm.Rows.Add();
                    dgvTaxForm.Rows[recNum].Cells[0].Value = taxDate;
                    dgvTaxForm.Rows[recNum].Cells[1].Value = taxMethod;
                    dgvTaxForm.Rows[recNum].Cells[2].Value = taxNote;
                    dgvTaxForm.Rows[recNum].Cells[3].Value = taxDesignatedFund;
                    dgvTaxForm.Rows[recNum].Cells[4].Value = taxAmount;
                    lblAllContributions.Text += String.Format("{0} \n", taxDesignatedFund.ToUpper()); 
                    lblAllAmounts.Text += String.Format("{0, -10}\n", taxAmount.ToString("C")); 
                    totalAmount += taxAmount; 
                    
                }
                



            }


            lblTotalContributions.Text = totalAmount.ToString("C"); 

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            loadTaxForm(); 
        }

        /// <summary>
        /// Gets total population
        /// </summary>
        private void TotalPopulation()
        {
            int totalPop;
            totalPop = dgvMember.Rows.Count;
            lblTotalPop.Text = Convert.ToString(totalPop);
        }

        /// <summary>
        /// This shows how often members contribute
        /// </summary>
        private void ContributeOften()
        {
            double amountPerYear;
            double totalAmount = 0;
            int totalRows = contributionDGV.Rows.Count - 1;
            for (int i = 0; i < totalRows; i++)
            {

                double amount = Convert.ToDouble(contributionDGV.Rows[i].Cells[3].Value);

                totalAmount += amount;
            }
            String totalAmountDisplay = Convert.ToString(totalAmount);

            lblTotContributions.Text = totalAmount.ToString("C");
            amountPerYear = totalAmount / 52;
            lblYearContributions.Text = amountPerYear.ToString("C");
        }

        /// <summary>
        /// Shows the number of each status category
        /// </summary>
        private void statusNumbers()
        {
            int totalRows = dgvMember.Rows.Count - 1;
            int attenderNumber = 0;
            int dependentNumber = 0;
            int visitorNumber = 0;
            int archivedNumber = 0;
            int memberNumber = 0;
            int ministerNumber = 0;
            int staffNumber = 0;
            int contactNumber = 0;




            for (int i = 0; i < totalRows; i++)
            {
                string status = Convert.ToString(dgvMember.Rows[i].Cells[12].Value);

                if (status == "Attender")
                {
                    attenderNumber++;
                }
                else if (status == "Dependent")
                {
                    dependentNumber++;

                }
                else if (status == "Visitor")
                {

                    visitorNumber++;

                }
                else if (status == "Archived")
                {
                    archivedNumber++;


                }
                else if (status == "Member")
                {
                    memberNumber++;


                }
                else if (status == "Minister")
                {
                    ministerNumber++;

                }
                else if (status == "Staff")
                {
                    staffNumber++;

                }
                else
                {
                    contactNumber++;


                }

                lblArchived.Text = Convert.ToString(archivedNumber);
                lblAttender.Text = Convert.ToString(attenderNumber);
                lblContact.Text = Convert.ToString(contactNumber);
                lblDependent.Text = Convert.ToString(dependentNumber);
                lblMember.Text = Convert.ToString(memberNumber);
                lblMinister.Text = Convert.ToString(ministerNumber);
                lblStaff.Text = Convert.ToString(staffNumber);
                lblVisitor.Text = Convert.ToString(visitorNumber);

            }
        }

        /// <summary>
        /// This shows the church's goal for raising funds and how far they have gotten
        /// </summary>
        private void GoalFunds()
        {
            const double TOTAL_HEIGHT = 337;
            picIndicatorFunds.Location = new Point(58, 370);
            double totalAmount = 0;
            int totalRows = contributionDGV.Rows.Count - 1;
            for (int i = 0; i < totalRows; i++)
            {

                double amount = Convert.ToDouble(contributionDGV.Rows[i].Cells[3].Value);

                totalAmount += amount;
            }
            const double HEIGHT = 30000000;
            double movement = TOTAL_HEIGHT * totalAmount / HEIGHT;
            int anIntX = picIndicatorFunds.Location.X;
            int anIntY = picIndicatorFunds.Location.Y;
            anIntY -= Convert.ToInt32(movement);
            picIndicatorFunds.Location = new Point(anIntX, anIntY);
        }

        /// <summary>
        /// This shows statistics related to how people tithe
        /// </summary>
        private void WaysToTithe()
        {
            string[] products = new string[] { "Cash", "Check", "Card" };
            int totalRows = contributionDGV.Rows.Count - 1;
            int cashCount = 0;
            int checkCount = 0;
            int cardCount = 0;
            for (int i = 0; i < totalRows; i++)
            {

                String tithe = Convert.ToString(contributionDGV.Rows[i].Cells[4].Value);
                if (tithe == "cash")
                    cashCount++;
                else if (tithe == "check")
                    checkCount++;
                else if (tithe == "card")
                    cardCount++;

            }
            int[] QOHs = new int[] { cashCount, checkCount, cardCount };

            chartTithe.Series.Clear();
            chartTithe.Series.Add("Values");

            chartTithe.Series["Values"].ChartType = SeriesChartType.Pie;

            for (int i = 0; i < products.Count(); i++)
            {
                chartTithe.Series["Values"].Points.AddXY(products[i], QOHs[i]);
            }

            chartTithe.Series["Values"].IsVisibleInLegend = false;   
            chartTithe.Series["Values"].Label = "#VALX\n#PERCENT{P1}"; 
            chartTithe.Series["Values"].LabelForeColor = System.Drawing.Color.Black; 
            chartTithe.Series["Values"]["PieLabelStyle"] = "Outside"; 
            chartTithe.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        /// <summary>
        /// This shows the percentage of males and females in the church. 
        /// </summary>
        private void MaleAndFemale()
        {
            string[] products = new string[] { "Male", "Female" };
            int totalRows = dgvMember.Rows.Count - 1;
            int maleCount = 0;
            int femaleCount = 0;
            for (int i = 0; i < totalRows; i++)
            {

                String gender = Convert.ToString(dgvMember.Rows[i].Cells[4].Value);
                if (gender == "Male")
                    maleCount++;
                else if (gender == "Female")
                    femaleCount++;

            }
            int[] QOHs = new int[] { maleCount, femaleCount };

            chartGender.Series.Clear();
            chartGender.Series.Add("Values");

            chartGender.Series["Values"].ChartType = SeriesChartType.Pie;

            for (int i = 0; i < products.Count(); i++)
            {
                chartGender.Series["Values"].Points.AddXY(products[i], QOHs[i]);
            }

            chartGender.Series["Values"].IsVisibleInLegend = false;  
            chartGender.Series["Values"].Label = "#VALX\n#PERCENT{P1}"; 
            chartGender.Series["Values"].LabelForeColor = System.Drawing.Color.Black; 
            chartGender.Series["Values"]["PieLabelStyle"] = "Outside"; 
            chartGender.ChartAreas[0].Area3DStyle.Enable3D = true; 
        }

        /// <summary>
        /// This shows statistics related to the marital status of our population
        /// </summary>
        private void MaritalStatus()
        {
            string[] products = new string[] { "Divorced", "Married", "Not applicable", "Separated", "Single", "Unknown", "Widowed" };
            int totalRows = dgvMember.Rows.Count - 1;
            int divorcedCount = 0;
            int marriedCount = 0;
            int notapplicableCount = 0;
            int separatedCount = 0;
            int singleCount = 0;
            int unknownCount = 0;
            int widowedCount = 0;

            for (int i = 0; i < totalRows; i++)
            {

                String maritalStatus = Convert.ToString(dgvMember.Rows[i].Cells[16].Value);
                if (maritalStatus == "Divorced")
                    divorcedCount++;
                else if (maritalStatus == "Married")
                    marriedCount++;
                else if (maritalStatus == "Not Applicable")
                    notapplicableCount++;
                else if (maritalStatus == "Separated")
                    separatedCount++;
                else if (maritalStatus == "Single")
                    singleCount++;
                else if (maritalStatus == "Unknown")
                    unknownCount++;
                else if (maritalStatus == "Widowed")
                    widowedCount++;

            }
            int[] QOHs = new int[] { divorcedCount, marriedCount, notapplicableCount, separatedCount, singleCount, unknownCount, widowedCount };

            chartMaritalStatus.Series.Clear();
            chartMaritalStatus.Series.Add("Values");

            chartMaritalStatus.Series["Values"].ChartType = SeriesChartType.Pie;

            for (int i = 0; i < products.Count(); i++)
            {
                chartMaritalStatus.Series["Values"].Points.AddXY(products[i], QOHs[i]);
            }

            chartMaritalStatus.Series["Values"].IsVisibleInLegend = false;   
            chartMaritalStatus.Series["Values"].Label = "#VALX\n#PERCENT{P1}"; 
            chartMaritalStatus.Series["Values"].LabelForeColor = System.Drawing.Color.Black; 
            chartMaritalStatus.Series["Values"]["PieLabelStyle"] = "Outside"; 
            chartMaritalStatus.ChartAreas[0].Area3DStyle.Enable3D = true; 
        }

        /// <summary>
        /// This shows how much each age group contributes
        /// </summary>
        private void ContributionsByAgeGroup()
        {
            string[] ageGroups = new string[] { "Infant", "Toddler", "Preschooler", "Middle childhood", "Young teens", "Teenagers", "Young Adults", "Adults", "Seniors" };
            int totalMemberRows = dgvMember.Rows.Count - 1;
            double infantContribution = 0;
            double toddlerContribution = 0;
            double preschoolerContribution = 0;
            double middleChildhoodContribution = 0;
            double youngTeensContribution = 0;
            double teenagersContribution = 0;
            double youngAdultContribution = 0;
            double adultContribution = 0;
            double seniorContribution = 0;

            int infantCount = 0;
            int toddlerCount = 0;
            int preschoolerCount = 0;
            int middleChildhoodCount = 0;
            int youngTeensCount = 0;
            int teenagersCount = 0;
            int youngAdultCount = 0;
            int adultCount = 0;
            int seniorCount = 0;

            for (int i = 0; i < totalMemberRows; i++)
            {

                int birthYear = Convert.ToDateTime(dgvMember.Rows[i].Cells[5].Value).Year;

                int age = DateTime.Now.Year - birthYear;
                int memberId = Convert.ToInt32(dgvMember.Rows[i].Cells[0].Value);

                if (age < 1)
                {
                    infantCount++;
                }
                else if (age < 3 && age > 1)
                {
                    toddlerCount++;
                }
                else if (age < 6 && age > 3)
                {
                    preschoolerCount++;
                }
                else if (age < 12 && age > 6)
                {
                    middleChildhoodCount++;
                }
                else if (age < 15 && age > 12)
                {
                    youngTeensCount++;
                }
                else if (age < 18 && age > 15)
                {
                    teenagersCount++;
                }
                else if (age < 25 && age > 18)
                {
                    youngAdultCount++;
                }
                else if (age < 65 && age > 25)
                {
                    adultCount++;
                }
                else if (age > 65)
                {
                    seniorCount++;
                }

                for (int j = 0; j < contributionDGV.Rows.Count - 1; j++)
                {

                    if (age < 1 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        infantContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                    else if (age < 3 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        toddlerContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                    else if (age < 6 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        preschoolerContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                    else if (age < 12 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        middleChildhoodContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                    else if (age < 15 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        youngTeensContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                    else if (age < 18 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        teenagersContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                    else if (age < 25 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        youngAdultContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                    else if (age < 65 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        adultContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                    else if (age > 65 && memberId == Convert.ToInt32(contributionDGV.Rows[j].Cells[1].Value))
                    {
                        seniorContribution += Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value);
                    }
                }


            }

            lblInfant.Text = infantCount.ToString();
            lblToddler.Text = toddlerCount.ToString();
            lblPreschooler.Text = preschoolerCount.ToString();
            lblMiddleChildhood.Text = middleChildhoodCount.ToString();
            lblYoungTeens.Text = youngTeensCount.ToString();
            lblTeenagers.Text = teenagersCount.ToString();
            lblYoungAdults.Text = youngAdultCount.ToString();
            lblAdults.Text = adultCount.ToString();
            lblSeniors.Text = seniorCount.ToString();

            double[] QOHs = new double[] { 
                infantContribution, toddlerContribution, preschoolerContribution, 
                middleChildhoodContribution, youngTeensContribution, teenagersContribution,
                youngAdultContribution, adultContribution, seniorContribution };

            chartContributionsPerAgeGroup.Series.Clear();
            chartContributionsPerAgeGroup.Series.Add("Values");

            chartContributionsPerAgeGroup.Series["Values"].ChartType = SeriesChartType.Pie;

            for (int i = 0; i < ageGroups.Count(); i++)
            {
                chartContributionsPerAgeGroup.Series["Values"].Points.AddXY(ageGroups[i], QOHs[i]);
            }

            chartContributionsPerAgeGroup.Series["Values"].IsVisibleInLegend = false;   
            chartContributionsPerAgeGroup.Series["Values"].Label = "#VALX\n#PERCENT{P1}"; 
            chartContributionsPerAgeGroup.Series["Values"].LabelForeColor = System.Drawing.Color.Black; 
            chartContributionsPerAgeGroup.Series["Values"]["PieLabelStyle"] = "Outside"; 
            chartContributionsPerAgeGroup.ChartAreas[0].Area3DStyle.Enable3D = true; 
        }

        /// <summary>
        /// This shows a line graph of the total contributions the last sixteen years
        /// </summary>
        private void TotalFundsGraph()
        {
            int[] sales = new int[] { 3000, 12000, 6500, 9000, 7000, 5500 };

            chartTotalFunds.Visible = true;
            chartTotalFunds.Series.Clear();
            chartTotalFunds.Series.Add("Contributons");
            chartTotalFunds.Series["Contributons"].ChartType = SeriesChartType.Line;
            chartTotalFunds.Series["Contributons"].Color = System.Drawing.Color.Red;

            int[] years = new int[contributionDGV.Rows.Count];
            for (int j = 0; j < contributionDGV.Rows.Count - 1; j++)
            {
                years[j] = Convert.ToDateTime(contributionDGV.Rows[j].Cells[2].Value).Year;
            }
            Array.Sort(years);
            int startindex = 0;
            for (int x = 0; x < years.Length; x++)
            {
                if (years[x] == 2000)
                {
                    startindex = x;
                    break;
                }

            }
            for (int j = startindex; j < years.Length - 1; j++)
            {
                chartTotalFunds.Series["Contributons"].Points.AddXY(years[j], Convert.ToDouble(contributionDGV.Rows[j].Cells[3].Value));
            }
            chartTotalFunds.ChartAreas[0].AxisX.Maximum = 2016;
            chartTotalFunds.ChartAreas[0].AxisX.Minimum = 2000;
            chartTotalFunds.ChartAreas[0].AxisY.Maximum = 100000;
            chartTotalFunds.ChartAreas[0].AxisY.Minimum = 0;
        }

        private void btnDeleteExistingContribution_Click(object sender, EventArgs e)
        {
            int selNum = contributionDGV.CurrentCellAddress.Y;
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to delete this contribution?", "Delete Contribution", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                contributionDGV.Rows.RemoveAt(selNum);

                FileStream myFile = new FileStream("Sample Data2.csv", FileMode.Create, FileAccess.Write);

                StreamWriter writer = new StreamWriter(myFile);

                foreach (Contribution c in contributions)
                {
                    writer.WriteLine(c.ContributionNumber + "," + c.MemberID + "," + c.ContributionDate + ","
                        + c.Amount + "," + c.Method + "," + c.DesignatedFund + "," + c.CheckNo + "," + c.Note);
                }

                writer.Close();
                myFile.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var filteredMembers =
                from m in members
                select m;

            if (txtFilterLastName.Text != "")
            {
                filteredMembers = filteredMembers.Where(m => m.LastName.ToUpper() == txtFilterLastName.Text.ToUpper());
            }

            if (cboMemberType.Text != "")
            {
                filteredMembers = filteredMembers.Where(m => m.MemberType == cboMemberType.SelectedItem.ToString());
            }

            if (cboMaritalStatus.Text != "")
            {
                filteredMembers = filteredMembers.Where(m => m.MaritalStatus == cboMaritalStatus.SelectedItem.ToString());
            }

            if (cboAgeClassification.Text != "")
            {
                filteredMembers = filteredMembers.Where(m => m.AgeClassification == cboAgeClassification.SelectedItem.ToString()); 

            }

            LoadMemberListToGrid(filteredMembers.ToList());
 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var filteredContributions =
                from c in contributions
                select c;

            if (txtFilterLastCont.Text != "")
            {
                filteredContributions = filteredContributions.Where(c => c.ContributionNumber == Convert.ToInt32(txtFilterLastCont.Text));
            }

            if (txtFilterMemberID.Text != "")
            {
                filteredContributions = filteredContributions.Where(c => c.MemberID == Convert.ToInt32(txtFilterMemberID.Text));
            }

            if (cboFund.Text != "")
            {
                filteredContributions = filteredContributions.Where(c => c.DesignatedFund.ToUpper() == cboFund.SelectedItem.ToString().ToUpper());
            }

            
            if (dtpContributionDateFilter.Value != DateTime.Today)
                {
                    filteredContributions = filteredContributions.Where(c => c.ContributionDate == dtpContributionDateFilter.Value);
                }
            

            LoadContributionListToGrid(filteredContributions.ToList());
        }

        private void btnSortContributionNo_Click(object sender, EventArgs e)
        {
            var filteredContributions =
                from c in contributions
                orderby c.ContributionNumber
                select c;

            LoadContributionListToGrid(filteredContributions.ToList()); 

        }

        private void btnSortMemberID_Click(object sender, EventArgs e)
        {
            var filteredContributions =
                from c in contributions
                orderby c.MemberID
                select c;

            LoadContributionListToGrid(filteredContributions.ToList()); 
        }

        private void btnSortFund_Click(object sender, EventArgs e)
        {
            var filteredContributions =
                from c in contributions
                orderby c.DesignatedFund
                select c;

            LoadContributionListToGrid(filteredContributions.ToList()); 
        }

        private void btnSortDate_Click(object sender, EventArgs e)
        {
            var filteredContributions =
                from c in contributions
                orderby c.ContributionDate
                select c;

            LoadContributionListToGrid(filteredContributions.ToList()); 
        }

        private void btnSortLastName_Click(object sender, EventArgs e)
        {
            var filteredMembers =
                from m in members
                orderby m.LastName
                select m;

            LoadMemberListToGrid(filteredMembers.ToList()); 
        }

        private void btnSortMaritalStatus_Click(object sender, EventArgs e)
        {
            var filteredMembers =
                from m in members
                orderby m.MaritalStatus
                select m;

            LoadMemberListToGrid(filteredMembers.ToList()); 
        }

        private void btnSortMemberType_Click(object sender, EventArgs e)
        {
            var filteredMembers =
                from m in members
                orderby m.MemberType
                select m;

            LoadMemberListToGrid(filteredMembers.ToList()); 
        }

        private void btnSortAgeClassification_Click(object sender, EventArgs e)
        {
            var filteredMembers =
                from m in members
                orderby m.AgeClassification
                select m;

            LoadMemberListToGrid(filteredMembers.ToList()); 
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            dgvMember.DataSource = null;
            members.Clear();
            LoadMembersFromFile();
            txtFilterLastName.Text = "";
            cboAgeClassification.Text = "";
            cboMaritalStatus.Text = "";
            cboMemberType.Text = ""; 
        }

        private void btnClearFilterCon_Click(object sender, EventArgs e)
        {
            contributionDGV.DataSource = null;
            contributions.Clear();
            LoadContributionsFromFile(); 
            txtFilterLastCont.Text = "";
            cboFund.Text = "";
            dtpContributionDateFilter.Value = DateTime.Today;
            txtFilterMemberID.Text = ""; 
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void GenerateEmail()
        {
            string test = lblTotalContributions.Text;

            string myServer = "bu-mail.baylor.edu";   	//Öor your ISP provider's SMTP server
            string myUserid = "Bryan_Briggs";    	//your email acct userid
            string myPsw = "8a53Ba1!";	//your email acct password
            string myFromAddress = "Bryan_Briggs@baylor.edu";	//your email address
            string myToAddress = "Katelyn_Schmidt@baylor.edu"; 	//the receiver's email address
            string mySubject = "Your Tax deduction is here!";
            string myMessage = "<h3>" + "Your tax deduction = " + test + "</h3>";




            lblMsgBox.Text += "==> Email generation started..." + Environment.NewLine;

            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredential = new NetworkCredential(myUserid, myPsw);
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(myFromAddress);

            smtpClient.Host = myServer;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            bool isEmailSecure = true;

            if (isEmailSecure)
            {
                smtpClient.EnableSsl = true;
            }

            message.From = fromAddress;
            message.Subject = mySubject;
            message.IsBodyHtml = true;
            message.Body = myMessage;
            message.To.Add(myToAddress);

            try
            {
                if (isEmailSecure)
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                        delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                }
                smtpClient.Send(message);
                lblMsgBox.Text += Environment.NewLine + "==> Email successfuly sent!";
            }
            catch (Exception ex)
            {
                lblMsgBox.Text = ex.Message;
                lblMsgBox.Text += Environment.NewLine + "==> Email error!";
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            GenerateEmail(); 
        }

 


    }
}
