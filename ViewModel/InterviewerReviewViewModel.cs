using System.Collections.Generic;

namespace ViewModel
{
    public class InterviewerReviewViewModel
    {
        public int InterviewerReviewId { get; set; }

        public int InterviewerID { get; set; }

        public string InterviewerName { get; set; }

#nullable enable
        public string? Pros { get; set; }

        public string? Cons { get; set; }

        public string? Comments { get; set; }
#nullable disable

        public string Result { get; set; }

        public List<SkillRatingViewModel> SkillRating { get; set; }

    }
}