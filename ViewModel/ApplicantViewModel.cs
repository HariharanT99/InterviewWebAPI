using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ApplicantViewModel
    {

        public int ApplicantID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string LastEmployer { get; set; }
        public string MedicalStatus { get; set; }
        public int NoticePeriod { get; set; }
        public List<InterviewViewModel> Interview { get; set; }

    }
}
