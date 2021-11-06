using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Model
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Applicants = new HashSet<Applicant>();
            InterviewerReviews = new HashSet<InterviewerReview>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }

        [InverseProperty(nameof(Applicant.CreatedByNavigation))]
        public virtual ICollection<Applicant> Applicants { get; set; }
        [InverseProperty(nameof(InterviewerReview.User))]
        public virtual ICollection<InterviewerReview> InterviewerReviews { get; set; }
        [InverseProperty(nameof(UserRole.User))]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
