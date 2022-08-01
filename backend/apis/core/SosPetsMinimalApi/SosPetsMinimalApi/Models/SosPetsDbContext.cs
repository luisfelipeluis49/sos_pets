using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SosPetsMinimalApi.Models
{
    public partial class SosPetsDbContext : DbContext
    {
        public SosPetsDbContext()
        {
        }

        public SosPetsDbContext(DbContextOptions<SosPetsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveIngredient> ActiveIngredients { get; set; } = null!;
        public virtual DbSet<Agendum> Agenda { get; set; } = null!;
        public virtual DbSet<Anamnesi> Anamneses { get; set; } = null!;
        public virtual DbSet<AnamnesisMedicine> AnamnesisMedicines { get; set; } = null!;
        public virtual DbSet<AnamnesisSurgery> AnamnesisSurgeries { get; set; } = null!;
        public virtual DbSet<AnamnesisVaccine> AnamnesisVaccines { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentMedicine> AppointmentMedicines { get; set; } = null!;
        public virtual DbSet<AppointmentSurgery> AppointmentSurgeries { get; set; } = null!;
        public virtual DbSet<AppointmentVaccine> AppointmentVaccines { get; set; } = null!;
        public virtual DbSet<Breed> Breeds { get; set; } = null!;
        public virtual DbSet<Establishment> Establishments { get; set; } = null!;
        public virtual DbSet<EstablishmentProfessional> EstablishmentProfessionals { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<ParasiteControl> ParasiteControls { get; set; } = null!;
        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<Professional> Professionals { get; set; } = null!;
        public virtual DbSet<ReproductionStage> ReproductionStages { get; set; } = null!;
        public virtual DbSet<Specie> Species { get; set; } = null!;
        public virtual DbSet<Surgery> Surgeries { get; set; } = null!;
        public virtual DbSet<Tutor> Tutors { get; set; } = null!;
        public virtual DbSet<TypeOfProfessional> TypeOfProfessionals { get; set; } = null!;
        public virtual DbSet<Vaccine> Vaccines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NNOME-LVIX;User ID=sa;Password=123456;Database=SosPetsDb;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveIngredient>(entity =>
            {
                entity.ToTable("ActiveIngredient");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Agendum>(entity =>
            {
                entity.HasOne(d => d.TutorNavigation)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.Tutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tutor_FK_1");
            });

            modelBuilder.Entity<Anamnesi>(entity =>
            {
                entity.ToTable("Anamnesis");

                entity.Property(e => e.Castrated).HasDefaultValueSql("((0))");

                entity.Property(e => e.Diet)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.ParasiteControlNavigation)
                    .WithMany(p => p.Anamnesis)
                    .HasForeignKey(d => d.ParasiteControl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ParasiteControl_FK");

                entity.HasOne(d => d.ReproductionStageNavigation)
                    .WithMany(p => p.Anamnesis)
                    .HasForeignKey(d => d.ReproductionStage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ReproductionStage_FK");
            });

            modelBuilder.Entity<AnamnesisMedicine>(entity =>
            {
                entity.Property(e => e.Details)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnamnesisNavigation)
                    .WithMany(p => p.AnamnesisMedicines)
                    .HasForeignKey(d => d.Anamnesis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Anamnesis_FK_0");

                entity.HasOne(d => d.MedicineNavigation)
                    .WithMany(p => p.AnamnesisMedicines)
                    .HasForeignKey(d => d.Medicine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Medicine_FK_0");
            });

            modelBuilder.Entity<AnamnesisSurgery>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Details)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnamnesisNavigation)
                    .WithMany(p => p.AnamnesisSurgeries)
                    .HasForeignKey(d => d.Anamnesis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Anamnesis_FK_1");

                entity.HasOne(d => d.SurgeryNavigation)
                    .WithMany(p => p.AnamnesisSurgeries)
                    .HasForeignKey(d => d.Surgery)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Surgery_FK_0");
            });

            modelBuilder.Entity<AnamnesisVaccine>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Expiration)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([varchar](10),dateadd(year,(1),getdate()),(120)))");

                entity.HasOne(d => d.AnamnesisNavigation)
                    .WithMany(p => p.AnamnesisVaccines)
                    .HasForeignKey(d => d.Anamnesis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Anamnesis_FK_2");

                entity.HasOne(d => d.VaccineNavigation)
                    .WithMany(p => p.AnamnesisVaccines)
                    .HasForeignKey(d => d.Vaccine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vaccine_FK_0");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.HasOne(d => d.AgendaNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Agenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Agenda_FK");

                entity.HasOne(d => d.EstablishmentNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Establishment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Establishment_FK_1");

                entity.HasOne(d => d.PetNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Pet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pet_FK");

                entity.HasOne(d => d.ProfessionalNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Professional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Professional_FK_1");
            });

            modelBuilder.Entity<AppointmentMedicine>(entity =>
            {
                entity.Property(e => e.Details)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.AppointmentNavigation)
                    .WithMany(p => p.AppointmentMedicines)
                    .HasForeignKey(d => d.Appointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Appointment_FK_0");

                entity.HasOne(d => d.MedicineNavigation)
                    .WithMany(p => p.AppointmentMedicines)
                    .HasForeignKey(d => d.Medicine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Medicine_FK_1");
            });

            modelBuilder.Entity<AppointmentSurgery>(entity =>
            {
                entity.Property(e => e.Details)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.AppointmentNavigation)
                    .WithMany(p => p.AppointmentSurgeries)
                    .HasForeignKey(d => d.Appointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Appointment_FK_1");

                entity.HasOne(d => d.SurgeryNavigation)
                    .WithMany(p => p.AppointmentSurgeries)
                    .HasForeignKey(d => d.Surgery)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Surgery_FK_1");
            });

            modelBuilder.Entity<AppointmentVaccine>(entity =>
            {
                entity.Property(e => e.Expiration)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([varchar](10),dateadd(year,(1),getdate()),(120)))");

                entity.HasOne(d => d.AppointmentNavigation)
                    .WithMany(p => p.AppointmentVaccines)
                    .HasForeignKey(d => d.Appointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Appointment_FK_2");

                entity.HasOne(d => d.VaccineNavigation)
                    .WithMany(p => p.AppointmentVaccines)
                    .HasForeignKey(d => d.Vaccine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vaccine_FK_1");
            });

            modelBuilder.Entity<Breed>(entity =>
            {
                entity.ToTable("Breed");

                entity.Property(e => e.Breed1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Breed");
            });

            modelBuilder.Entity<Establishment>(entity =>
            {
                entity.ToTable("Establishment");

                entity.Property(e => e.AddressComplement)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Crmv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CRMV")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EstablishmentProfessional>(entity =>
            {
                entity.HasOne(d => d.EstablishmentNavigation)
                    .WithMany(p => p.EstablishmentProfessionals)
                    .HasForeignKey(d => d.Establishment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Establishment_FK_0");

                entity.HasOne(d => d.ProfessionalNavigation)
                    .WithMany(p => p.EstablishmentProfessionals)
                    .HasForeignKey(d => d.Professional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Professional_FK_0");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActiveIngredientNavigation)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.ActiveIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ActiveIngredient_FK");
            });

            modelBuilder.Entity<ParasiteControl>(entity =>
            {
                entity.ToTable("ParasiteControl");

                entity.Property(e => e.Bath).HasColumnType("date");

                entity.Property(e => e.CheckUp).HasColumnType("date");

                entity.Property(e => e.OnDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.Prevention).HasColumnType("date");

                entity.Property(e => e.PreventionDetails)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.Bithdate).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnamnesisNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Anamnesis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Anamnesis_FK_3");

                entity.HasOne(d => d.BreedNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Breed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Breed_FK");

                entity.HasOne(d => d.SpecieNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Specie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Specie_FK");

                entity.HasOne(d => d.TutorNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.Tutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tutor_FK_0");
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.ToTable("Professional");

                entity.Property(e => e.Crmv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CRMV")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Professionals)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Type_FK");
            });

            modelBuilder.Entity<ReproductionStage>(entity =>
            {
                entity.ToTable("ReproductionStage");

                entity.Property(e => e.Stage)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specie>(entity =>
            {
                entity.ToTable("Specie");

                entity.Property(e => e.Specie1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Specie");
            });

            modelBuilder.Entity<Surgery>(entity =>
            {
                entity.ToTable("Surgery");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.ToTable("Tutor");

                entity.Property(e => e.Bithdate).HasColumnType("date");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength();

                entity.Property(e => e.Crmv)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CRMV")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TypeOfProfessional>(entity =>
            {
                entity.ToTable("TypeOfProfessional");

                entity.Property(e => e.Type)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vaccine>(entity =>
            {
                entity.ToTable("Vaccine");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
