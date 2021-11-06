using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    [Table("InterviewerReview")]
    public partial class InterviewerReview
    {
        public InterviewerReview()
        {
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        [Column("InterviewerReviewID")]
        public int InterviewerReviewId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Column("InterviewID")]
        public int? InterviewId { get; set; }
        [StringLength(500)]
        public string Pros { get; set; }
        [StringLength(500)]
        public string Cons { get; set; }
        [StringLength(1000)]
        public string Comments { get; set; }
        public byte? Status { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(InterviewId))]
        [InverseProperty("InterviewerReviews")]
        public virtual Interview Interview { get; set; }
        [ForeignKey(nameof(Status))]
        [InverseProperty("InterviewerReviews")]
        public virtual Status StatusNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("InterviewerReviews")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(SkillRating.Review))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
