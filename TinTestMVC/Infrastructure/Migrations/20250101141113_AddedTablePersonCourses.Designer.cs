﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20250101141113_AddedTablePersonCourses")]
    partial class AddedTablePersonCourses
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "max@example.com",
                            FirstName = "Maksymilian",
                            LastName = "Galeziowski"
                        },
                        new
                        {
                            Id = 2,
                            Email = "krzys@test.com",
                            FirstName = "Krzys",
                            LastName = "Fajny"
                        });
                });

            modelBuilder.Entity("Domain.Entities.PersonCourses", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PersonId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("PersonCourses");
                });

            modelBuilder.Entity("Domain.Entities.PersonCourses", b =>
                {
                    b.HasOne("Domain.Entities.Course", "Course")
                        .WithMany("PersonCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany("PersonCourses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.Course", b =>
                {
                    b.Navigation("PersonCourses");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Navigation("PersonCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
