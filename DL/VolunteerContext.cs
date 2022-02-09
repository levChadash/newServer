using System;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL
{
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
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PesachProject> PesachProjects { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentComment> StudentComments { get; set; }
        public virtual DbSet<StudentYear> StudentYears { get; set; }
        public virtual DbSet<VolunteerType> VolunteerTypes { get; set; }

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

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.Pair).HasColumnName("pair");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnName("reason");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Absents)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Absent_Match");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_Person");
            });
            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(50);

                entity.Property(e => e.Method)
                    .HasColumnName("METHOD")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Path)
                    .HasColumnName("PATH")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate)
                 .HasColumnName("Record_Date")
                 .HasColumnType("datetime");

                entity.Property(e => e.Referer)
                    .HasColumnName("REFERER")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
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

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhood_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.VolunteerTypeId).HasColumnName("volunteer_type_id");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK_Comment_Neighborhood");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Comment_Student");

                entity.HasOne(d => d.VolunteerType)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.VolunteerTypeId)
                    .HasConstraintName("FK_Comment_VolunteerType");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("Family");

                entity.Property(e => e.Id).HasColumnName("id");

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

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhood_id");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("phone_number")
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(10)
                    .HasColumnName("phone_number2")
                    .IsFixedLength(true);

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.VolunteerTypeId).HasColumnName("volunteer_type_id");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Families)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Family_Neighborhood");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Families)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Family_Status");

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

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfMatch)
                    .HasColumnType("date")
                    .HasColumnName("date_of_match");

                entity.Property(e => e.FamilyId).HasColumnName("family_id");

                entity.Property(e => e.RegisterId).HasColumnName("register_id");

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Family");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.RegisterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Register");
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.ToTable("Neighborhood");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("id_number")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PesachProject>(entity =>
            {
                entity.ToTable("PesachProject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FinishRegistration)
                    .HasColumnType("date")
                    .HasColumnName("finish_registration");

                entity.Property(e => e.StartRegistration)
                    .HasColumnType("date")
                    .HasColumnName("start_registration");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("Register");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Challenging).HasColumnName("challenging");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.NeihborhoodId).HasColumnName("neihborhood_id");

                entity.Property(e => e.OneTime).HasColumnName("one_time");

                entity.Property(e => e.Regulary).HasColumnName("regulary");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.StudentId2).HasColumnName("student_id2");

                entity.Property(e => e.VolunteerTypeId).HasColumnName("volunteer_type_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Neihborhood)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.NeihborhoodId)
                    .HasConstraintName("FK_Register_Neighborhood");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.RegisterStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Register_Student");

                entity.HasOne(d => d.StudentId2Navigation)
                    .WithMany(p => p.RegisterStudentId2Navigations)
                    .HasForeignKey(d => d.StudentId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Register_Student1");

                entity.HasOne(d => d.VolunteerType)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.VolunteerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Register_VolunteerType");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.NumOfVisits).HasColumnName("num_of_visits");

                entity.Property(e => e.RegisterId).HasColumnName("register_id");

                entity.Property(e => e.SDate)
                    .HasColumnType("date")
                    .HasColumnName("s_date");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.RegisterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Register");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhood_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Grade");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Neighborhood");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Person");
            });

            modelBuilder.Entity<StudentComment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentComments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentComments_Student");
            });

            modelBuilder.Entity<StudentYear>(entity =>
            {
                entity.ToTable("StudentYear");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassNumber).HasColumnName("class_number");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentYears)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentYear_Student");
            });

            modelBuilder.Entity<VolunteerType>(entity =>
            {
                entity.ToTable("VolunteerType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dscription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dscription");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
