using System;
using Microsoft.EntityFrameworkCore;
using myVeterinaryClinic.Models;

namespace VeterinaryClinic.Models
{
    public partial class VeterinaryClinicContext : DbContext
    {
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DocServ> DocServs { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<VeterinaryClinic.Models.Service> Services { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }    
        public VeterinaryClinicContext(DbContextOptions<VeterinaryClinicContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Animals_Owners");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<DocServ>(entity =>
            {
                entity.HasKey(e => e.DocServID);

                entity.ToTable("DocServ");

                entity.Property(e => e.DocServID).HasColumnName("DocservID");

                entity.Property(e => e.doctorID).HasColumnName("DoctorID");

                entity.Property(e => e.serviceID).HasColumnName("ServiceID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DocServs)
                    .HasForeignKey(d => d.doctorID)
                    .HasConstraintName("FK_DocServ_Doctors");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.DocServs)
                    .HasForeignKey(d => d.serviceID)
                    .HasConstraintName("FK_DocServ_Services");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("FullName");

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.Phone).HasMaxLength(25);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.Property(e => e.VaccinationId).HasColumnName("VaccinationID");

                entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

                entity.Property(e => e.DateVaccination).HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NextDateVaccination).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("FK_Vaccinations_Animals");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Vaccinations_Doctors");
            });

            OnModelCreatingPartial(modelBuilder);
        }

 partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}
