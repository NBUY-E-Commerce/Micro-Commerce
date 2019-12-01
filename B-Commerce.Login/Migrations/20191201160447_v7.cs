using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.Login.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PasswordChanges_UserID",
                table: "PasswordChanges");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordChanges_UserID",
                table: "PasswordChanges",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PasswordChanges_UserID",
                table: "PasswordChanges");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordChanges_UserID",
                table: "PasswordChanges",
                column: "UserID",
                unique: true);
        }
    }
}
