using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.LogService.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qeueName",
                table: "ProjectInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "qeueName",
                table: "ProjectInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProjectInfos",
                keyColumn: "ID",
                keyValue: 1,
                column: "qeueName",
                value: "queue");
        }
    }
}
