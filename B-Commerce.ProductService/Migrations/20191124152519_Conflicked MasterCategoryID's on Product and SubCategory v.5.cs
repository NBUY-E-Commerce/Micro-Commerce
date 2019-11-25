using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class ConflickedMasterCategoryIDsonProductandSubCategoryv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_MasterCategoryID1",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MasterCategoryID1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MasterCategoryID1",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID1",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryID1",
                table: "Products",
                column: "SubCategoryID1",
                unique: true,
                filter: "[SubCategoryID1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_SubCategoryID",
                table: "Products",
                column: "SubCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_SubCategoryID1",
                table: "Products",
                column: "SubCategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_SubCategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_SubCategoryID1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryID1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryID1",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MasterCategoryID1",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MasterCategoryID1",
                table: "Categories",
                column: "MasterCategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_MasterCategoryID1",
                table: "Categories",
                column: "MasterCategoryID1",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
