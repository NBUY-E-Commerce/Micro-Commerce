using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ProductSpacialAreas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleteDateTime",
                table: "ProductSpacialAreas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deleteUserId",
                table: "ProductSpacialAreas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "insertDateTime",
                table: "ProductSpacialAreas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "insertUserId",
                table: "ProductSpacialAreas",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ProductSpacialAreas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "ProductSpacialAreas");

            migrationBuilder.DropColumn(
                name: "deleteDateTime",
                table: "ProductSpacialAreas");

            migrationBuilder.DropColumn(
                name: "deleteUserId",
                table: "ProductSpacialAreas");

            migrationBuilder.DropColumn(
                name: "insertDateTime",
                table: "ProductSpacialAreas");

            migrationBuilder.DropColumn(
                name: "insertUserId",
                table: "ProductSpacialAreas");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ProductSpacialAreas");
        }
    }
}
