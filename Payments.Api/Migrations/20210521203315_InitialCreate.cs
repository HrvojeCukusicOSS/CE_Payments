using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTests",
                columns: table => new
                {
                    UserTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTestNamse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTests", x => x.UserTestId);
                });

            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "UserTestId", "Age", "UserTestNamse" },
                values: new object[] { 1, 29, "Potato" });

            migrationBuilder.InsertData(
                table: "UserTests",
                columns: new[] { "UserTestId", "Age", "UserTestNamse" },
                values: new object[] { 2, 10, "Batman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTests");
        }
    }
}
