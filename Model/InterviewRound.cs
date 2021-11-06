using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    [Table("InterviewRound")]
    public partial class InterviewRound
    {
        public InterviewRound()
        {
            Interviews = new HashSet<Interview>();
        }

        [Key]
        [Column("InterviewRoundID")]
        public byte InterviewRoundId { get; set; }
        public byte? RoundOrder { get; set; }
        [StringLength(20)]
        public string InterviewRoundName { get; set; }

        [InverseProperty(nameof(Interview.InterviewRound))]
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
