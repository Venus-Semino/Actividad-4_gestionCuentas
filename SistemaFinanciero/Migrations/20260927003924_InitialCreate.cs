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
                    { new Guid("a1111111-1111-1111-1111-111111111111"), null, 2, null, null, null, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Caja Chica", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a2222222-1111-1111-1111-111111111111"), null, 0, "Banamex", null, null, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Cuenta Operativa", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a3333333-1111-1111-1111-111111111111"), null, 4, null, null, null, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Fondo de Inversión", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Concepts",
                columns: new[] { "Id", "CompanyId", "ConceptType", "CreatedAt", "IsActive", "LongDescription", "Name", "ShortDescription", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Venta de servicios", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c1111112-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Rendimientos", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c1111113-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Aportación de capital", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c1111114-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Venta de activos", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c1111115-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 0, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Reembolsos", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c2222221-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Pago de nómina", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c2222222-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Renta de oficina", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c2222223-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Servicios públicos", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c2222224-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Compra de equipo", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("c2222225-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 1, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Licencias de software", null, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc) }
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
