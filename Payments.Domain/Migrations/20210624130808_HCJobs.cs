using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class HCJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConformationID",
                table: "FinalBill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConformationTable",
                table: "FinalBill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobsListJobListID",
                table: "FinalBill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobsTableJobsID",
                table: "FinalBill",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobsTable",
                columns: table => new
                {
                    JobsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsTable", x => x.JobsID);
                });

            migrationBuilder.CreateTable(
                name: "JobsList",
                columns: table => new
                {
                    JobListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobsID = table.Column<int>(type: "int", nullable: false),
                    PayerConformation = table.Column<bool>(type: "bit", nullable: false),
                    ReciverConformation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsList", x => x.JobListID);
                    table.ForeignKey(
                        name: "FK_JobsList_JobsTable_JobsID",
                        column: x => x.JobsID,
                        principalTable: "JobsTable",
                        principalColumn: "JobsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConformationTable",
                columns: table => new
                {
                    ConformationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobListID = table.Column<int>(type: "int", nullable: false),
                    PriceCheck = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConformationTable", x => x.ConformationID);
                    table.ForeignKey(
                        name: "FK_ConformationTable_JobsList_JobListID",
                        column: x => x.JobListID,
                        principalTable: "JobsList",
                        principalColumn: "JobListID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "FinalBill",
                keyColumn: "IdFinalBill",
                keyValue: 1,
                column: "ConformationID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FinalBill",
                keyColumn: "IdFinalBill",
                keyValue: 2,
                column: "ConformationID",
                value: 1);

            migrationBuilder.InsertData(
                table: "JobsTable",
                columns: new[] { "JobsID", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Writes code for apps", "Software Developer", 225m },
                    { 2, "Supervises developers", "IT Manager", 550m }
                });

            migrationBuilder.InsertData(
                table: "JobsList",
                columns: new[] { "JobListID", "JobsID", "PayerConformation", "ReciverConformation" },
                values: new object[] { 1, 1, true, true });

            migrationBuilder.InsertData(
                table: "ConformationTable",
                columns: new[] { "ConformationID", "JobListID", "PriceCheck" },
                values: new object[] { 1, 1, 775m });

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_ConformationTable",
                table: "FinalBill",
                column: "ConformationTable");

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_JobsListJobListID",
                table: "FinalBill",
                column: "JobsListJobListID");

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_JobsTableJobsID",
                table: "FinalBill",
                column: "JobsTableJobsID");

            migrationBuilder.CreateIndex(
                name: "IX_ConformationTable_JobListID",
                table: "ConformationTable",
                column: "JobListID");

            migrationBuilder.CreateIndex(
                name: "IX_JobsList_JobsID",
                table: "JobsList",
                column: "JobsID");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalBill_ConformationTable_ConformationTable",
                table: "FinalBill",
                column: "ConformationTable",
                principalTable: "ConformationTable",
                principalColumn: "ConformationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalBill_JobsList_JobsListJobListID",
                table: "FinalBill",
                column: "JobsListJobListID",
                principalTable: "JobsList",
                principalColumn: "JobListID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalBill_JobsTable_JobsTableJobsID",
                table: "FinalBill",
                column: "JobsTableJobsID",
                principalTable: "JobsTable",
                principalColumn: "JobsID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalBill_ConformationTable_ConformationTable",
                table: "FinalBill");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalBill_JobsList_JobsListJobListID",
                table: "FinalBill");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalBill_JobsTable_JobsTableJobsID",
                table: "FinalBill");

            migrationBuilder.DropTable(
                name: "ConformationTable");

            migrationBuilder.DropTable(
                name: "JobsList");

            migrationBuilder.DropTable(
                name: "JobsTable");

            migrationBuilder.DropIndex(
                name: "IX_FinalBill_ConformationTable",
                table: "FinalBill");

            migrationBuilder.DropIndex(
                name: "IX_FinalBill_JobsListJobListID",
                table: "FinalBill");

            migrationBuilder.DropIndex(
                name: "IX_FinalBill_JobsTableJobsID",
                table: "FinalBill");

            migrationBuilder.DropColumn(
                name: "ConformationID",
                table: "FinalBill");

            migrationBuilder.DropColumn(
                name: "ConformationTable",
                table: "FinalBill");

            migrationBuilder.DropColumn(
                name: "JobsListJobListID",
                table: "FinalBill");

            migrationBuilder.DropColumn(
                name: "JobsTableJobsID",
                table: "FinalBill");
        }
    }
}
