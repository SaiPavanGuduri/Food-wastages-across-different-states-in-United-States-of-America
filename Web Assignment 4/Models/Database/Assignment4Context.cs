using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Web_Assignment_4.Models
{
    public partial class Assignment4Context : DbContext
    {
        public Assignment4Context()
        {
        }

        public Assignment4Context(DbContextOptions<Assignment4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<FoodEnforcement> FoodEnforcements { get; set; }
        public virtual DbSet<State> States { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.1.120;Database=Assignment4;User Id=sa;Password=msm;");
            }
        }//*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.City1);

                entity.ToTable("cities");

                entity.Property(e => e.City1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("state_code");

                entity.HasOne(d => d.StateCodeNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cities__state_co__2A4B4B5E");
            });

            modelBuilder.Entity<FoodEnforcement>(entity =>
            {
                entity.ToTable("foodEnforcement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address_1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address_2");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Classification)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("classification");

                entity.Property(e => e.CodeInfo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("code_info");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.EventId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("event_id");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("postal_code");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.RecallNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("recall_number");

                entity.Property(e => e.ReportDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("report_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.FoodEnforcements)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("FK__foodEnforc__city__36B12243");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateCode)
                    .HasName("PK__states__86729A0209DC51A6");

                entity.ToTable("states");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("state_code");

                entity.Property(e => e.State1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
