using System;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using SistemaFinanciero.Data;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.GraphQL;

[ExtendObjectType("Mutation")]
public class AccountConceptMutations
{
    public async Task<Account> CreateAccountAsync(
        CreateAccountInput input,
        [Service] FinancialDbContext context)
    {
        // Validación para prevenir registros duplicados[cite: 3]
        var exists = context.Accounts.Any(a => a.CompanyId == input.CompanyId && a.Name == input.Name);
        if (exists) throw new GraphQLException("Ya existe una cuenta con este nombre para la empresa.");

        var account = new Account
        {
            Id = Guid.NewGuid(),
            CompanyId = input.CompanyId,
            AccountType = input.AccountType,
            Name = input.Name,
            BankName = input.BankName,
            AccountNumber = input.AccountNumber,
            Clabe = input.Clabe,
            CardLastDigits = input.CardLastDigits,
            ShortDescription = input.ShortDescription,
            LongDescription = input.LongDescription,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.Accounts.Add(account);
        await context.SaveChangesAsync();
        return account;
    }

    public async Task<Concept> CreateConceptAsync(
        CreateConceptInput input,
        [Service] FinancialDbContext context)
    {
        // Validación para prevenir registros duplicados[cite: 3]
        var exists = context.Concepts.Any(c => c.CompanyId == input.CompanyId && c.ConceptType == input.ConceptType && c.Name == input.Name);
        if (exists) throw new GraphQLException("Ya existe este concepto registrado para la empresa.");

        var concept = new Concept
        {
            Id = Guid.NewGuid(),
            CompanyId = input.CompanyId,
            ConceptType = input.ConceptType,
            Name = input.Name,
            ShortDescription = input.ShortDescription,
            LongDescription = input.LongDescription,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        context.Concepts.Add(concept);
        await context.SaveChangesAsync();
        return concept;
    }
}