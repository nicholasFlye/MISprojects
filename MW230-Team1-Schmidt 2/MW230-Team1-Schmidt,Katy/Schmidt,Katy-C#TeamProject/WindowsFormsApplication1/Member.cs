using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Member
    {
      
        //Fields
        private DateTime birthDate;
        private string ageClassification; 

        //auto-implemented properties 
        public int MemberID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Honorific { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; UpdateAgeGroup(); }

        }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MemberType { get; set; }
        public DateTime AttendanceBeginDate { get; set; }
        public DateTime AttendanceLastDate { get; set; }
        public DateTime MembershipDate { get; set; }
        public string MaritalStatus { get; set; }
        public string AgeClassification { get { return ageClassification; } }


        private void UpdateAgeGroup()
        {
            DateTime dateValue = DateTime.Now;
            DateTime dateValueBday = Convert.ToDateTime(BirthDate);
            TimeSpan span = dateValue.Subtract(dateValueBday);
            int numDays = span.Days;
            int years = numDays / 365;
            if (years >= 65)
            {
                ageClassification = "Seniors";

            }
            else if (years >= 25)
            {
                ageClassification = "Adults";

            }
            else if (years >= 18)
            {
                ageClassification = "Young Adults";


            }

            else if (years >= 15)
            {
                ageClassification = "Teenagers";

            }

            else if (years >= 12)
            {
                ageClassification = "Young Teens";


            }
            else if (years >= 6)
            {
                ageClassification = "Middle Childhood";

            }
            else if (years >= 3)
            {
                ageClassification = "Preschooler";


            }
            else if (years >= 1)
            {
                ageClassification = "Toddler";

            }
            else if (years >= 0)
            {
                ageClassification = "Infant";
            }
            else
            {

                ageClassification = "Unknown";
            }

        }
    }
}
