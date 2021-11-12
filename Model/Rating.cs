using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        public byte RatingId { get; set; }
        public byte Value { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [InverseProperty(nameof(SkillRating.Rating))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
