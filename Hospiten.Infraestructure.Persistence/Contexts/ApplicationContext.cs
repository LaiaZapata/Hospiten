using Hospiten.Core.Domain.Common;
using Hospiten.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospiten.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext
    {
        public class ApplicationDBContext : DbContext
        {
            public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options) { }

            public DbSet<Appointments> Appointments { get; set; }
            public DbSet<Doctors> Doctors { get; set; }
            public DbSet<Exams> Exams { get; set; }
            public DbSet<Laboratory> Laboratories { get; set; }
            public DbSet<Patient> Patients { get; set; }
            public DbSet<Users> Users { get; set; }


            public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.Created = DateTime.Now;
                            entry.Entity.CreatedBy = "DefaultAppUser";
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModified = DateTime.Now;
                            entry.Entity.LastModifiedBy = "DefaultAppUser";
                            break;
                    }
                }

                return base.SaveChangesAsync(cancellationToken);
            }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // fluent API

                #region tables
                modelBuilder.Entity<Appointments>().ToTable("Appointments");
                modelBuilder.Entity<Doctors>().ToTable("Doctors");
                modelBuilder.Entity<Exams>().ToTable("Exams");
                modelBuilder.Entity<Laboratory>().ToTable("Laboratory");
                modelBuilder.Entity<Patient>().ToTable("Patient");
                modelBuilder.Entity<Users>().ToTable("Users");
                #endregion

                #region Primary Keys
                modelBuilder.Entity<Appointments>().HasKey(a => a.Ap_Id);
                modelBuilder.Entity<Doctors>().HasKey(d => d.Doctor_Id);
                modelBuilder.Entity<Exams>().HasKey(e => e.Exam_Id);
                modelBuilder.Entity<Laboratory>().HasKey(l => l.Lab_Id);
                modelBuilder.Entity<Patient>().HasKey(p => p.Patient_Id);
                modelBuilder.Entity<Users>().HasKey(u => u.User_Id);
                #endregion

                #region Relationships
                modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Patient_Name)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.Patient_Id);
               
                modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Doctor_Name)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.Doctor_Id);

                modelBuilder.Entity<Laboratory>()
                .HasOne(l => l.Patient_Name)
                .WithMany(p => p.Laboratories)
                .HasForeignKey(a => a.Patient_Id);

                modelBuilder.Entity<Laboratory>()
                .HasOne(l => l.Exam_Name)
                .WithMany()
                .HasForeignKey(l => l.Exam_Id);
                #endregion

                #region Appointments
                modelBuilder.Entity<Appointments>()
                .Property(a => a.Patient_Id)
                .IsRequired()
                .HasMaxLength(50);

                modelBuilder.Entity<Appointments>()
                .Property(a => a.Doctor_Id)
                .IsRequired()
                .HasMaxLength(50);

                modelBuilder.Entity<Appointments>()
                .Property(a => a.Ap_Date)
                .IsRequired()
                .HasMaxLength(50);

                modelBuilder.Entity<Appointments>()
                .Property(a => a.Ap_hour)
                 .IsRequired()
                .HasMaxLength(50);

                modelBuilder.Entity<Appointments>()
                .Property(a => a.Ap_Status)
                .IsRequired()
                .HasMaxLength(50);
                #endregion

                #region Doctors
                modelBuilder.Entity<Doctors>()
                .Property(d => d.Name)
                .HasMaxLength(50);

                 modelBuilder.Entity<Doctors>()
                .Property(d => d.lastname)
                .HasMaxLength(50);

                 modelBuilder.Entity<Doctors>()
                .Property(d => d.email)
                .HasMaxLength(50);

                 modelBuilder.Entity<Doctors>()
                .Property(d => d.phone_Number)
                .HasMaxLength(50);

                 modelBuilder.Entity<Doctors>()
                .Property(d => d.Cedula)
                .HasMaxLength(50);

                 modelBuilder.Entity<Doctors>()
                .Property(d => d.photo)
                .HasMaxLength(150);



                #endregion

                #region Exams
                modelBuilder.Entity<Exams>()
                .Property(e => e.Exam_Name)
                .HasMaxLength(50);

                #endregion

                #region Laboratory
                modelBuilder.Entity<Laboratory>()
                .Property( l => l.Lab_Name)
                .HasMaxLength(50);

                modelBuilder.Entity<Laboratory>()
                .Property(l => l.Patient_Id)
                .HasMaxLength(50);

                modelBuilder.Entity<Laboratory>()
                .Property(l => l.Exam_Id)
                .HasMaxLength(50);

                modelBuilder.Entity<Laboratory>()
                .Property(l => l.Result)
                .HasMaxLength(50);

                modelBuilder.Entity<Laboratory>()
                .Property(l => l.Description)
                .HasMaxLength(50);
                #endregion

                #region Patient
                modelBuilder.Entity<Patient>()
                .Property(p => p.Name)
                .HasMaxLength(50);

                modelBuilder.Entity<Patient>()
                .Property(p => p.Lastname)
                .HasMaxLength(50);

                modelBuilder.Entity<Patient>()
                .Property(p => p.Phone_Number)
                .HasMaxLength(50);

                modelBuilder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(50);

                modelBuilder.Entity<Patient>()
                .Property(p => p.Cedula)
                .HasMaxLength(50);

                modelBuilder.Entity<Patient>()
                .Property(p => p.dateB);

                modelBuilder.Entity<Patient>()
                .Property(p => p.Smokes)
                .HasMaxLength(2);

                modelBuilder.Entity<Patient>()
                .Property(p => p.Allergi)
                .HasMaxLength(2);
                #endregion

                #region User
                modelBuilder.Entity<Users>()
                .Property(u => u.User_Name)
                .HasMaxLength(50);

                modelBuilder.Entity<Users>()
                .Property(u => u.User_Password)
                .HasMaxLength(50);

                modelBuilder.Entity<Users>()
                .Property(u => u.User_Email)
                .HasMaxLength(50);

                modelBuilder.Entity<Users>()
                .Property(u => u.User_type)
                .HasMaxLength(50);
                #endregion
            }

        }
    }
}
