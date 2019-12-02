using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogService.Migrations
{
    public partial class LogService_V2Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "deleteDateTime",
                table: "ProjectOwners",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deleteUserId",
                table: "ProjectOwners",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "insertDateTime",
                table: "ProjectOwners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "insertUserId",
                table: "ProjectOwners",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ProjectOwners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleteDateTime",
                table: "ProjectInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deleteUserId",
                table: "ProjectInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "insertDateTime",
                table: "ProjectInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "insertUserId",
                table: "ProjectInfos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ProjectInfos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleteDateTime",
                table: "LogInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deleteUserId",
                table: "LogInfos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "insertUserId",
                table: "LogInfos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "LogInfos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProjectInfos",
                keyColumn: "ID",
                keyValue: 1,
                column: "insertDateTime",
                value: new DateTime(2019, 12, 1, 21, 56, 40, 347, DateTimeKind.Local).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "ProjectOwners",
                keyColumn: "ID",
                keyValue: 1,
                column: "insertDateTime",
                value: new DateTime(2019, 12, 1, 21, 56, 40, 358, DateTimeKind.Local).AddTicks(810));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleteDateTime",
                table: "ProjectOwners");

            migrationBuilder.DropColumn(
                name: "deleteUserId",
                table: "ProjectOwners");

            migrationBuilder.DropColumn(
                name: "insertDateTime",
                table: "ProjectOwners");

            migrationBuilder.DropColumn(
                name: "insertUserId",
                table: "ProjectOwners");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ProjectOwners");

            migrationBuilder.DropColumn(
                name: "deleteDateTime",
                table: "ProjectInfos");

            migrationBuilder.DropColumn(
                name: "deleteUserId",
                table: "ProjectInfos");

            migrationBuilder.DropColumn(
                name: "insertDateTime",
                table: "ProjectInfos");

            migrationBuilder.DropColumn(
                name: "insertUserId",
                table: "ProjectInfos");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ProjectInfos");

            migrationBuilder.DropColumn(
                name: "deleteDateTime",
                table: "LogInfos");

            migrationBuilder.DropColumn(
                name: "deleteUserId",
                table: "LogInfos");

            migrationBuilder.DropColumn(
                name: "insertUserId",
                table: "LogInfos");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "LogInfos");
        }
    }
}
