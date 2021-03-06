// <auto-generated />
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
    [Migration("20210608191324_AddIsDeleted")]
    partial class AddIsDeleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            Id = new Guid("2cb8a9d0-3f00-4f38-8a66-65403f3a0fe2"),
                            IsDeleted = false,
                            Name = "ПЗ"
                        },
                        new
                        {
                            Id = new Guid("9da7f782-3978-49f4-ba90-bb042e94ef3c"),
                            IsDeleted = false,
                            Name = "ГЗ"
                        },
                        new
                        {
                            Id = new Guid("f3ccdee6-c89b-4eb9-b7ff-01c7101df404"),
                            IsDeleted = false,
                            Name = "СЕМ"
                        },
                        new
                        {
                            Id = new Guid("2de4aa61-c511-4d6b-a451-0760a61e550e"),
                            IsDeleted = false,
                            Name = "МЗ"
                        },
                        new
                        {
                            Id = new Guid("a2818899-4c4d-4e88-a1cc-f24bf956e826"),
                            IsDeleted = false,
                            Name = "Лекция"
                        });
                });

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("DisciplinesAPI.Models.DBModels.VideoCourses", b =>
                {
                    b.Navigation("Video");
                });

            modelBuilder.Entity("DisciplinesAPI.Models.Disciplines", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
