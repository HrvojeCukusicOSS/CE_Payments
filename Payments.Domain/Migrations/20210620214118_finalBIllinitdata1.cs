using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Domain.Migrations
{
    public partial class finalBIllinitdata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FinalBill",
                columns: table => new
                {
                    IdFinalBill = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalBill_ReceiversTable_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "ReceiversTable",
                        principalColumn: "IdReceiver",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalBill_StatusFinalBill_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusFinalBill",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalBill");

            migrationBuilder.DropTable(
                name: "PayersTable");

            migrationBuilder.DropTable(
                name: "ReceiversTable");

            migrationBuilder.DropTable(
                name: "StatusFinalBill");
        }
    }
}
