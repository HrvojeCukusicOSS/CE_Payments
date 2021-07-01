using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class HCJobApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConformationTable",
                columns: new[] { "ConformationID", "JobListId", "PriceCheck" },
                values: new object[] { 1, 1, 775m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConformationTable",
                keyColumn: "ConformationID",
                keyValue: 1);
        }
    }
}
