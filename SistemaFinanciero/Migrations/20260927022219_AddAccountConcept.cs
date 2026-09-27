using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaFinanciero.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountConcept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountConcepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountConcepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountConcepts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountConcepts_Concepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountConcepts",
                columns: new[] { "Id", "AccountId", "ConceptId", "CreatedAt", "IsActive" },
                values: new object[,]
                {
                    { new Guid("ac100001-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("c1111115-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac100002-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("c2222223-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac100003-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("c2222224-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac100004-1111-1111-1111-111111111111"), new Guid("a2222222-1111-1111-1111-111111111111"), new Guid("c1111111-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac100005-1111-1111-1111-111111111111"), new Guid("a2222222-1111-1111-1111-111111111111"), new Guid("c1111113-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac100006-1111-1111-1111-111111111111"), new Guid("a2222222-1111-1111-1111-111111111111"), new Guid("c2222221-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac100007-1111-1111-1111-111111111111"), new Guid("a2222222-1111-1111-1111-111111111111"), new Guid("c2222222-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac100008-1111-1111-1111-111111111111"), new Guid("a2222222-1111-1111-1111-111111111111"), new Guid("c2222225-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac100009-1111-1111-1111-111111111111"), new Guid("a3333333-1111-1111-1111-111111111111"), new Guid("c1111112-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true },
                    { new Guid("ac10000a-1111-1111-1111-111111111111"), new Guid("a3333333-1111-1111-1111-111111111111"), new Guid("c1111114-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountConcepts_AccountId_ConceptId",
                table: "AccountConcepts",
                columns: new[] { "AccountId", "ConceptId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountConcepts_ConceptId",
                table: "AccountConcepts",
                column: "ConceptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountConcepts");
        }
    }
}
