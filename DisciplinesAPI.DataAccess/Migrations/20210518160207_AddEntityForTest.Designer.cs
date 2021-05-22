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
    [Migration("20210518160207_AddEntityForTest")]
    partial class AddEntityForTest
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

                    b.Property<bool>("IsTrue")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("QuestionsId")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LessonTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8aa1098e-1010-4c7f-a3c8-e244ad6a7ea2"),
                            Name = "ПЗ"
                        },
                        new
                        {
                            Id = new Guid("c10db1d4-1564-46c6-9442-5e597f63fa7f"),
                            Name = "ГЗ"
                        },
                        new
                        {
                            Id = new Guid("02bbd981-3b45-4d4b-abc3-f4c7fc5baf56"),
                            Name = "СЕМ"
                        },
                        new
                        {
                            Id = new Guid("d9e3f695-70f7-4d27-8335-141969d00361"),
                            Name = "МЗ"
                        },
                        new
                        {
                            Id = new Guid("34d58776-25c9-4d05-b4c4-544aae8e201d"),
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

                    b.Property<Guid?>("DisciplinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinesId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VideoCoursesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VideoCoursesId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.VideoCourses", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("VideoCourses");
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
                        .HasForeignKey("QuestionsId");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Lesson", b =>
                {
                    b.HasOne("DisciplinesAPI.Models.Disciplines", "Disciplines")
                        .WithMany("lessons")
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
                        .WithMany("Questions")
                        .HasForeignKey("DisciplinesId");

                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Video", b =>
                {
                    b.HasOne("DisciplinesAPI.Models.DBModels.VideoCourses", "VideoCourses")
                        .WithMany("Video")
                        .HasForeignKey("VideoCoursesId");

                    b.Navigation("VideoCourses");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.LessonType", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Questions", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.VideoCourses", b =>
                {
                    b.Navigation("Video");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.Disciplines", b =>
                {
                    b.Navigation("lessons");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
