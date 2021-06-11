﻿// <auto-generated />
using System;
using DisciplinesAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DisciplinesAPI.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210611193506_AddTests")]
    partial class AddTests
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Answers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTrue")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuestionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionsId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("AdditionalMaterial")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("CountHours")
                        .HasColumnType("int");

                    b.Property<int>("CurrentNumberOflessonsType")
                        .HasColumnType("int");

                    b.Property<Guid>("DisciplinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("LessonTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("MethodicMaterials")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Presentation")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThemeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinesId");

                    b.HasIndex("LessonTypeId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.LessonType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LessonTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("215819a9-97c1-4ac1-bca6-0ae78d2a4074"),
                            IsDeleted = false,
                            Name = "ПЗ"
                        },
                        new
                        {
                            Id = new Guid("3efe08e5-c66f-4579-a3a0-7faa56750c67"),
                            IsDeleted = false,
                            Name = "ГЗ"
                        },
                        new
                        {
                            Id = new Guid("1685b84d-51a2-491c-9823-99ff16cc0a54"),
                            IsDeleted = false,
                            Name = "СЕМ"
                        },
                        new
                        {
                            Id = new Guid("bdb79589-858d-4c10-bf89-5ef8b04c4a53"),
                            IsDeleted = false,
                            Name = "МЗ"
                        },
                        new
                        {
                            Id = new Guid("5e5b108f-731d-4a35-ae1c-c8c7b955e963"),
                            IsDeleted = false,
                            Name = "Лекция"
                        });
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Questions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<Guid>("DisciplinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinesId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.Disciplines", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountHours")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursGZ")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursLR")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursLeck")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursMZ")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursPZ")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursSEM")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursSWZ")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursTest")
                        .HasColumnType("int");

                    b.Property<int>("CountHoursСontrolWork")
                        .HasColumnType("int");

                    b.Property<int>("CountNorm")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfPlan")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("GPID")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExam")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Plan")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Answers", b =>
                {
                    b.HasOne("DisciplinesAPI.Models.DBModels.Questions", "Questions")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Lesson", b =>
                {
                    b.HasOne("DisciplinesAPI.Models.Disciplines", "Disciplines")
                        .WithMany("Lessons")
                        .HasForeignKey("DisciplinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DisciplinesAPI.Models.DBModels.LessonType", "LessonType")
                        .WithMany("Lessons")
                        .HasForeignKey("LessonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplines");

                    b.Navigation("LessonType");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Questions", b =>
                {
                    b.HasOne("DisciplinesAPI.Models.Disciplines", "Disciplines")
                        .WithMany()
                        .HasForeignKey("DisciplinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.LessonType", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Questions", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.Disciplines", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}