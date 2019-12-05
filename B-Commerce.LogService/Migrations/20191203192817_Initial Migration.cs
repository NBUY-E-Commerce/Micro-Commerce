using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.LogService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "LogInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogInfo = table.Column<string>(nullable: false),
                    LogInsertDate = table.Column<DateTime>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LogInfos_ProjectInfos_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogInfos");

            migrationBuilder.DropTable(
                name: "ProjectOwners");

            migrationBuilder.DropTable(
                name: "ProjectInfos");
        }
    }
}
