using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    [Table("Applicant")]
    public partial class Applicant
    {
        public Applicant()
        {
            Interviews = new HashSet<Interview>();
        }

        [Key]
        [Column("ApplicantID")]
        public int ApplicantId { get; set; }
        [StringLength(24)]
        public string FirstName { get; set; }
        [StringLength(24)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string LastEmployer { get; set; }
        [StringLength(20)]
        public string LastDesignation { get; set; }
        public int? AppliedFor { get; set; }
        [StringLength(150)]
        public string ReferedBy { get; set; }
        [StringLength(500)]
        public string MedicalStatus { get; set; }
        public int? NoticePeriod { get; set; }
        [StringLength(200)]
        public string Resume { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column("ModifiedBY")]
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        [ForeignKey(nameof(AppliedFor))]
        [InverseProperty(nameof(Designation.Applicants))]
        public virtual Designation AppliedForNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(User.Applicants))]
        public virtual User CreatedByNavigation { get; set; }
        [InverseProperty(nameof(Interview.Applicant))]
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
