using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Api.Migrations
{
    public partial class NewUserField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "UserTests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "UserTests");
        }
    }
}
