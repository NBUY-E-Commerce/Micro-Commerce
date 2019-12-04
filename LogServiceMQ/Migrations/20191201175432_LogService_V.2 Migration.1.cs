using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogService.Migrations
{
    public partial class LogService_V2Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogInfoMessage",
                table: "LogInfos",
                newName: "LogInfo");

            migrationBuilder.RenameColumn(
                name: "LogID",
                table: "LogInfos",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "LogInfo",
                table: "LogInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogInsertDate",
                table: "LogInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "LogInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjectInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    qeueName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectOwners",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    IsRequestEmail = table.Column<bool>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OwnerID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectOwners_ProjectInfos_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProjectInfos",
                columns: new[] { "ID", "Password", "ProjectCode", "qeueName" },
                values: new object[] { 1, "admin", "code", "queue" });

            migrationBuilder.InsertData(
                table: "ProjectOwners",
                columns: new[] { "ID", "Email", "IsRequestEmail", "ProjectID" },
                values: new object[] { 1, "hacimu@gmail.com", true, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_LogInfos_ProjectID",
                table: "LogInfos",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectOwners_ProjectID",
                table: "ProjectOwners",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_LogInfos_ProjectInfos_ProjectID",
                table: "LogInfos",
                column: "ProjectID",
                principalTable: "ProjectInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogInfos_ProjectInfos_ProjectID",
                table: "LogInfos");

            migrationBuilder.DropTable(
                name: "ProjectOwners");

            migrationBuilder.DropTable(
                name: "ProjectInfos");

            migrationBuilder.DropIndex(
                name: "IX_LogInfos_ProjectID",
                table: "LogInfos");

            migrationBuilder.DropColumn(
                name: "LogInsertDate",
                table: "LogInfos");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "LogInfos");

            migrationBuilder.RenameColumn(
                name: "LogInfo",
                table: "LogInfos",
                newName: "LogInfoMessage");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LogInfos",
                newName: "LogID");

            migrationBuilder.AlterColumn<string>(
                name: "LogInfoMessage",
                table: "LogInfos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
