using System;
using Microsoft.EntityFrameworkCore;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.Data;

public class FinancialDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Concept> Concepts { get; set; } = null!;

    public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Prevención de registros duplicados requerida por la actividad[cite: 3]
        modelBuilder.Entity<Account>()
            .HasIndex(a => new { a.CompanyId, a.Name })
            .IsUnique();

        modelBuilder.Entity<Concept>()
            .HasIndex(c => new { c.CompanyId, c.ConceptType, c.Name })
            .IsUnique();

        // Seeding de datos mínimos solicitados: 3 cuentas, 5 ingresos, 5 egresos[cite: 3]
        var companyId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var now = DateTime.UtcNow;

        modelBuilder.Entity<Account>().HasData(
            new Account { Id = Guid.NewGuid(), CompanyId = companyId, AccountType = AccountType.CASH, Name = "Caja Chica", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Account { Id = Guid.NewGuid(), CompanyId = companyId, AccountType = AccountType.DEBIT, Name = "Cuenta Operativa", BankName = "Banamex", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Account { Id = Guid.NewGuid(), CompanyId = companyId, AccountType = AccountType.INVESTMENT, Name = "Fondo de Inversión", IsActive = true, CreatedAt = now, UpdatedAt = now }
        );

        modelBuilder.Entity<Concept>().HasData(
            // 5 Conceptos de Ingreso (INCOME)[cite: 3]
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Venta de servicios", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Rendimientos", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Aportación de capital", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Venta de activos", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Reembolsos", IsActive = true, CreatedAt = now, UpdatedAt = now },
            
            // 5 Conceptos de Egreso (EXPENSE)[cite: 3]
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Pago de nómina", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Renta de oficina", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Servicios públicos", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Compra de equipo", IsActive = true, CreatedAt = now, UpdatedAt = now },
            new Concept { Id = Guid.NewGuid(), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Licencias de software", IsActive = true, CreatedAt = now, UpdatedAt = now }
        );
    }
}