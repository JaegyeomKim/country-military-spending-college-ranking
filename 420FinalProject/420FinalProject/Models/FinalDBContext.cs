using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _420FinalProject.Models
{
    public partial class FinalDBContext : DbContext
    {
        public FinalDBContext()
        {
        }

        public FinalDBContext(DbContextOptions<FinalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CountryTable> CountryTables { get; set; } = null!;
        public virtual DbSet<EducationEffectTable> EducationEffectTables { get; set; } = null!;
        public virtual DbSet<NationalDefenseTable> NationalDefenseTables { get; set; } = null!;
        public virtual DbSet<UniversityTable> UniversityTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KAYLAPTOP;Database=FinalDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryTable>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("CountryTable");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Country).HasMaxLength(255);
            });

            modelBuilder.Entity<EducationEffectTable>(entity =>
            {
                entity.HasKey(e => e.EffectId);

                entity.ToTable("EducationEffectTable");

                entity.Property(e => e.EffectId).HasColumnName("EffectID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DefenseId).HasColumnName("DefenseID");

                entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.EducationEffectTables)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_EducationEffectTable_CountryTable");

                entity.HasOne(d => d.Defense)
                    .WithMany(p => p.EducationEffectTables)
                    .HasForeignKey(d => d.DefenseId)
                    .HasConstraintName("FK_EducationEffectTable_NationalDefenseTable1");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.EducationEffectTables)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("FK_EducationEffectTable_UniversityTable");
            });

            modelBuilder.Entity<NationalDefenseTable>(entity =>
            {
                entity.HasKey(e => e.DefenseId);

                entity.ToTable("NationalDefenseTable");

                entity.Property(e => e.DefenseId).HasColumnName("DefenseID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.NationalDefenseTables)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_NationalDefenseTable_CountryTable1");
            });

            modelBuilder.Entity<UniversityTable>(entity =>
            {
                entity.HasKey(e => e.UniversityId);

                entity.ToTable("UniversityTable");

                entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

                entity.Property(e => e.Institution).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
