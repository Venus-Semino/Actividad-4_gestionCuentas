using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaFinanciero.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoMotorTransacciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CapturedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CapturedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    LongDescription = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Concepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "CapturedAt", "CapturedBy", "ConceptId", "CreatedAt", "IsActive", "LongDescription", "ShortDescription", "TransactionDate", "TransactionType", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("38b1e50f-9c3e-4194-b449-7e736163ea9e"), new Guid("a1111111-1111-1111-1111-111111111111"), 1500.00m, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e7fa0299-4667-437f-bc41-91cbfccb29f2"), new Guid("c1111115-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("da6a1450-4096-45b9-ad11-9bfba2193b4b"), new Guid("a2222222-1111-1111-1111-111111111111"), 8500.00m, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e7fa0299-4667-437f-bc41-91cbfccb29f2"), new Guid("c2222222-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ConceptId",
                table: "Transactions",
                column: "ConceptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
