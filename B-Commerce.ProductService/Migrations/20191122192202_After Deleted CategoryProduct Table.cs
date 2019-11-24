using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class AfterDeletedCategoryProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MasterCategory_MCID",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterCategory",
                table: "MasterCategory");

            migrationBuilder.RenameTable(
                name: "MasterCategory",
                newName: "MasterCategories");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "MasterCategories",
                newName: "DeletedCategory");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "MasterCategories",
                newName: "IsActiveCategory");

            migrationBuilder.RenameColumn(
                name: "insertDateTime",
                table: "MasterCategories",
                newName: "I_DateTime");

            migrationBuilder.RenameColumn(
                name: "deleteDateTime",
                table: "MasterCategories",
                newName: "D_DateTime");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "MasterCategories",
                newName: "CategoryDesc");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "MasterCategories",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DeletedCategory",
                table: "MasterCategories",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActiveCategory",
                table: "MasterCategories",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryDesc",
                table: "MasterCategories",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterCategories",
                table: "MasterCategories",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryID",
                table: "Products",
                column: "SubCategoryID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterCategories",
                table: "MasterCategories");

            migrationBuilder.DropColumn(
                name: "SubCategoryID",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "MasterCategories",
                newName: "MasterCategory");

            migrationBuilder.RenameColumn(
                name: "DeletedCategory",
                table: "MasterCategory",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActiveCategory",
                table: "MasterCategory",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "I_DateTime",
                table: "MasterCategory",
                newName: "insertDateTime");

            migrationBuilder.RenameColumn(
                name: "D_DateTime",
                table: "MasterCategory",
                newName: "deleteDateTime");

            migrationBuilder.RenameColumn(
                name: "CategoryDesc",
                table: "MasterCategory",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "MasterCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "isDeleted",
                table: "MasterCategory",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "MasterCategory",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MasterCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterCategory",
                table: "MasterCategory",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoryID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductID",
                table: "CategoryProduct",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MasterCategory_MCID",
                table: "Categories",
                column: "MCID",
                principalTable: "MasterCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
