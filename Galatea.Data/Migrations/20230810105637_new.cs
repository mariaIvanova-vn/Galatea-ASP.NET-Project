using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galatea.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("dff5f044-7a8b-4ba6-b197-ff5bfc4cb4c5"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "IsActive", "Title", "UserId" },
                values: new object[] { new Guid("ba278fce-d97d-4cd1-8030-3dcc3dac49a2"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 8, 10, 13, 56, 36, 879, DateTimeKind.Local).AddTicks(8193), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", true, "Търся персонал", new Guid("4305f537-df35-473e-aebc-97c32ade996c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("ba278fce-d97d-4cd1-8030-3dcc3dac49a2"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "IsActive", "Title", "UserId" },
                values: new object[] { new Guid("dff5f044-7a8b-4ba6-b197-ff5bfc4cb4c5"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 8, 10, 13, 1, 27, 816, DateTimeKind.Local).AddTicks(1106), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", true, "Търся персонал", new Guid("4305f537-df35-473e-aebc-97c32ade996c") });
        }
    }
}
