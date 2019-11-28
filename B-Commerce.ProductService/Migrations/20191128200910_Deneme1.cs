using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class Deneme1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletedCategory = table.Column<bool>(nullable: false, defaultValue: false),
                    I_DateTime = table.Column<DateTime>(nullable: false),
                    D_DateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    CategoryDesc = table.Column<string>(maxLength: 250, nullable: true),
                    IsActiveCategory = table.Column<bool>(nullable: false, defaultValue: true),
                    MasterCategoryID = table.Column<int>(nullable: true),
                    SubCategoryID = table.Column<int>(nullable: false),
                    CategoryID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryID1",
                        column: x => x.CategoryID1,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeletedProduct = table.Column<bool>(nullable: false, defaultValue: false),
                    I_DateTime = table.Column<DateTime>(nullable: false),
                    D_DateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 250, nullable: false),
                    ProductDesc = table.Column<string>(maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    AvailableCount = table.Column<int>(nullable: false),
                    IsActiveProduct = table.Column<bool>(nullable: false, defaultValue: true),
                    PercentageDiscount = table.Column<float>(nullable: true),
                    SpecialOfferPrice = table.Column<decimal>(nullable: true),
                    SpecialOfferMinimumQuantity = table.Column<float>(nullable: true),
                    SpecialOfferMaximumQuantity = table.Column<float>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeletedImage = table.Column<bool>(nullable: false, defaultValue: false),
                    I_DateTime = table.Column<DateTime>(nullable: false),
                    D_DateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    URL = table.Column<string>(maxLength: 250, nullable: false),
                    ImageDesc = table.Column<string>(maxLength: 250, nullable: true),
                    IsActiveImage = table.Column<bool>(nullable: false, defaultValue: true),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryID1",
                table: "Categories",
                column: "CategoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
