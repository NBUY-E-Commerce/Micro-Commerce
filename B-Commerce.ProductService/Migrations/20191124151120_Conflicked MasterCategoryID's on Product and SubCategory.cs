using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class ConflickedMasterCategoryIDsonProductandSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MasterCategories_MCID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_SubCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MCID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubCategoryID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MasterCategoryID",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterCategoryID1",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MasterCategoryID",
                table: "Categories",
                column: "MasterCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MasterCategoryID1",
                table: "Categories",
                column: "MasterCategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MasterCategories_MasterCategoryID",
                table: "Categories",
                column: "MasterCategoryID",
                principalTable: "MasterCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MasterCategories_MasterCategoryID",
                table: "Categories");

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
                name: "IX_Categories_MasterCategoryID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MasterCategoryID1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MasterCategoryID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MasterCategoryID1",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MCID",
                table: "Categories",
                column: "MCID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MasterCategories_MCID",
                table: "Categories",
                column: "MCID",
                principalTable: "MasterCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_SubCategoryID",
                table: "Products",
                column: "SubCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
