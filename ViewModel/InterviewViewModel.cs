using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class InterviewViewModel
    {
        public int InterviewID { get; set; }
        
        public int InterviewRoundID { get; set; }
        
        public string Status { get; set; }
        
        public string InterviewRoundName { get; set; }
        
        public List<InterviewerReviewViewModel> InterviewerReview { get; set; }
    }
}
