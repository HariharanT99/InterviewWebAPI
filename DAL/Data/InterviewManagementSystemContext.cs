using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;

#nullable disable

namespace DAL.Data
{
    public partial class InterviewManagementSystemContext : DbContext
    {
        public InterviewManagementSystemContext()
        {
        }

        public InterviewManagementSystemContext(DbContextOptions<InterviewManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<InterviewRound> InterviewRounds { get; set; }
        public virtual DbSet<InterviewerReview> InterviewerReviews { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillRating> SkillRatings { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Server=TRAINEE-05; Database=InterviewManagementSystem; User Id=SA; Password=harant@26031999;Trusted_Connection=false;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastDesignation).IsUnicode(false);

                entity.Property(e => e.LastEmployer).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MedicalStatus).IsUnicode(false);

                entity.HasOne(d => d.AppliedForNavigation)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.AppliedFor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applicant__Appli__398D8EEE");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ApplicantCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applicant__Creat__3A81B327");

                entity.HasOne(d => d.ReferedByNavigation)
                    .WithMany(p => p.ApplicantReferedByNavigations)
                    .HasForeignKey(d => d.ReferedBy)
                    .HasConstraintName("FK__Applicant__Refer__3B75D760");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.DesignationId).ValueGeneratedOnAdd();

                entity.Property(e => e.Designation1).IsUnicode(false);
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.ApplicantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Interview__Appli__3C69FB99");

                entity.HasOne(d => d.InterviewRound)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.InterviewRoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Interview__Inter__3D5E1FD2");

                entity.HasOne(d => d.ResultNavigation)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.Result)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Interview__Resul__3E52440B");
            });

            modelBuilder.Entity<InterviewRound>(entity =>
            {
                entity.Property(e => e.InterviewRoundId).ValueGeneratedOnAdd();

                entity.Property(e => e.InterviewRoundName).IsUnicode(false);
            });

            modelBuilder.Entity<InterviewerReview>(entity =>
            {
                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Cons).IsUnicode(false);

                entity.Property(e => e.Pros).IsUnicode(false);

                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.InterviewerReviews)
                    .HasForeignKey(d => d.InterviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Interview__Inter__3F466844");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.InterviewerReviews)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Interview__Statu__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.InterviewerReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Interview__UserI__412EB0B6");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.RatingId).ValueGeneratedOnAdd();

                entity.Property(e => e.Category).IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedOnAdd();

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Skill__ParentID__4222D4EF");
            });

            modelBuilder.Entity<SkillRating>(entity =>
            {
                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.SkillRatings)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SkillRati__Ratin__4316F928");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.SkillRatings)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SkillRati__Revie__440B1D61");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.SkillRatings)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SkillRati__Skill__44FF419A");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).ValueGeneratedOnAdd();

                entity.Property(e => e.StatusType).IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__RoleID__45F365D3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__UserID__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
