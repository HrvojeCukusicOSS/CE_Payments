using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class contract1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "IdContract", "EndDate", "IntrestPercentage", "IsActivated", "NumberOfPayments", "PayersName", "PenaltyPErcentage", "ReciversName", "StartDate", "TermsOfPayments" },
                values: new object[] { 10, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "5.0", false, 1, "eaaav@gad", "7.5", "asdf@gad", new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Payment" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "IdContract",
                keyValue: 10);
        }
    }
}
