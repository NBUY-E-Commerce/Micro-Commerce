using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class shoppingcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "deleteDateTime",
                table: "ShoppingCartProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deleteUserId",
                table: "ShoppingCartProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "insertDateTime",
                table: "ShoppingCartProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "insertUserId",
                table: "ShoppingCartProducts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ShoppingCartProducts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleteDateTime",
                table: "ShoppingCartProducts");

            migrationBuilder.DropColumn(
                name: "deleteUserId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropColumn(
                name: "insertDateTime",
                table: "ShoppingCartProducts");

            migrationBuilder.DropColumn(
                name: "insertUserId",
                table: "ShoppingCartProducts");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ShoppingCartProducts");
        }
    }
}
