using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class ModelReadjusmentSimpleTables2AddedMasterCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedProduct",
                table: "Products",
                newName: "IsDeletedProduct");

            migrationBuilder.RenameColumn(
                name: "ActiveProduct",
                table: "Products",
                newName: "IsActiveProduct");

            migrationBuilder.RenameColumn(
                name: "DeletedImage",
                table: "ProductImages",
                newName: "IsDeletedImage");

            migrationBuilder.RenameColumn(
                name: "ActiveImage",
                table: "ProductImages",
                newName: "IsActiveImage");

            migrationBuilder.RenameColumn(
                name: "ActiveCategory",
                table: "Categories",
                newName: "IsActiveCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeletedProduct",
                table: "Products",
                newName: "DeletedProduct");

            migrationBuilder.RenameColumn(
                name: "IsActiveProduct",
                table: "Products",
                newName: "ActiveProduct");

            migrationBuilder.RenameColumn(
                name: "IsDeletedImage",
                table: "ProductImages",
                newName: "DeletedImage");

            migrationBuilder.RenameColumn(
                name: "IsActiveImage",
                table: "ProductImages",
                newName: "ActiveImage");

            migrationBuilder.RenameColumn(
                name: "IsActiveCategory",
                table: "Categories",
                newName: "ActiveCategory");
        }
    }
}
