using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisciplinesAPI.DataAccess.Migrations
{
    public partial class AddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Videos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VideoCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LessonTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Disciplines",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VideoCourses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Disciplines");

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
        }
    }
}
