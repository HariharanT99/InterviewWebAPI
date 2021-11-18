using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Model
{
    [Table("Interview")]
    public partial class Interview
    {
        public Interview()
        {
            InterviewerReviews = new HashSet<InterviewerReview>();
        }

        [Key]
        [Column("InterviewID")]
        public int InterviewId { get; set; }
        [Column("ApplicantID")]
        public int ApplicantId { get; set; }
        [Column("InterviewRoundID")]
        public byte InterviewRoundId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InterviewAt { get; set; }
        public byte Result { get; set; }

        [ForeignKey(nameof(ApplicantId))]
        [InverseProperty("Interviews")]
        public virtual Applicant Applicant { get; set; }
        [ForeignKey(nameof(InterviewRoundId))]
        [InverseProperty("Interviews")]
        public virtual InterviewRound InterviewRound { get; set; }
        [ForeignKey(nameof(Result))]
        [InverseProperty(nameof(Status.Interviews))]
        public virtual Status ResultNavigation { get; set; }
        [InverseProperty(nameof(InterviewerReview.Interview))]
        public virtual ICollection<InterviewerReview> InterviewerReviews { get; set; }
    }
}
