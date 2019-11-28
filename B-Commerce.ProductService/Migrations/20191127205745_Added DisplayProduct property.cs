using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class AddedDisplayProductproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDisplayProduct",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDisplayProduct",
                table: "Products");
        }
    }
}
