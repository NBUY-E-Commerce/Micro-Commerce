using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.NotificationService.Migrations
{
    public partial class isbanned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectCode",
                table: "ProjectPermissions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isBanned",
                table: "ProjectPermissions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "ProjectPermissions");

            migrationBuilder.DropColumn(
                name: "isBanned",
                table: "ProjectPermissions");
        }
    }
}
