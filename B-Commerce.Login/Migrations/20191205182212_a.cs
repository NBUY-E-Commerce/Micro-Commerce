using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.Login.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 401,
                column: "insertDateTime",
                value: new DateTime(2019, 12, 5, 21, 22, 10, 493, DateTimeKind.Local).AddTicks(3725));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 401,
                column: "insertDateTime",
                value: new DateTime(2019, 12, 5, 21, 9, 58, 326, DateTimeKind.Local).AddTicks(7778));
        }
    }
}
