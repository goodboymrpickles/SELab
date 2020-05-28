﻿// <auto-generated />
using System;
using EDUProjects.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EDUProjects.DataAccess.Migrations
{
    [DbContext(typeof(EDUProjectsDbContext))]
    [Migration("20200515202017_migration2")]
    partial class migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EnrollmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subject_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EnrollmentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Grading", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Passed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Gradings");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Annexes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GradingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Project_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("GradingId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birth_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EnrollmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GradingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("University")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnrollmentId");

                    b.HasIndex("GradingId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birth_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Class", b =>
                {
                    b.HasOne("EDUProjects.ApplicationLogic.Data.Enrollment", null)
                        .WithMany("Classes")
                        .HasForeignKey("EnrollmentId");

                    b.HasOne("EDUProjects.ApplicationLogic.Data.Teacher", null)
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Grading", b =>
                {
                    b.HasOne("EDUProjects.ApplicationLogic.Data.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Project", b =>
                {
                    b.HasOne("EDUProjects.ApplicationLogic.Data.Class", null)
                        .WithMany("Projects")
                        .HasForeignKey("ClassId");

                    b.HasOne("EDUProjects.ApplicationLogic.Data.Grading", null)
                        .WithMany("Projects")
                        .HasForeignKey("GradingId");
                });

            modelBuilder.Entity("EDUProjects.ApplicationLogic.Data.Student", b =>
                {
                    b.HasOne("EDUProjects.ApplicationLogic.Data.Enrollment", null)
                        .WithMany("Students")
                        .HasForeignKey("EnrollmentId");

                    b.HasOne("EDUProjects.ApplicationLogic.Data.Grading", null)
                        .WithMany("Students")
                        .HasForeignKey("GradingId");
                });
#pragma warning restore 612, 618
        }
    }
}