using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class proyect_weightContext : DbContext
    {
        public proyect_weightContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<CorpCustomers> CorpCustomers { get; set; }
        public virtual DbSet<WeightControl> WeightControl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CorpCustomers>(entity =>
            {
                entity.HasKey(e => e.IdCustomers)
                    .HasName("PRIMARY");

                entity.ToTable("corp_customers");

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCustomers)
                    .HasColumnName("id_customers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateModify)
                    .HasColumnName("date_modify")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PasswordAttempts)
                    .HasColumnName("password_attempts")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserModify)
                    .HasColumnName("user_modify")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<WeightControl>(entity =>
            {
                entity.HasKey(e => e.IdWeight)
                    .HasName("PRIMARY");

                entity.ToTable("weight_control");

                entity.HasIndex(e => e.IdCustomers)
                    .HasName("id_customers_idx");

                entity.Property(e => e.IdWeight)
                    .HasColumnName("id_weight")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateWeight)
                     .HasColumnName("date_weight")
                     .HasColumnType("datetime");

                entity.Property(e => e.IdCustomers)
                    .HasColumnName("id_customers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Imc)
                    .HasColumnName("imc")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(6,3)");

                entity.HasOne(d => d.IdCustomersNavigation)
                    .WithMany(p => p.WeightControl)
                    .HasForeignKey(d => d.IdCustomers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_customers");
            });
        }
    }
}
