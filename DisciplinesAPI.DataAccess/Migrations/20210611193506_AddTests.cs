using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisciplinesAPI.DataAccess.Migrations
{
    public partial class AddTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "VideoCourses");

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("2cb8a9d0-3f00-4f38-8a66-65403f3a0fe2"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("2de4aa61-c511-4d6b-a451-0760a61e550e"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("9da7f782-3978-49f4-ba90-bb042e94ef3c"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("a2818899-4c4d-4e88-a1cc-f24bf956e826"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("f3ccdee6-c89b-4eb9-b7ff-01c7101df404"));

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DisciplinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTrue = table.Column<bool>(type: "bit", nullable: false),
                    QuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LessonTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("215819a9-97c1-4ac1-bca6-0ae78d2a4074"), false, "ПЗ" },
                    { new Guid("3efe08e5-c66f-4579-a3a0-7faa56750c67"), false, "ГЗ" },
                    { new Guid("1685b84d-51a2-491c-9823-99ff16cc0a54"), false, "СЕМ" },
                    { new Guid("bdb79589-858d-4c10-bf89-5ef8b04c4a53"), false, "МЗ" },
                    { new Guid("5e5b108f-731d-4a35-ae1c-c8c7b955e963"), false, "Лекция" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsId",
                table: "Answers",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DisciplinesId",
                table: "Questions",
                column: "DisciplinesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("1685b84d-51a2-491c-9823-99ff16cc0a54"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("215819a9-97c1-4ac1-bca6-0ae78d2a4074"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("3efe08e5-c66f-4579-a3a0-7faa56750c67"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("5e5b108f-731d-4a35-ae1c-c8c7b955e963"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("bdb79589-858d-4c10-bf89-5ef8b04c4a53"));

            migrationBuilder.CreateTable(
                name: "VideoCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.InsertData(
                table: "LessonTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("2cb8a9d0-3f00-4f38-8a66-65403f3a0fe2"), false, "ПЗ" },
                    { new Guid("9da7f782-3978-49f4-ba90-bb042e94ef3c"), false, "ГЗ" },
                    { new Guid("f3ccdee6-c89b-4eb9-b7ff-01c7101df404"), false, "СЕМ" },
                    { new Guid("2de4aa61-c511-4d6b-a451-0760a61e550e"), false, "МЗ" },
                    { new Guid("a2818899-4c4d-4e88-a1cc-f24bf956e826"), false, "Лекция" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoCoursesId",
                table: "Videos",
                column: "VideoCoursesId");
        }
    }
}
