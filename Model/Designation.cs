using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Model
{
    [Table("Designation")]
    public partial class Designation
    {
        public Designation()
        {
            Applicants = new HashSet<Applicant>();
        }

        [Key]
        [Column("DesignationID")]
        public byte DesignationId { get; set; }
        [Required]
        [Column("Designation")]
        [StringLength(30)]
        public string Designation1 { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty(nameof(Applicant.AppliedForNavigation))]
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
