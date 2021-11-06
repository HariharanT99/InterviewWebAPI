using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    [Table("Status")]
    public partial class Status
    {
        public Status()
        {
            InterviewerReviews = new HashSet<InterviewerReview>();
            Interviews = new HashSet<Interview>();
        }

        [Key]
        [Column("StatusID")]
        public byte StatusId { get; set; }
        [StringLength(20)]
        public string StatusType { get; set; }

        [InverseProperty(nameof(InterviewerReview.StatusNavigation))]
        public virtual ICollection<InterviewerReview> InterviewerReviews { get; set; }
        [InverseProperty(nameof(Interview.ResultNavigation))]
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
