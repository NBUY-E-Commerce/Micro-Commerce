using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.Login.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SocialTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Country = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 20, nullable: true),
                    Adress = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 12, nullable: true),
                    WrongCount = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    LockedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountVerifications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    VerificationCode = table.Column<string>(maxLength: 6, nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    ExpireTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountVerifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountVerifications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordChanges",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    ChangeCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordChanges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PasswordChanges_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialID = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    SocialTypeID = table.Column<int>(nullable: false),
                    AccessToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SocialInfos_SocialTypes_SocialTypeID",
                        column: x => x.SocialTypeID,
                        principalTable: "SocialTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialInfos_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    TokenText = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountVerifications_UserID",
                table: "AccountVerifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordChanges_UserID",
                table: "PasswordChanges",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SocialInfos_SocialTypeID",
                table: "SocialInfos",
                column: "SocialTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SocialInfos_UserID",
                table: "SocialInfos",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserID",
                table: "Tokens",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountVerifications");

            migrationBuilder.DropTable(
                name: "PasswordChanges");

            migrationBuilder.DropTable(
                name: "SocialInfos");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "SocialTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
