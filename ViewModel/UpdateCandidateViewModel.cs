namespace ViewModel
{
    public class UpdateCandidateViewModel
    {
        public int ApplicantId { get; set; }

        public int UserId { get; set; } //Modified by

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LastEmployer { get; set; }

        public string LastDesignation { get; set; }

        public int AppliedFor { get; set; }

        public int? ReferredBy { get; set; }

        public string MedicalStatus { get; set; }

        public int NoticePeriod { get; set; }
    }
}