using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.NotificationService.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectPermissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectCode = table.Column<string>(nullable: true),
                    OwnerMail = table.Column<string>(nullable: true),
                    OwnerPhone = table.Column<string>(nullable: true),
                    isBanned = table.Column<bool>(nullable: false),
                    DailyMailCount = table.Column<int>(nullable: false),
                    DailySmsCount = table.Column<int>(nullable: false),
                    MaxMailLimit = table.Column<int>(nullable: false),
                    MaxSmsLimit = table.Column<int>(nullable: false),
                    MailAuthorization = table.Column<bool>(nullable: false),
                    SmsAuthorization = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPermissions", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPermissions");
        }
    }
}
