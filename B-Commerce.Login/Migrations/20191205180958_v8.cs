using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.Login.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Adress", "City", "Country", "Email", "IsLocked", "IsVerified", "LockedTime", "Name", "Password", "Phone", "Surname", "Username", "WrongCount", "deleteDateTime", "deleteUserId", "insertDateTime", "insertUserId", "isDeleted" },
                values: new object[] { 401, null, null, null, "asd123gqwerqga14sdAS4asf5@asdasfa!@$ASFyase3hiy.com", false, true, null, "Visitor", "bcommerce", null, "Bcommerce", "Visitor", 0, null, null, new DateTime(2019, 12, 5, 21, 9, 58, 326, DateTimeKind.Local).AddTicks(7778), null, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 401);
        }
    }
}
