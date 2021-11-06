using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    [Table("SkillRating")]
    public partial class SkillRating
    {
        [Key]
        [Column("SkillRatingID")]
        public int SkillRatingId { get; set; }
        [Column("ReviewID")]
        public int? ReviewId { get; set; }
        [Column("SkillID")]
        public int? SkillId { get; set; }
        [Column("RatingID")]
        public int? RatingId { get; set; }

        [ForeignKey(nameof(RatingId))]
        [InverseProperty("SkillRatings")]
        public virtual Rating Rating { get; set; }
        [ForeignKey(nameof(ReviewId))]
        [InverseProperty(nameof(InterviewerReview.SkillRatings))]
        public virtual InterviewerReview Review { get; set; }
        [ForeignKey(nameof(SkillId))]
        [InverseProperty("SkillRatings")]
        public virtual Skill Skill { get; set; }
    }
}
