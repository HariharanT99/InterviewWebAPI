using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    [Table("Skill")]
    public partial class Skill
    {
        public Skill()
        {
            InverseParent = new HashSet<Skill>();
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        [Column("SkillID")]
        public int SkillId { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(Skill.InverseParent))]
        public virtual Skill Parent { get; set; }
        [InverseProperty(nameof(Skill.Parent))]
        public virtual ICollection<Skill> InverseParent { get; set; }
        [InverseProperty(nameof(SkillRating.Skill))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
