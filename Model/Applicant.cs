using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastEmployer { get; set; }
        [Required]
        [StringLength(30)]
        public string LastDesignation { get; set; }
        public byte AppliedFor { get; set; }
        public int? ReferedBy { get; set; }
        [StringLength(100)]
        public string MedicalStatus { get; set; }
        public int NoticePeriod { get; set; }
        [Required]
        [StringLength(200)]
        public string Resume { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [Column("ModifiedBY")]
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(AppliedFor))]
        [InverseProperty(nameof(Designation.Applicants))]
        public virtual Designation AppliedForNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(User.ApplicantCreatedByNavigations))]
        public virtual User CreatedByNavigation { get; set; }
        [ForeignKey(nameof(ReferedBy))]
        [InverseProperty(nameof(User.ApplicantReferedByNavigations))]
        public virtual User ReferedByNavigation { get; set; }
        [InverseProperty(nameof(Interview.Applicant))]
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
