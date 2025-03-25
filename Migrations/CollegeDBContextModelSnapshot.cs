﻿// <auto-generated />
using System;
using CollegeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace firstAPI.Migrations
{
    [DbContext(typeof(CollegeDBContext))]
    partial class CollegeDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("CollegeApp.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "NJ",
                            DOB = new DateTime(1990, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "benjamin@email.com",
                            StudentName = "Benjamin"
                        },
                        new
                        {
                            Id = 2,
                            Address = "CA",
                            DOB = new DateTime(1995, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sophia@email.com",
                            StudentName = "Sophia"
                        },
                        new
                        {
                            Id = 3,
                            Address = "NY",
                            DOB = new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "liam@email.com",
                            StudentName = "Liam"
                        },
                        new
                        {
                            Id = 4,
                            Address = "TX",
                            DOB = new DateTime(1994, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "olivia@email.com",
                            StudentName = "Olivia"
                        },
                        new
                        {
                            Id = 5,
                            Address = "FL",
                            DOB = new DateTime(1993, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "noah@email.com",
                            StudentName = "Noah"
                        },
                        new
                        {
                            Id = 6,
                            Address = "WA",
                            DOB = new DateTime(1991, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emma@email.com",
                            StudentName = "Emma"
                        },
                        new
                        {
                            Id = 7,
                            Address = "NV",
                            DOB = new DateTime(1989, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "james@email.com",
                            StudentName = "James"
                        },
                        new
                        {
                            Id = 8,
                            Address = "IL",
                            DOB = new DateTime(1996, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ava@email.com",
                            StudentName = "Ava"
                        },
                        new
                        {
                            Id = 9,
                            Address = "OH",
                            DOB = new DateTime(1993, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "william@email.com",
                            StudentName = "William"
                        },
                        new
                        {
                            Id = 10,
                            Address = "PA",
                            DOB = new DateTime(1992, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mia@email.com",
                            StudentName = "Mia"
                        },
                        new
                        {
                            Id = 11,
                            Address = "GA",
                            DOB = new DateTime(1994, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lucas@email.com",
                            StudentName = "Lucas"
                        },
                        new
                        {
                            Id = 12,
                            Address = "MI",
                            DOB = new DateTime(1991, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "charlotte@email.com",
                            StudentName = "Charlotte"
                        },
                        new
                        {
                            Id = 13,
                            Address = "NC",
                            DOB = new DateTime(1990, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "henry@email.com",
                            StudentName = "Henry"
                        },
                        new
                        {
                            Id = 14,
                            Address = "VA",
                            DOB = new DateTime(1995, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "amelia@email.com",
                            StudentName = "Amelia"
                        },
                        new
                        {
                            Id = 15,
                            Address = "MA",
                            DOB = new DateTime(1993, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alexander@email.com",
                            StudentName = "Alexander"
                        },
                        new
                        {
                            Id = 16,
                            Address = "CO",
                            DOB = new DateTime(1996, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "evelyn@email.com",
                            StudentName = "Evelyn"
                        },
                        new
                        {
                            Id = 17,
                            Address = "AZ",
                            DOB = new DateTime(1988, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michael@email.com",
                            StudentName = "Michael"
                        },
                        new
                        {
                            Id = 18,
                            Address = "OR",
                            DOB = new DateTime(1994, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "harper@email.com",
                            StudentName = "Harper"
                        },
                        new
                        {
                            Id = 19,
                            Address = "WI",
                            DOB = new DateTime(1992, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "daniel@email.com",
                            StudentName = "Daniel"
                        },
                        new
                        {
                            Id = 20,
                            Address = "MN",
                            DOB = new DateTime(1990, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ella@email.com",
                            StudentName = "Ella"
                        });
                });

            modelBuilder.Entity("Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentName = "Computer Science",
                            Description = "Focuses on programming, algorithms, and systems."
                        },
                        new
                        {
                            Id = 2,
                            DepartmentName = "Mathematics",
                            Description = "Deals with numbers, theories, and proofs."
                        },
                        new
                        {
                            Id = 3,
                            DepartmentName = "Business",
                            Description = "Covers management, marketing, and finance."
                        },
                        new
                        {
                            Id = 4,
                            DepartmentName = "Biology",
                            Description = "Studies living organisms and ecosystems."
                        });
                });

            modelBuilder.Entity("CollegeApp.Data.Student", b =>
                {
                    b.HasOne("Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_STUDENTS_DEPARTMENT");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Department", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
