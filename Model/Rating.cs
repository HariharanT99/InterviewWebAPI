using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    [Table("Rating")]
    public partial class Rating
    {
        public Rating()
        {
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        [Column("RatingID")]
        public int RatingId { get; set; }
        public int? Value { get; set; }
        [StringLength(20)]
        public string Category { get; set; }

        [InverseProperty(nameof(SkillRating.Rating))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
