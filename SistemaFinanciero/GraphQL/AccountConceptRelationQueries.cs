using System;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SistemaFinanciero.Data;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.GraphQL;

[ExtendObjectType("Query")]
public class AccountConceptRelationQueries
{
    public async Task<IQueryable<AccountConcept>> GetAccountConcepts(
        [Service] FinancialDbContext context,
        Guid accountId)
    {
        var accountExists = await context.Accounts.AnyAsync(a => a.Id == accountId);
        if (!accountExists)
        {
            throw new GraphQLException("La cuenta no existe.");
        }

        return context.AccountConcepts
            .Include(link => link.Account)
            .Include(link => link.Concept)
            .Where(link => link.AccountId == accountId && link.IsActive);
    }
}