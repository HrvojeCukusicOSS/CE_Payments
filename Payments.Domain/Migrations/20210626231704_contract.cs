using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class contract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    IdContract = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciversName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfPayments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPayments = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntrestPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PenaltyPErcentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.IdContract);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
