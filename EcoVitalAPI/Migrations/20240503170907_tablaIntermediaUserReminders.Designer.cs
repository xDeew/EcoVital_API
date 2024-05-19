﻿// <auto-generated />
using System;
using EcoVitalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoVitalAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240503170907_tablaIntermediaUserReminders")]
    partial class tablaIntermediaUserReminders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EcoVitalAPI.Models.ActivityRecord", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordId"), 1L, 1);

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("int");

                    b.HasKey("RecordId");

                    b.ToTable("ActivityRecords");
                });

            modelBuilder.Entity("EcoVitalAPI.Models.HealthReminder", b =>
                {
                    b.Property<int>("ReminderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReminderId"), 1L, 1);

                    b.Property<string>("ReminderMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReminderTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReminderType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReminderId");

                    b.ToTable("HealthReminders");
                });

            modelBuilder.Entity("EcoVitalAPI.Models.ProgressTracking", b =>
                {
                    b.Property<int>("ProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgressId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Metric")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("ProgressId");

                    b.HasIndex("UserId");

                    b.ToTable("ProgressTrackings");
                });

            modelBuilder.Entity("EcoVitalAPI.Models.UserActivityRecord", b =>
                {
                    b.Property<int>("UserActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserActivityId"), 1L, 1);

                    b.Property<int>("ActivityRecordId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserActivityId");

                    b.ToTable("UserActivityRecords");
                });

            modelBuilder.Entity("LoginAPI.Models.SecurityQuestion", b =>
                {
                    b.Property<int>("SecurityQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SecurityQuestionId"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SecurityQuestionId");

                    b.ToTable("SecurityQuestions");
                });

            modelBuilder.Entity("LoginAPI.Models.UserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("UserGoal", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoalId"), 1L, 1);

                    b.Property<int>("ActivityRecordId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GoalId");

                    b.ToTable("UserGoals");
                });

            modelBuilder.Entity("EcoVitalAPI.Models.ProgressTracking", b =>
                {
                    b.HasOne("LoginAPI.Models.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
