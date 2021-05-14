using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisciplinesAPI.DataAccess.Migrations
{
    public partial class AddSeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
