using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galatea.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("f4adb3f2-943e-4769-aaec-0c5af88d9969"));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "Title", "UserId" },
                values: new object[] { new Guid("dc1af0df-b3d3-4684-bd93-55e1a0f14b89"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 8, 3, 12, 41, 13, 509, DateTimeKind.Local).AddTicks(2837), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", "Търся персонал", new Guid("2f0ff2d4-b657-4cb5-3c99-08db81f0bbc7") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("dc1af0df-b3d3-4684-bd93-55e1a0f14b89"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "IsActive", "Title", "UserId" },
                values: new object[] { new Guid("f4adb3f2-943e-4769-aaec-0c5af88d9969"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 7, 23, 14, 29, 14, 490, DateTimeKind.Local).AddTicks(2799), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", false, "Търся персонал", new Guid("2f0ff2d4-b657-4cb5-3c99-08db81f0bbc7") });
        }
    }
}
