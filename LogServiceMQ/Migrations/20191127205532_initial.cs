using Microsoft.EntityFrameworkCore.Migrations;

namespace LogService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogInfos",
                columns: table => new
                {
                    LogInfoID = table.Column<string>(nullable: false),
                    LogInfoMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInfos", x => x.LogInfoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogInfos");
        }
    }
}
