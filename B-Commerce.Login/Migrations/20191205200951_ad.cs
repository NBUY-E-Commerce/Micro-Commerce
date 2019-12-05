using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.Login.Migrations
{
    public partial class ad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Adress", "City", "Country", "Email", "IsLocked", "IsVerified", "LockedTime", "Name", "Password", "Phone", "Surname", "Username", "WrongCount", "deleteDateTime", "deleteUserId", "insertDateTime", "insertUserId", "isDeleted" },
                values: new object[] { 123, null, null, null, "asd123gqwerqga14sdAS4asf5@asdasfa!@$ASFyase3hiy.com", false, true, null, "Visitor", "bcommerce", null, "Bcommerce", "Visitor", 0, null, null, new DateTime(2019, 12, 5, 23, 9, 50, 146, DateTimeKind.Local).AddTicks(9840), null, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 123);
        }
    }
}
