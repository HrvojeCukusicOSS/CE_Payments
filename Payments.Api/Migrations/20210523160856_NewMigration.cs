using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Api.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumn: "UserTestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTests",
                keyColumn: "UserTestId",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "UserTestId", "Age", "Nickname", "UserTestNamse" },
                values: new object[] { 1, 29, null, "Potato" });

            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "UserTestId", "Age", "Nickname", "UserTestNamse" },
                values: new object[] { 2, 10, null, "Batman" });
        }
    }
}
