using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class DashboardApplicantViewModel
    {

        public DashboardApplicantViewModel()
        {
            this.InterviewerList = new List<string>();
        }
        public int ApplicantId { get; set; }

        public string ApplicantName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AppliedFor { get; set; }

        public int CurrentRound { get; set; }

        public DateTime? InterviewAt { get; set; }

        public string Status { get; set; }

#nullable enable
        public List<string>? InterviewerList { get; set; }
    }
}
