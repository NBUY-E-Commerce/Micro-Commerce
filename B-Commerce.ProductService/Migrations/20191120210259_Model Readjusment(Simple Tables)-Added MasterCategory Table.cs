using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class ModelReadjusmentSimpleTablesAddedMasterCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MCID",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MasterCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCategory", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MCID",
                table: "Categories",
                column: "MCID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MasterCategory_MCID",
                table: "Categories",
                column: "MCID",
                principalTable: "MasterCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MasterCategory_MCID",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "MasterCategory");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MCID",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "MCID",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
