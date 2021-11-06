using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;

#nullable disable

namespace DAL.Data
{
    public partial class InterviewManagementContext : DbContext
    {
        public InterviewManagementContext()
        {
        }

        public InterviewManagementContext(DbContextOptions<InterviewManagementContext> options)
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

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.Property(e => e.Resume).IsUnicode(false);

                entity.HasOne(d => d.AppliedForNavigation)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.AppliedFor)
                    .HasConstraintName("FK__Applicant__Appli__2A4B4B5E");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Applicant__Creat__2B3F6F97");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.DesignationId).ValueGeneratedNever();

                entity.Property(e => e.Designation1).IsUnicode(false);
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.ApplicantId)
                    .HasConstraintName("FK__Interview__Appli__30F848ED");

                entity.HasOne(d => d.InterviewRound)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.InterviewRoundId)
                    .HasConstraintName("FK__Interview__Inter__31EC6D26");

                entity.HasOne(d => d.ResultNavigation)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.Result)
                    .HasConstraintName("FK__Interview__Resul__300424B4");
            });

            modelBuilder.Entity<InterviewRound>(entity =>
            {
                entity.Property(e => e.InterviewRoundId).ValueGeneratedOnAdd();

                entity.Property(e => e.InterviewRoundName).IsUnicode(false);
            });

            modelBuilder.Entity<InterviewerReview>(entity =>
            {
                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.InterviewerReviews)
                    .HasForeignKey(d => d.InterviewId)
                    .HasConstraintName("FK__Interview__Inter__403A8C7D");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.InterviewerReviews)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__Interview__Statu__3F466844");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.InterviewerReviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Interview__UserI__412EB0B6");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Category).IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Skill__ParentID__3A81B327");
            });

            modelBuilder.Entity<SkillRating>(entity =>
            {
                entity.Property(e => e.SkillRatingId).ValueGeneratedNever();

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.SkillRatings)
                    .HasForeignKey(d => d.RatingId)
                    .HasConstraintName("FK__SkillRati__Ratin__45F365D3");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.SkillRatings)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("FK__SkillRati__Revie__440B1D61");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.SkillRatings)
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK__SkillRati__Skill__44FF419A");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).ValueGeneratedOnAdd();

                entity.Property(e => e.StatusType).IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.UserRoleId).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRole__RoleID__36B12243");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRole__UserID__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
