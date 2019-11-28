using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogService.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LogInfos",
                table: "LogInfos");

            migrationBuilder.DropColumn(
                name: "LogInfoID",
                table: "LogInfos");

            migrationBuilder.AddColumn<int>(
                name: "LogID",
                table: "LogInfos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogInfos",
                table: "LogInfos",
                column: "LogID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LogInfos",
                table: "LogInfos");

            migrationBuilder.DropColumn(
                name: "LogID",
                table: "LogInfos");

            migrationBuilder.AddColumn<string>(
                name: "LogInfoID",
                table: "LogInfos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogInfos",
                table: "LogInfos",
                column: "LogInfoID");
        }
    }
}
