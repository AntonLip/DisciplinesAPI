using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisciplinesAPI.DataAccess.Migrations
{
    public partial class AddRefInLesson : Migration
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

            migrationBuilder.InsertData(
                table: "LessonTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3bb58019-6ded-449a-ae1d-040d29eb2bc2"), "ПЗ" },
                    { new Guid("4788c0ab-8856-4106-8aa2-0ab0889ec3c5"), "ГЗ" },
                    { new Guid("929eaa79-3bd1-450c-83c1-efb761bdb6b9"), "СЕМ" },
                    { new Guid("d2d2208b-d377-49b5-b3d0-3afff9c569a5"), "МЗ" },
                    { new Guid("5444afec-c260-40d3-8173-786a1220376d"), "Лекция" }
                });

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

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("3bb58019-6ded-449a-ae1d-040d29eb2bc2"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("4788c0ab-8856-4106-8aa2-0ab0889ec3c5"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("5444afec-c260-40d3-8173-786a1220376d"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("929eaa79-3bd1-450c-83c1-efb761bdb6b9"));

            migrationBuilder.DeleteData(
                table: "LessonTypes",
                keyColumn: "Id",
                keyValue: new Guid("d2d2208b-d377-49b5-b3d0-3afff9c569a5"));

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
