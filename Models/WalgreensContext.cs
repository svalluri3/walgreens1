using Microsoft.EntityFrameworkCore;
using System;

namespace Walgreens.Models
{
    public class WalgreensContext : DbContext
    {
        public WalgreensContext(DbContextOptions<WalgreensContext> options)
            : base(options)
        {
        }

        public DbSet<Prescription> Prescriptions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Prescription entity
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId);

                entity.Property(e => e.MedicationName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.FillStatus)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Cost)
                      .HasColumnType("decimal(10,2)");

                entity.Property(e => e.RequestDate)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Seed some initial data with static dates
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    PrescriptionId = 1,
                    MedicationName = "Atorvastatin",
                    FillStatus = "Filled",
                    Cost = 12.50m,
                    RequestDate = new DateTime(2025, 9, 25) // static date
                },
                new Prescription
                {
                    PrescriptionId = 2,
                    MedicationName = "Lisinopril",
                    FillStatus = "Cancelled",
                    Cost = 8.99m,
                    RequestDate = new DateTime(2025, 9, 24) // static date
                }
            );
        }
    }
}
