﻿// <auto-generated />
using System;
using HairdresserBookingApi.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HairdresserBookingApi.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20220227110103_remove phone from users 27.02.2022")]
    partial class removephonefromusers27022022
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsForMan")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkerActivityId")
                        .HasColumnType("int");

                    b.Property<int>("WorkerServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkerActivityId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.WorkBreak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkerAvailabilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerAvailabilityId");

                    b.ToTable("WorkBreak");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.WorkerActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RequiredMinutes")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerActivities");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.WorkerAvailability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerAvailabilities");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.Reservation", b =>
                {
                    b.HasOne("HairdresserBookingApi.Models.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairdresserBookingApi.Models.Entities.Api.WorkerActivity", "WorkerActivity")
                        .WithMany()
                        .HasForeignKey("WorkerActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WorkerActivity");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.WorkBreak", b =>
                {
                    b.HasOne("HairdresserBookingApi.Models.Entities.Api.WorkerAvailability", "WorkerAvailability")
                        .WithMany("Breaks")
                        .HasForeignKey("WorkerAvailabilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkerAvailability");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.WorkerActivity", b =>
                {
                    b.HasOne("HairdresserBookingApi.Models.Entities.Api.Activity", "Activity")
                        .WithMany("WorkerActivity")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HairdresserBookingApi.Models.Entities.Api.Worker", "Worker")
                        .WithMany("WorkerActivity")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.WorkerAvailability", b =>
                {
                    b.HasOne("HairdresserBookingApi.Models.Entities.Api.Worker", "Worker")
                        .WithMany("WorkerAvailabilities")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Users.User", b =>
                {
                    b.HasOne("HairdresserBookingApi.Models.Entities.Users.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.Activity", b =>
                {
                    b.Navigation("WorkerActivity");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.Worker", b =>
                {
                    b.Navigation("WorkerActivity");

                    b.Navigation("WorkerAvailabilities");
                });

            modelBuilder.Entity("HairdresserBookingApi.Models.Entities.Api.WorkerAvailability", b =>
                {
                    b.Navigation("Breaks");
                });
#pragma warning restore 612, 618
        }
    }
}