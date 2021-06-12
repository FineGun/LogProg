using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LogicalProgramming.Models
{
    public partial class aspnetLogicalProgrammingContext : DbContext
    {
        public aspnetLogicalProgrammingContext()
        {
        }

        public aspnetLogicalProgrammingContext(DbContextOptions<aspnetLogicalProgrammingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<LogicalTask> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-LogicalProgramming;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryDesc).HasMaxLength(250);

                entity.Property(e => e.CategoryName).HasMaxLength(150);
            });

            modelBuilder.Entity<LogicalTask>(entity =>
            {

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK_Task_Category_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
