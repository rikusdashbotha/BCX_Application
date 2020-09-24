﻿// <auto-generated />
using System;
using BCX_DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BCX_DAL.Migrations
{
    [DbContext(typeof(BCX_DBContext))]
    [Migration("20200921055210_FixedRolesIndex3")]
    partial class FixedRolesIndex3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BCX_CORE.Objects.Employees.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CANCELLED")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedTS")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTS")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1")
                        .IsUnique()
                        .HasFilter("[RoleId1] IS NOT NULL");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CANCELLED = false,
                            CreatedTS = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Foo",
                            LastName = "Bar",
                            RoleId = 101,
                            UpdatedTS = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CANCELLED = false,
                            CreatedTS = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bob",
                            LastName = "Newbie",
                            RoleId = 102,
                            UpdatedTS = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BCX_CORE.Objects.Hours.Hour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CANCELLED")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedTS")
                        .HasColumnType("datetime2");

                    b.Property<double>("Hours")
                        .HasColumnType("float");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<double>("RoleRateAtTime")
                        .HasColumnType("float");

                    b.Property<int>("TaskAssignId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedTS")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.HasIndex("TaskAssignId");

                    b.ToTable("Hours");
                });

            modelBuilder.Entity("BCX_CORE.Objects.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CANCELLED")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedTS")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("RatePerHour")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedTS")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            CANCELLED = false,
                            CreatedTS = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Level 1",
                            RatePerHour = 50.0,
                            UpdatedTS = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 102,
                            CANCELLED = false,
                            CreatedTS = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Level 2",
                            RatePerHour = 100.0,
                            UpdatedTS = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BCX_CORE.Objects.TaskAssigns.TaskAssign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AtCurrentRate")
                        .HasColumnType("float");

                    b.Property<bool>("CANCELLED")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedTS")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTS")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskAssigns");
                });

            modelBuilder.Entity("BCX_CORE.Objects.Tasks.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CANCELLED")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedTS")
                        .HasColumnType("datetime2");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("TaskAssignId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskAssignId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTS")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TaskAssignId1");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("BCX_CORE.Objects.Employees.Employee", b =>
                {
                    b.HasOne("BCX_CORE.Objects.Roles.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BCX_CORE.Objects.Roles.Role", null)
                        .WithOne("Employee")
                        .HasForeignKey("BCX_CORE.Objects.Employees.Employee", "RoleId1");
                });

            modelBuilder.Entity("BCX_CORE.Objects.Hours.Hour", b =>
                {
                    b.HasOne("BCX_CORE.Objects.Roles.Role", "Role")
                        .WithOne("Hour")
                        .HasForeignKey("BCX_CORE.Objects.Hours.Hour", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BCX_CORE.Objects.TaskAssigns.TaskAssign", "TaskAssign")
                        .WithMany("Hours")
                        .HasForeignKey("TaskAssignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BCX_CORE.Objects.TaskAssigns.TaskAssign", b =>
                {
                    b.HasOne("BCX_CORE.Objects.Employees.Employee", "Employee")
                        .WithMany("TaskAssigns")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BCX_CORE.Objects.Tasks.Task", "Task")
                        .WithMany("TaskAssigns")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("BCX_CORE.Objects.Tasks.Task", b =>
                {
                    b.HasOne("BCX_CORE.Objects.TaskAssigns.TaskAssign", "TaskAssign")
                        .WithMany()
                        .HasForeignKey("TaskAssignId1");
                });
#pragma warning restore 612, 618
        }
    }
}
