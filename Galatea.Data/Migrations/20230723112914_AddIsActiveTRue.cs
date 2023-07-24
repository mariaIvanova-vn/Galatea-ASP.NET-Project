using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galatea.Data.Migrations
{
    public partial class AddIsActiveTRue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("9f487dad-7013-44f0-8019-55a4a2cea65d"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Publications",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "Title", "UserId" },
                values: new object[] { new Guid("f4adb3f2-943e-4769-aaec-0c5af88d9969"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 7, 23, 14, 29, 14, 490, DateTimeKind.Local).AddTicks(2799), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", "Търся персонал", new Guid("2f0ff2d4-b657-4cb5-3c99-08db81f0bbc7") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("f4adb3f2-943e-4769-aaec-0c5af88d9969"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Publications");

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "Title", "UserId" },
                values: new object[] { new Guid("9f487dad-7013-44f0-8019-55a4a2cea65d"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 7, 23, 13, 35, 25, 808, DateTimeKind.Local).AddTicks(3012), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", "Търся персонал", new Guid("2f0ff2d4-b657-4cb5-3c99-08db81f0bbc7") });
        }
    }
}
