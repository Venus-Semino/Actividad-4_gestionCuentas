using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaFinanciero.Migrations
{
    /// <inheritdoc />
    public partial class ArreglandoSemillasDinamicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("38b1e50f-9c3e-4194-b449-7e736163ea9e"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("da6a1450-4096-45b9-ad11-9bfba2193b4b"));

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "CapturedAt", "CapturedBy", "ConceptId", "CreatedAt", "IsActive", "LongDescription", "ShortDescription", "TransactionDate", "TransactionType", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("f1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111"), 1500.00m, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("12345678-1234-1234-1234-123456789012"), new Guid("c1111115-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f2222222-1111-1111-1111-111111111111"), new Guid("a2222222-1111-1111-1111-111111111111"), 8500.00m, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("12345678-1234-1234-1234-123456789012"), new Guid("c2222222-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("f2222222-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "CapturedAt", "CapturedBy", "ConceptId", "CreatedAt", "IsActive", "LongDescription", "ShortDescription", "TransactionDate", "TransactionType", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("38b1e50f-9c3e-4194-b449-7e736163ea9e"), new Guid("a1111111-1111-1111-1111-111111111111"), 1500.00m, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e7fa0299-4667-437f-bc41-91cbfccb29f2"), new Guid("c1111115-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 0, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("da6a1450-4096-45b9-ad11-9bfba2193b4b"), new Guid("a2222222-1111-1111-1111-111111111111"), 8500.00m, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e7fa0299-4667-437f-bc41-91cbfccb29f2"), new Guid("c2222222-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }
    }
}
