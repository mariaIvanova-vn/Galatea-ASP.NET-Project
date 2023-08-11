using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Galatea.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Publications_PublicationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Publications_PublicationId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_PublicationId",
                table: "Ratings");

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("3fccdf54-22c5-47f2-ab6a-fc987d16d704"));

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "IsActive", "Title", "UserId" },
                values: new object[] { new Guid("5ddeab18-e375-491a-aa27-362618e3e7bd"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 8, 10, 10, 40, 25, 411, DateTimeKind.Local).AddTicks(9341), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", true, "Търся персонал", new Guid("4305f537-df35-473e-aebc-97c32ade996c") });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Publications_PublicationId",
                table: "Comments",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Publications_Id",
                table: "Ratings",
                column: "Id",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Publications_PublicationId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Publications_Id",
                table: "Ratings");

            migrationBuilder.DeleteData(
                table: "Publications",
                keyColumn: "Id",
                keyValue: new Guid("5ddeab18-e375-491a-aa27-362618e3e7bd"));

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedOn", "ImageUrl", "IsActive", "Title", "UserId" },
                values: new object[] { new Guid("3fccdf54-22c5-47f2-ab6a-fc987d16d704"), 2, "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888", new DateTime(2023, 8, 10, 10, 18, 47, 924, DateTimeKind.Local).AddTicks(1588), "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG", true, "Търся персонал", new Guid("4305f537-df35-473e-aebc-97c32ade996c") });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PublicationId",
                table: "Ratings",
                column: "PublicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Publications_PublicationId",
                table: "Comments",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Publications_PublicationId",
                table: "Ratings",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id");
        }
    }
}
