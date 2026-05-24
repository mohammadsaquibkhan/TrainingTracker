using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingTracker.Models;

namespace TrainingTracker.Data
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Training> Trainings { get; set; } = null!;
        public DbSet<Assignment> Assignments { get; set; } = null!;
        public DbSet<Certificate> Certificates { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Department
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(d => d.Name).IsUnique();
                entity.Property(d => d.Name).IsRequired().HasMaxLength(200);

                entity.HasMany(d => d.Employees)
                      .WithOne(e => e.Department)
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.JobTitle).HasMaxLength(200);
                entity.Property(e => e.Email).IsRequired();

                entity.HasOne(e => e.Manager)
                      .WithMany()
                      .HasForeignKey(e => e.ManagerId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(e => e.Assignments)
                      .WithOne(a => a.Employee)
                      .HasForeignKey(a => a.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Certificates)
                      .WithOne(c => c.Employee)
                      .HasForeignKey(c => c.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Training
            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasIndex(t => t.TrainingCode).IsUnique();
                entity.Property(t => t.TrainingCode).IsRequired().HasMaxLength(50);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);

                entity.Property(t => t.Type)
                      .HasConversion(new EnumToStringConverter<TrainingType>());

                entity.HasMany(t => t.Assignments)
                      .WithOne(a => a.Training)
                      .HasForeignKey(a => a.TrainingId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(t => t.Certificates)
                      .WithOne(c => c.Training)
                      .HasForeignKey(c => c.TrainingId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Assignment
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(a => a.Status)
                      .HasConversion(new EnumToStringConverter<AssignmentStatus>());

                entity.HasOne(a => a.Certificate)
                      .WithOne(c => c.Assignment)
                      .HasForeignKey<Certificate>(c => c.AssignmentId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Certificate
            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.HasIndex(c => c.CertificateNumber).IsUnique();
                entity.Property(c => c.CertificateNumber).IsRequired().HasMaxLength(100);
            });

            // Notification
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(n => n.Assignment)
                      .WithMany()
                      .HasForeignKey(n => n.AssignmentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(n => n.NotificationType)
                      .HasConversion(new EnumToStringConverter<NotificationType>());
            });
        }
    }
}
