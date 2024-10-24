using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobPortalSystem_Exercise.Models;

public partial class JobPortalExDbContext : DbContext
{
    public JobPortalExDbContext()
    {
    }

    public JobPortalExDbContext(DbContextOptions<JobPortalExDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=abdul-samad;Initial Catalog=JobPortalEX_DB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC071971152B");

            entity.ToTable("Application");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AppliedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__Compa__59063A47");

            entity.HasOne(d => d.Job).WithMany(p => p.Applications)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__JobId__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.Applications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Applicati__UserI__571DF1D5");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC07DD702A9C");

            entity.ToTable("Company");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC078F6C3D94");

            entity.ToTable("Experience");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.User).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Experienc__UserI__534D60F1");
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Intervie__3214EC0778DA1726");

            entity.ToTable("Interview");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Interview__Compa__4E88ABD4");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InterviewCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Interview__Creat__4F7CD00D");

            entity.HasOne(d => d.Job).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Interview__JobId__4CA06362");

            entity.HasOne(d => d.Jobseeker).WithMany(p => p.InterviewJobseekers)
                .HasForeignKey(d => d.JobseekerId)
                .HasConstraintName("FK__Interview__Jobse__4D94879B");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Job__3214EC0790B5D203");

            entity.ToTable("Job");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Job__CompanyId__47DBAE45");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Job__CreatedBy__48CFD27E");
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Qualific__3214EC074AF3986A");

            entity.ToTable("Qualification");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.User).WithMany(p => p.Qualifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Qualifica__UserI__440B1D61");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skill__3214EC07B2844ABA");

            entity.ToTable("Skill");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.User).WithMany(p => p.Skills)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Skill__UserId__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC077371854D");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534AB7056C9").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);

            entity.HasOne(d => d.Company).WithMany(p => p.Users)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__User__CompanyId__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
