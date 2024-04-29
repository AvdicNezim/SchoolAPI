﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolAPI.Data;

#nullable disable

namespace SchoolAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240427121043_addedFinals")]
    partial class addedFinals
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("coursesid")
                        .HasColumnType("int");

                    b.Property<int>("studentsid")
                        .HasColumnType("int");

                    b.HasKey("coursesid", "studentsid");

                    b.HasIndex("studentsid");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfClasses")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("courses");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Microsoft Web Services",
                            numberOfClasses = 32
                        },
                        new
                        {
                            id = 2,
                            name = "ASP.NET Core MVC",
                            numberOfClasses = 44
                        },
                        new
                        {
                            id = 3,
                            name = "Introduction To Web Development",
                            numberOfClasses = 32
                        });
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("departments");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Microsoft Web Development"
                        },
                        new
                        {
                            id = 2,
                            name = "Microsoft Desktop Development"
                        });
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Final", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("mark")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("courseId");

                    b.HasIndex("studentId");

                    b.ToTable("Finals");

                    b.HasData(
                        new
                        {
                            id = 1,
                            courseId = 1,
                            date = new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            mark = 10,
                            name = "Primer polaganja",
                            studentId = 1
                        },
                        new
                        {
                            id = 2,
                            courseId = 1,
                            date = new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            mark = 10,
                            name = "Primer polaganja",
                            studentId = 2
                        },
                        new
                        {
                            id = 3,
                            courseId = 2,
                            date = new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            mark = 10,
                            name = "Primer polaganja",
                            studentId = 1
                        });
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("departmentId");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            id = 1,
                            departmentId = 1,
                            firstName = "John",
                            lastName = "Doe"
                        },
                        new
                        {
                            id = 2,
                            departmentId = 1,
                            firstName = "Mark",
                            lastName = "Stone"
                        });
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("SchoolAPI.Data.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("coursesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI.Data.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("studentsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Final", b =>
                {
                    b.HasOne("SchoolAPI.Data.Entities.Course", "course")
                        .WithMany()
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI.Data.Entities.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("student");
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Student", b =>
                {
                    b.HasOne("SchoolAPI.Data.Entities.Department", "department")
                        .WithMany()
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });
#pragma warning restore 612, 618
        }
    }
}