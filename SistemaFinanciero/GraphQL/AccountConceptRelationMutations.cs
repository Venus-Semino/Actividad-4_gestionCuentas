using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SistemaFinanciero.Data;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.GraphQL;

[ExtendObjectType("Mutation")]
public class AccountConceptRelationMutations
{
    public async Task<AccountConcept> AssignConceptToAccountAsync(
        AssignConceptToAccountInput input,
        [Service] FinancialDbContext context)
    {
        var account = await context.Accounts.FirstOrDefaultAsync(a => a.Id == input.AccountId);
        if (account is null)
        {
            throw new GraphQLException("La cuenta no existe.");
        }

        var concept = await context.Concepts.FirstOrDefaultAsync(c => c.Id == input.ConceptId);
        if (concept is null)
        {
            throw new GraphQLException("El concepto no existe.");
        }

        if (account.CompanyId != concept.CompanyId)
        {
            throw new GraphQLException("La cuenta y el concepto no pertenecen a la misma empresa.");
        }

        var existing = await context.AccountConcepts
            .Include(link => link.Account)
            .Include(link => link.Concept)
            .FirstOrDefaultAsync(link =>
                link.AccountId == input.AccountId &&
                link.ConceptId == input.ConceptId);

        if (existing is { IsActive: true })
        {
            throw new GraphQLException("Este concepto ya está asignado a la cuenta.");
        }

        if (existing is not null)
        {
            existing.IsActive = true;
            await context.SaveChangesAsync();
            return existing;
        }

        var relation = new AccountConcept
        {
            Id = Guid.NewGuid(),
            AccountId = account.Id,
            ConceptId = concept.Id,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            Account = account,
            Concept = concept
        };

        context.AccountConcepts.Add(relation);

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new GraphQLException("Este concepto ya está asignado a la cuenta.");
        }

        return relation;
    }

    public async Task<bool> RemoveConceptFromAccountAsync(
        Guid accountId,
        Guid conceptId,
        [Service] FinancialDbContext context)
    {
        var accountExists = await context.Accounts.AnyAsync(a => a.Id == accountId);
        if (!accountExists)
        {
            throw new GraphQLException("La cuenta no existe.");
        }

        var conceptExists = await context.Concepts.AnyAsync(c => c.Id == conceptId);
        if (!conceptExists)
        {
            throw new GraphQLException("El concepto no existe.");
        }

        var relation = await context.AccountConcepts.FirstOrDefaultAsync(link =>
            link.AccountId == accountId &&
            link.ConceptId == conceptId &&
            link.IsActive);

        if (relation is null)
        {
            throw new GraphQLException("No existe una relación activa entre esta cuenta y este concepto.");
        }

        relation.IsActive = false;
        await context.SaveChangesAsync();
        return true;
    }
}
