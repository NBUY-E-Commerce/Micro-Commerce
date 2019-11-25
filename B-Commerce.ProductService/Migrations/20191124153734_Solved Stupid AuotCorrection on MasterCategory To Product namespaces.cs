using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class SolvedStupidAuotCorrectiononMasterCategoryToProductnamespaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MasterCategories_MasterCategoryID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_SubCategoryID1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryID1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MasterCategoryID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubCategoryID1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MasterCategoryID",
                table: "Categories");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MasterCategories_MCID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MCID",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterCategoryID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryID1",
                table: "Products",
                column: "SubCategoryID1",
                unique: true,
                filter: "[SubCategoryID1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MasterCategoryID",
                table: "Categories",
                column: "MasterCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MasterCategories_MasterCategoryID",
                table: "Categories",
                column: "MasterCategoryID",
                principalTable: "MasterCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_SubCategoryID1",
                table: "Products",
                column: "SubCategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
