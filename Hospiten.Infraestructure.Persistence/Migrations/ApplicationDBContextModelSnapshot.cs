﻿// <auto-generated />
using System;
using Hospiten.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospiten.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext.ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Appointments", b =>
                {
                    b.Property<int>("Ap_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ap_Id"));

                    b.Property<string>("Ap_Date")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ap_Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ap_hour")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Doctor_Id")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("Patient_Id")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Ap_Id");

                    b.HasIndex("Doctor_Id");

                    b.HasIndex("Patient_Id");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Doctors", b =>
                {
                    b.Property<int>("Doctor_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Doctor_Id"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phone_Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Doctor_Id");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Exams", b =>
                {
                    b.Property<int>("Exam_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Exam_Id"));

                    b.Property<string>("Exam_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Exam_Id");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Laboratory", b =>
                {
                    b.Property<int>("Lab_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Lab_Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Exam_Id")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Lab_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Patient_Id")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Lab_Id");

                    b.HasIndex("Exam_Id");

                    b.HasIndex("Patient_Id");

                    b.ToTable("Laboratory", (string)null);
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Patient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Patient_Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Allergi")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Smokes")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("dateB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Patient_Id");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Users", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("User_Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("User_type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("User_Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Appointments", b =>
                {
                    b.HasOne("Hospiten.Core.Domain.Entities.Doctors", "Doctor_Name")
                        .WithMany("Appointments")
                        .HasForeignKey("Doctor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospiten.Core.Domain.Entities.Patient", "Patient_Name")
                        .WithMany("Appointments")
                        .HasForeignKey("Patient_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor_Name");

                    b.Navigation("Patient_Name");
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Laboratory", b =>
                {
                    b.HasOne("Hospiten.Core.Domain.Entities.Exams", "Exam_Name")
                        .WithMany()
                        .HasForeignKey("Exam_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospiten.Core.Domain.Entities.Patient", "Patient_Name")
                        .WithMany("Laboratories")
                        .HasForeignKey("Patient_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam_Name");

                    b.Navigation("Patient_Name");
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Doctors", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Hospiten.Core.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Laboratories");
                });
#pragma warning restore 612, 618
        }
    }
}
