using System.Collections.Generic;

namespace ViewModel
{
    public class InterviewerReviewViewModel
    {
        public int InterviewerReviewId { get; set; }
        public int InterviewerID { get; set; }
        public string InterviewerName { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public string Comments { get; set; }
        public string Result { get; set; }
        public List<SkillRatingViewModel> SkillRating { get; set; }

    }
}