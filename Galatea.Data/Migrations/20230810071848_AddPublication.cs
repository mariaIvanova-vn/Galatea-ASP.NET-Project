using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galatea.Data.Migrations
{
    public partial class AddPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_AspNetUsers_Id",
                table: "Publications");

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "IsActive", "Title", "UserId" },
                values: new object[] { new Guid("3fccdf54-22c5-47f2-ab6a-fc987d16d704"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 8, 10, 10, 18, 47, 924, DateTimeKind.Local).AddTicks(1588), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", true, "Търся персонал", new Guid("4305f537-df35-473e-aebc-97c32ade996c") });

            migrationBuilder.CreateIndex(
                name: "IX_Publications_UserId",
                table: "Publications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_AspNetUsers_UserId",
                table: "Publications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_AspNetUsers_UserId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_UserId",
                table: "Publications");

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("3fccdf54-22c5-47f2-ab6a-fc987d16d704"));

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_AspNetUsers_Id",
                table: "Publications",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
