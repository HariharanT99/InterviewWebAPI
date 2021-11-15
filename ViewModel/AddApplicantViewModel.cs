using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AddApplicantViewModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastEmployer { get; set; }
        public string LastDesignation { get; set; }
        public int AppliedFor { get; set; }
        public int ReferedBy { get; set; }
        public string MedicalStatus { get; set; }
        public int NoticePeriod { get; set; }
        public string Resume { get; set; }
    }
}
