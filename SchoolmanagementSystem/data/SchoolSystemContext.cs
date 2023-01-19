using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolmanagementSystem.data;

public partial class SchoolSystemContext : DbContext
{
    public SchoolSystemContext()
    {
    }

    public SchoolSystemContext(DbContextOptions<SchoolSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<StudentsRecord> StudentsRecords { get; set; }

    public virtual DbSet<TeachersRecord> TeachersRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-DP5B1C81\\SQLEXPRESS;Database=SchoolSystem;Trusted_Connection=True; TrustServerCertificate = True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminCnic).HasName("PK__Admin__8AB5ADCA331D88D3");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminCnic).HasColumnName("Admin_CNIC");
            entity.Property(e => e.AdminName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Admin_Name");
            entity.Property(e => e.AdminPhone).HasColumnName("Admin_Phone");
        });

        modelBuilder.Entity<StudentsRecord>(entity =>
        {
            entity.HasKey(e => e.StudentCnic).HasName("PK__Students__F57602A6227D7EF0");

            entity.Property(e => e.StudentCnic).HasColumnName("Student_CNIC");
            entity.Property(e => e.StudentAddress)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Student_Address");
            entity.Property(e => e.StudentClass)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Student_Class");
            entity.Property(e => e.StudentDegree)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Student_Degree");
            entity.Property(e => e.StudentGroup)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Student_Group");
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Student_Name");
            entity.Property(e => e.StudentPhone).HasColumnName("Student_Phone");
            entity.Property(e => e.StudentSection)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Student_Section");
        });

        modelBuilder.Entity<TeachersRecord>(entity =>
        {
            entity.HasKey(e => e.TeacherCnic).HasName("PK__Teachers__ECEBFC73F7D3A9FA");

            entity.Property(e => e.TeacherCnic).HasColumnName("Teacher_CNIC");
            entity.Property(e => e.TeacherAddress)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Teacher_Address");
            entity.Property(e => e.TeacherClass)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Teacher_Class");
            entity.Property(e => e.TeacherExperience)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Teacher_Experience");
            entity.Property(e => e.TeacherName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Teacher_Name");
            entity.Property(e => e.TeacherPhone).HasColumnName("Teacher_Phone");
            entity.Property(e => e.TeacherQualification)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Teacher_Qualification");
            entity.Property(e => e.TeacherSubject)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Teacher_Subject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
