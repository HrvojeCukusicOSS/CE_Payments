using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class paymentstest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PayersTable",
                columns: table => new
                {
                    IdPayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayersTable", x => x.IdPayer);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInformations",
                columns: table => new
                {
                    IdPaymentInformation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInformations", x => x.IdPaymentInformation);
                });

            migrationBuilder.CreateTable(
                name: "ReceiversTable",
                columns: table => new
                {
                    IdReceiver = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiversTable", x => x.IdReceiver);
                });

            migrationBuilder.CreateTable(
                name: "StatusFinalBill",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusFinalBill", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "StatusPaymentSolution",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPaymentSolution", x => x.Id);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinalBill",
                columns: table => new
                {
                    IdFinalBill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayerId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalBill", x => x.IdFinalBill);
                    table.ForeignKey(
                        name: "FK_FinalBill_PayersTable_PayerId",
                        column: x => x.PayerId,
                        principalTable: "PayersTable",
                        principalColumn: "IdPayer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalBill_ReceiversTable_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "ReceiversTable",
                        principalColumn: "IdReceiver",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalBill_StatusFinalBill_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusFinalBill",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSolutions",
                columns: table => new
                {
                    IdPaymentSolution = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermsOfPaymnt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    NumberOfPayments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSolutions", x => x.IdPaymentSolution);
                    table.ForeignKey(
                        name: "FK_PaymentSolutions_StatusPaymentSolution_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusPaymentSolution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSchedules",
                columns: table => new
                {
                    IdPaymentSchedule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentSolutionId = table.Column<int>(type: "int", nullable: false),
                    PaymnetInformationId = table.Column<int>(type: "int", nullable: false),
                    StartOfSchedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntOfSchedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalAmount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSchedules", x => x.IdPaymentSchedule);
                    table.ForeignKey(
                        name: "FK_PaymentSchedules_PaymentInformations_PaymnetInformationId",
                        column: x => x.PaymnetInformationId,
                        principalTable: "PaymentInformations",
                        principalColumn: "IdPaymentInformation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentSchedules_PaymentSolutions_PaymentSolutionId",
                        column: x => x.PaymentSolutionId,
                        principalTable: "PaymentSolutions",
                        principalColumn: "IdPaymentSolution",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "JobsTable",
                columns: new[] { "JobsID", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Writes code for apps", "Software Developer", 225m },
                    { 2, "Supervises developers", "IT Manager", 550m }
                });

            migrationBuilder.InsertData(
                table: "PayersTable",
                columns: new[] { "IdPayer", "Name" },
                values: new object[,]
                {
                    { 1, "eaaav@gad" },
                    { 2, "htthv@gad" }
                });

            migrationBuilder.InsertData(
                table: "ReceiversTable",
                columns: new[] { "IdReceiver", "Name" },
                values: new object[,]
                {
                    { 1, "asdf@gad" },
                    { 2, "zztzf@gad" }
                });

            migrationBuilder.InsertData(
                table: "StatusFinalBill",
                columns: new[] { "IdStatus", "Code", "Description", "ShortName" },
                values: new object[] { 1, "1950", "This is some very dangerous string error", "Some Status" });

            migrationBuilder.InsertData(
                table: "FinalBill",
                columns: new[] { "IdFinalBill", "PayerId", "ReceiverId", "StatusId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "FinalBill",
                columns: new[] { "IdFinalBill", "PayerId", "ReceiverId", "StatusId" },
                values: new object[] { 2, 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "JobsList",
                columns: new[] { "JobListID", "JobsID", "PayerConformation", "ReciverConformation" },
                values: new object[] { 1, 1, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_ConformationTable_JobListID",
                table: "ConformationTable",
                column: "JobListID");

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_PayerId",
                table: "FinalBill",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_ReceiverId",
                table: "FinalBill",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalBill_StatusId",
                table: "FinalBill",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsList_JobsID",
                table: "JobsList",
                column: "JobsID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSchedules_PaymentSolutionId",
                table: "PaymentSchedules",
                column: "PaymentSolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSchedules_PaymnetInformationId",
                table: "PaymentSchedules",
                column: "PaymnetInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSolutions_StatusId",
                table: "PaymentSolutions",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConformationTable");

            migrationBuilder.DropTable(
                name: "FinalBill");

            migrationBuilder.DropTable(
                name: "PaymentSchedules");

            migrationBuilder.DropTable(
                name: "JobsList");

            migrationBuilder.DropTable(
                name: "PayersTable");

            migrationBuilder.DropTable(
                name: "ReceiversTable");

            migrationBuilder.DropTable(
                name: "StatusFinalBill");

            migrationBuilder.DropTable(
                name: "PaymentInformations");

            migrationBuilder.DropTable(
                name: "PaymentSolutions");

            migrationBuilder.DropTable(
                name: "JobsTable");

            migrationBuilder.DropTable(
                name: "StatusPaymentSolution");
        }
    }
}
