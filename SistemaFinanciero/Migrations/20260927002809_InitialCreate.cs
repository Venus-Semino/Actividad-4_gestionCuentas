using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaFinanciero.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    Clabe = table.Column<string>(type: "text", nullable: true),
                    CardLastDigits = table.Column<string>(type: "text", nullable: true),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    LongDescription = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConceptType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: true),
                    LongDescription = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountType", "BankName", "CardLastDigits", "Clabe", "CompanyId", "CreatedAt", "IsActive", "LongDescription", "Name", "ShortDescription", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("53890490-08ae-4208-aefa-b78066b96f93"), null, 2, null, null, null, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Caja Chica", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("a51b0c0f-2cec-4d8a-a4db-5e125d60a29b"), null, 0, "Banamex", null, null, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Cuenta Operativa", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("c7e3800d-7e09-4de6-967c-a5c967a267c8"), null, 4, null, null, null, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Fondo de Inversión", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) }
                });

            migrationBuilder.InsertData(
                table: "Concepts",
                columns: new[] { "Id", "CompanyId", "ConceptType", "CreatedAt", "IsActive", "LongDescription", "Name", "ShortDescription", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0d5d8a12-b23e-4fa4-9f11-d8a4b2fd9dab"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Servicios públicos", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("503182de-4325-427d-81a2-12a92e429087"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Reembolsos", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("5de947ab-4805-4f68-adc2-50bd9648f1b1"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Renta de oficina", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("624c8b1a-b5ee-491d-9543-eaa83bb32d73"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Venta de servicios", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("7a08746a-cff7-4613-b165-be966346d0f0"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Compra de equipo", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("899f8e9d-2bb3-4715-bdd1-7b8545b37780"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Aportación de capital", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("a9c900c3-adbe-496c-866c-9eacd17d2058"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Licencias de software", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("ab29becf-b011-4b00-ad4a-05253f13e4f0"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Pago de nómina", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("c9777066-825e-4844-b688-a4347e9b98cd"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Venta de activos", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) },
                    { new Guid("e8c69902-0937-465d-83be-f1cef2e5db50"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229), true, null, "Rendimientos", null, new DateTime(2026, 9, 27, 0, 28, 9, 198, DateTimeKind.Utc).AddTicks(3229) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CompanyId_Name",
                table: "Accounts",
                columns: new[] { "CompanyId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_CompanyId_ConceptType_Name",
                table: "Concepts",
                columns: new[] { "CompanyId", "ConceptType", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Concepts");
        }
    }
}
