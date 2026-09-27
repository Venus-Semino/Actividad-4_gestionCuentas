using System;
using Microsoft.EntityFrameworkCore;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.Data;

public class FinancialDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Concept> Concepts { get; set; } = null!;
    public DbSet<AccountConcept> AccountConcepts { get; set; } = null!;

    public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>()
            .HasIndex(a => new { a.CompanyId, a.Name })
            .IsUnique();

        modelBuilder.Entity<Concept>()
            .HasIndex(c => new { c.CompanyId, c.ConceptType, c.Name })
            .IsUnique();

        modelBuilder.Entity<AccountConcept>()
            .HasIndex(link => new { link.AccountId, link.ConceptId })
            .IsUnique();

        modelBuilder.Entity<AccountConcept>()
            .HasOne(link => link.Account)
            .WithMany()
            .HasForeignKey(link => link.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AccountConcept>()
            .HasOne(link => link.Concept)
            .WithMany()
            .HasForeignKey(link => link.ConceptId)
            .OnDelete(DeleteBehavior.Restrict);

        var companyId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var fixedDate = new DateTime(2026, 9, 21, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<Account>().HasData(
            new Account { Id = Guid.Parse("a1111111-1111-1111-1111-111111111111"), CompanyId = companyId, AccountType = AccountType.CASH, Name = "Caja Chica", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Account { Id = Guid.Parse("a2222222-1111-1111-1111-111111111111"), CompanyId = companyId, AccountType = AccountType.DEBIT, Name = "Cuenta Operativa", BankName = "Banamex", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Account { Id = Guid.Parse("a3333333-1111-1111-1111-111111111111"), CompanyId = companyId, AccountType = AccountType.INVESTMENT, Name = "Fondo de Inversión", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate }
        );

        modelBuilder.Entity<Concept>().HasData(
            // Ingresos
            new Concept { Id = Guid.Parse("c1111111-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Venta de servicios", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Concept { Id = Guid.Parse("c1111112-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Rendimientos", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Concept { Id = Guid.Parse("c1111113-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Aportación de capital", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Concept { Id = Guid.Parse("c1111114-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Venta de activos", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Concept { Id = Guid.Parse("c1111115-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.INCOME, Name = "Reembolsos", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },

            // Egresos
            new Concept { Id = Guid.Parse("c2222221-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Pago de nómina", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Concept { Id = Guid.Parse("c2222222-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Renta de oficina", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Concept { Id = Guid.Parse("c2222223-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Servicios públicos", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Concept { Id = Guid.Parse("c2222224-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Compra de equipo", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate },
            new Concept { Id = Guid.Parse("c2222225-1111-1111-1111-111111111111"), CompanyId = companyId, ConceptType = ConceptType.EXPENSE, Name = "Licencias de software", IsActive = true, CreatedAt = fixedDate, UpdatedAt = fixedDate }
        );

        var cajaChicaId = Guid.Parse("a1111111-1111-1111-1111-111111111111");
        var cuentaOperativaId = Guid.Parse("a2222222-1111-1111-1111-111111111111");
        var fondoInversionId = Guid.Parse("a3333333-1111-1111-1111-111111111111");

        modelBuilder.Entity<AccountConcept>().HasData(
            new AccountConcept { Id = Guid.Parse("ac100001-1111-1111-1111-111111111111"), AccountId = cajaChicaId, ConceptId = Guid.Parse("c1111115-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac100002-1111-1111-1111-111111111111"), AccountId = cajaChicaId, ConceptId = Guid.Parse("c2222223-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac100003-1111-1111-1111-111111111111"), AccountId = cajaChicaId, ConceptId = Guid.Parse("c2222224-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac100004-1111-1111-1111-111111111111"), AccountId = cuentaOperativaId, ConceptId = Guid.Parse("c1111111-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac100005-1111-1111-1111-111111111111"), AccountId = cuentaOperativaId, ConceptId = Guid.Parse("c1111113-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac100006-1111-1111-1111-111111111111"), AccountId = cuentaOperativaId, ConceptId = Guid.Parse("c2222221-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac100007-1111-1111-1111-111111111111"), AccountId = cuentaOperativaId, ConceptId = Guid.Parse("c2222222-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac100008-1111-1111-1111-111111111111"), AccountId = cuentaOperativaId, ConceptId = Guid.Parse("c2222225-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac100009-1111-1111-1111-111111111111"), AccountId = fondoInversionId, ConceptId = Guid.Parse("c1111112-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate },
            new AccountConcept { Id = Guid.Parse("ac10000a-1111-1111-1111-111111111111"), AccountId = fondoInversionId, ConceptId = Guid.Parse("c1111114-1111-1111-1111-111111111111"), IsActive = true, CreatedAt = fixedDate }
        );
    }
}