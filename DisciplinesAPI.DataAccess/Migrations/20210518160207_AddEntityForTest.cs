using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisciplinesAPI.DataAccess.Migrations
{
    public partial class AddEntityForTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Disciplines_DisciplinesId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_LessonTypes_LessonTypeId",
                table: "Lessons");

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("23e26f72-551e-4c62-83d4-5adc6f192e71"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("73478736-ce2e-4fd0-8bf9-b75cf8dc9d9e"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("7db5f424-a598-483c-a7a5-353686a2f25e"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("c3d9d14c-c763-4b04-936e-c81e3f8cdbe9"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("d7ecf5eb-26eb-4209-a6e3-2c73c090aad0"));

            migrationBuilder.RenameColumn(
                name: "name",
                table: "LessonTypes",
                newName: "Name");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonTypeId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplinesId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    DisciplinesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTrue = table.Column<bool>(type: "bit", nullable: false),
                    QuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LessonTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8aa1098e-1010-4c7f-a3c8-e244ad6a7ea2"), "ПЗ" },
                    { new Guid("c10db1d4-1564-46c6-9442-5e597f63fa7f"), "ГЗ" },
                    { new Guid("02bbd981-3b45-4d4b-abc3-f4c7fc5baf56"), "СЕМ" },
                    { new Guid("d9e3f695-70f7-4d27-8335-141969d00361"), "МЗ" },
                    { new Guid("34d58776-25c9-4d05-b4c4-544aae8e201d"), "Лекция" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsId",
                table: "Answers",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DisciplinesId",
                table: "Questions",
                column: "DisciplinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Disciplines_DisciplinesId",
                table: "Lessons",
                column: "DisciplinesId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_LessonTypes_LessonTypeId",
                table: "Lessons",
                column: "LessonTypeId",
                principalTable: "LessonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Disciplines_DisciplinesId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_LessonTypes_LessonTypeId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("02bbd981-3b45-4d4b-abc3-f4c7fc5baf56"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("34d58776-25c9-4d05-b4c4-544aae8e201d"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("8aa1098e-1010-4c7f-a3c8-e244ad6a7ea2"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("c10db1d4-1564-46c6-9442-5e597f63fa7f"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("d9e3f695-70f7-4d27-8335-141969d00361"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LessonTypes",
                newName: "name");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonTypeId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplinesId",
                table: "Lessons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "LessonTypes",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { new Guid("73478736-ce2e-4fd0-8bf9-b75cf8dc9d9e"), "ПЗ" },
                    { new Guid("23e26f72-551e-4c62-83d4-5adc6f192e71"), "ГЗ" },
                    { new Guid("c3d9d14c-c763-4b04-936e-c81e3f8cdbe9"), "СЕМ" },
                    { new Guid("7db5f424-a598-483c-a7a5-353686a2f25e"), "МЗ" },
                    { new Guid("d7ecf5eb-26eb-4209-a6e3-2c73c090aad0"), "Лекция" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Disciplines_DisciplinesId",
                table: "Lessons",
                column: "DisciplinesId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_LessonTypes_LessonTypeId",
                table: "Lessons",
                column: "LessonTypeId",
                principalTable: "LessonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
