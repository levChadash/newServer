using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity;

#nullable disable

namespace DL { 

    public partial class VolunteerContext : DbContext
    {
        public VolunteerContext()
        {
        }

        public VolunteerContext(DbContextOptions<VolunteerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absent> Absents { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<SpecialProject> SpecialProjects { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsVolunteering> StudentsVolunteerings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VolunteerType> VolunteerTypes { get; set; }
        public virtual DbSet<Volunteering> Volunteerings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=Volunteer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Absent>(entity =>
            {
                entity.ToTable("Absent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Pair).HasColumnName("pair");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.VolunteeringId).HasColumnName("volunteering_id");

                entity.HasOne(d => d.Volunteering)
                    .WithMany(p => p.Absents)
                    .HasForeignKey(d => d.VolunteeringId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Absent_Volunteering");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("comment");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.FromUserId).HasColumnName("from_user_id");

                entity.Property(e => e.Neighborhood)
                    .HasMaxLength(50)
                    .HasColumnName("neighborhood");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

                entity.Property(e => e.VolunteerTypeId).HasColumnName("volunteer_type_id");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.CommentFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .HasConstraintName("FK_Comment_User1");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.CommentToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .HasConstraintName("FK_Comment_User");

                entity.HasOne(d => d.VolunteerType)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.VolunteerTypeId)
                    .HasConstraintName("FK_Comment_VolunteerType");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("Family");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.Challenging).HasColumnName("challenging");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Neighborhood)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("neighborhood");

                entity.Property(e => e.OneTime).HasColumnName("one_time");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("phone_number")
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(10)
                    .HasColumnName("phone_number2")
                    .IsFixedLength(true);

                entity.Property(e => e.VolunteerTypeId).HasColumnName("volunteer_type_id");

                entity.HasOne(d => d.VolunteerType)
                    .WithMany(p => p.Families)
                    .HasForeignKey(d => d.VolunteerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Family_VolunteerType");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GradeNum).HasColumnName("grade_num");

                entity.Property(e => e.StartYear).HasColumnName("start_year");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.RatingId).HasColumnName("rating_id");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("host");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("method")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("path");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("record_date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("referer");

                entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comments");

                entity.Property(e => e.EDate)
                    .HasColumnType("date")
                    .HasColumnName("e_date");

                entity.Property(e => e.NumOfVisits).HasColumnName("num_of_visits");

                entity.Property(e => e.SDate)
                    .HasColumnType("date")
                    .HasColumnName("s_date");

                entity.Property(e => e.VolunteeringId).HasColumnName("volunteering_id");

                entity.HasOne(d => d.Volunteering)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.VolunteeringId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Volunteering");
            });

            modelBuilder.Entity<SpecialProject>(entity =>
            {
                entity.ToTable("SpecialProject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FinishRegistration)
                    .HasColumnType("date")
                    .HasColumnName("finish_registration");

                entity.Property(e => e.StartRegistration)
                    .HasColumnType("date")
                    .HasColumnName("start_registration");

                entity.Property(e => e.VolunteerTypeId).HasColumnName("volunteer_type_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.VolunteerType)
                    .WithMany(p => p.SpecialProjects)
                    .HasForeignKey(d => d.VolunteerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecialProject_VolunteerType");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassNum).HasColumnName("class_num");

                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.IsVolunteer).HasColumnName("is_volunteer");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Grade1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Person");
            });

            modelBuilder.Entity<StudentsVolunteering>(entity =>
            {
                entity.ToTable("StudentsVolunteering");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.VolunteeringId).HasColumnName("volunteering_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsVolunteerings)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsVolunteering_Student");

                entity.HasOne(d => d.Volunteering)
                    .WithMany(p => p.StudentsVolunteerings)
                    .HasForeignKey(d => d.VolunteeringId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsVolunteering_Volunteering");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CellphoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("cellphone_number")
                    .IsFixedLength(true);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("id_number")
                    .IsFixedLength(true);

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("phone_number")
                    .IsFixedLength(true);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<VolunteerType>(entity =>
            {
                entity.ToTable("VolunteerType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Volunteering>(entity =>
            {
                entity.ToTable("Volunteering");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Challenging).HasColumnName("challenging");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.DateOfMatch)
                    .HasColumnType("date")
                    .HasColumnName("date_of_match");

                entity.Property(e => e.FamilyId).HasColumnName("family_id");

                entity.Property(e => e.Neighborhood)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("neighborhood");

                entity.Property(e => e.VolunteerTypeId).HasColumnName("volunteer_type_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Volunteerings)
                    .HasForeignKey(d => d.FamilyId)
                    .HasConstraintName("FK_Volunteering_Family");

                entity.HasOne(d => d.VolunteerType)
                    .WithMany(p => p.Volunteerings)
                    .HasForeignKey(d => d.VolunteerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Volunteering_VolunteerType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
