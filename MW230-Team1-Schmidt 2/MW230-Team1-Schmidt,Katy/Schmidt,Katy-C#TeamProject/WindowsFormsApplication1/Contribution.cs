using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Contribution
    {

        //properties
        //auto-implemented properties 
        public int ContributionNumber { get; set; }
        public int MemberID { get; set; }
        public DateTime ContributionDate { get; set; }
        public double Amount { get; set; }
        public string Method { get; set; }
        public String CheckNo { get; set; }
        public string DesignatedFund { get; set; }
        public string Note { get; set; }



    }
}
