using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        public byte RoundOrder { get; set; }
        [Required]
        [StringLength(30)]
        public string InterviewRoundName { get; set; }

        [InverseProperty(nameof(Interview.InterviewRound))]
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
