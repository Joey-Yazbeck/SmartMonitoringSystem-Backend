using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartMonitoringSystem.Models;

public partial class FypContext : DbContext
{
    public FypContext()
    {
    }

    public FypContext(DbContextOptions<FypContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<Camera> Cameras { get; set; }

    public virtual DbSet<FamilyStatus> FamilyStatuses { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Keyword> Keywords { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Suspect> Suspects { get; set; }

    public virtual DbSet<Target> Targets { get; set; }

    public virtual DbSet<TargetStatus> TargetStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warrant> Warrants { get; set; }

    public virtual DbSet<WarrantStatus> WarrantStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=FYP;Username=postgres;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.AlertId).HasName("Alerts_pkey");

            entity.ToTable("alerts");

            entity.Property(e => e.AlertId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Target).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.TargetId)
                .HasConstraintName("TargetId");
        });

        modelBuilder.Entity<Camera>(entity =>
        {
            entity.HasKey(e => e.CameraId).HasName("Camera_pkey");

            entity.ToTable("camera");

            entity.Property(e => e.CameraId).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<FamilyStatus>(entity =>
        {
            entity.HasKey(e => e.FamilyStatusId).HasName("FamilyStatus_pkey");

            entity.ToTable("family_status");

            entity.Property(e => e.FamilyStatusId).UseIdentityAlwaysColumn();
            entity.Property(e => e.FamilyStatus1).HasColumnName("FamilyStatus");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("Gender_pkey");

            entity.ToTable("gender");

            entity.Property(e => e.GenderId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Gender1).HasColumnName("Gender");
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.HasKey(e => e.KeywordId).HasName("Keyword_pkey");

            entity.ToTable("keyword");

            entity.Property(e => e.KeywordId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Keyword1).HasColumnName("Keyword");
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.NationalityId).HasName("Nationality_pkey");

            entity.ToTable("nationality");

            entity.Property(e => e.NationalityId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Nationality1).HasColumnName("Nationality");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("Photo_pkey");

            entity.ToTable("photo");

            entity.HasIndex(e => e.TargetId, "Target_Constraint_Unique").IsUnique();

            entity.Property(e => e.PhotoId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Photo1).HasColumnName("Photo");

            entity.HasOne(d => d.Target).WithOne(p => p.Photo)
                .HasForeignKey<Photo>(d => d.TargetId)
                .HasConstraintName("TargetId");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("Profile_pkey");

            entity.ToTable("profile");

            entity.Property(e => e.ProfileId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.FamilyStatus).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.FamilyStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FamilyStatusId");

            entity.HasOne(d => d.Gender).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GenderId");

            entity.HasOne(d => d.Nationality).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.NationalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("NationalityId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("Role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Role1).HasColumnName("Role");
        });

        modelBuilder.Entity<Suspect>(entity =>
        {
            entity.HasKey(e => e.SuspectId).HasName("Suspect_pkey");

            entity.ToTable("suspect");

            entity.HasIndex(e => e.PhotoId, "PhotoId Constraint").IsUnique();

            entity.Property(e => e.SuspectId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Camera).WithMany(p => p.Suspects)
                .HasForeignKey(d => d.CameraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CameraId");

            entity.HasOne(d => d.Photo).WithOne(p => p.Suspect)
                .HasForeignKey<Suspect>(d => d.PhotoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PhotoId");
        });

        modelBuilder.Entity<Target>(entity =>
        {
            entity.HasKey(e => e.TargetId).HasName("Target_pkey");

            entity.ToTable("target");

            entity.HasIndex(e => e.ProfileId, "Profile_constraint_Unique").IsUnique();

            entity.Property(e => e.TargetId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Profile).WithOne(p => p.Target)
                .HasForeignKey<Target>(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProfileId");

            entity.HasOne(d => d.TargetStatus).WithMany(p => p.Targets)
                .HasForeignKey(d => d.TargetStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StatusID");
        });

        modelBuilder.Entity<TargetStatus>(entity =>
        {
            entity.HasKey(e => e.TargetStatusId).HasName("target_status_pkey");

            entity.ToTable("target_status");

            entity.Property(e => e.TargetStatusId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("TargetStatusID");
            entity.Property(e => e.TargetStatus1).HasColumnName("TargetStatus");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pkey");

            entity.ToTable("user");

            entity.Property(e => e.UserId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoleId");
        });

        modelBuilder.Entity<Warrant>(entity =>
        {
            entity.HasKey(e => e.WarrantId).HasName("Warrant_pkey");

            entity.ToTable("warrant");

            entity.Property(e => e.WarrantId).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Profile).WithMany(p => p.Warrants)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProfileId");

            entity.HasOne(d => d.WarrantStatus).WithMany(p => p.Warrants)
                .HasForeignKey(d => d.WarrantStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("WarrantStatusId");
        });

        modelBuilder.Entity<WarrantStatus>(entity =>
        {
            entity.HasKey(e => e.WarrantStatusId).HasName("WarrantStatus_pkey");

            entity.ToTable("warrant_status");

            entity.Property(e => e.WarrantStatusId).UseIdentityAlwaysColumn();
            entity.Property(e => e.WarrantStatus1).HasColumnName("WarrantStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
