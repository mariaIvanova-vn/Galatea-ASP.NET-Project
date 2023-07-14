using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galatea.Data.Migrations
{
    public partial class AddDateTimeConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("a5005d6f-0e06-44ee-9fd6-572c14bc14cb"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Publications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 12, 10, 44, 22, 822, DateTimeKind.Utc).AddTicks(2969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "Title", "UserId" },
                values: new object[] { new Guid("2257d2d3-b316-4f14-bd72-d9bb2cb6ed79"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 7, 12, 13, 44, 22, 822, DateTimeKind.Local).AddTicks(5750), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", "Търся персонал", new Guid("2f0ff2d4-b657-4cb5-3c99-08db81f0bbc7") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("2257d2d3-b316-4f14-bd72-d9bb2cb6ed79"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Publications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 12, 10, 44, 22, 822, DateTimeKind.Utc).AddTicks(2969));

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "Title", "UserId" },
                values: new object[] { new Guid("a5005d6f-0e06-44ee-9fd6-572c14bc14cb"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 7, 11, 16, 4, 22, 455, DateTimeKind.Local).AddTicks(262), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", "Търся персонал", new Guid("2f0ff2d4-b657-4cb5-3c99-08db81f0bbc7") });
        }
    }
}
