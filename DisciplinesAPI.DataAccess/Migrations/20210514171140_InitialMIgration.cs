using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisciplinesAPI.DataAccess.Migrations
{
    public partial class InitialMIgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountHours = table.Column<int>(type: "int", nullable: false),
                    CountHoursGZ = table.Column<int>(type: "int", nullable: false),
                    CountHoursPZ = table.Column<int>(type: "int", nullable: false),
                    CountHoursLeck = table.Column<int>(type: "int", nullable: false),
                    CountHoursSEM = table.Column<int>(type: "int", nullable: false),
                    CountHoursLR = table.Column<int>(type: "int", nullable: false),
                    CountHoursMZ = table.Column<int>(type: "int", nullable: false),
                    CountHoursTest = table.Column<int>(type: "int", nullable: false),
                    CountHoursСontrolWork = table.Column<int>(type: "int", nullable: false),
                    CountHoursSWZ = table.Column<int>(type: "int", nullable: false),
                    IsExam = table.Column<bool>(type: "bit", nullable: false),
                    DateOfPlan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountNorm = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Plan = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GPID = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThemeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountHours = table.Column<int>(type: "int", nullable: false),
                    CurrentNumberOflessonsType = table.Column<int>(type: "int", nullable: false),
                    MethodicMaterials = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AdditionalMaterial = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Presentation = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LessonTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisciplinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_LessonTypes_LessonTypeId",
                        column: x => x.LessonTypeId,
                        principalTable: "LessonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoCoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_VideoCourses_VideoCoursesId",
                        column: x => x.VideoCoursesId,
                        principalTable: "VideoCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DisciplinesId",
                table: "Lessons",
                column: "DisciplinesId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonTypeId",
                table: "Lessons",
                column: "LessonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoCoursesId",
                table: "Videos",
                column: "VideoCoursesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "LessonTypes");

            migrationBuilder.DropTable(
                name: "VideoCourses");
        }
    }
}
