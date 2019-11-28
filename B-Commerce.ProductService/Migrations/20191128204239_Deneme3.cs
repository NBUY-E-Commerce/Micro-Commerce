using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class Deneme3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpacialAreas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpacialAreas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpacialAreas",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    SpacialAreaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpacialAreas", x => new { x.ProductID, x.SpacialAreaID });
                    table.ForeignKey(
                        name: "FK_ProductSpacialAreas_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpacialAreas_SpacialAreas_SpacialAreaID",
                        column: x => x.SpacialAreaID,
                        principalTable: "SpacialAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpacialAreas_SpacialAreaID",
                table: "ProductSpacialAreas",
                column: "SpacialAreaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSpacialAreas");

            migrationBuilder.DropTable(
                name: "SpacialAreas");
        }
    }
}
