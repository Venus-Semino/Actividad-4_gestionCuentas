using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using SistemaFinanciero.Data;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.GraphQL;

[ExtendObjectType("Query")]
public class AccountConceptQueries
{
    public IQueryable<Account> GetAccounts(
        [Service] FinancialDbContext context,
        Guid companyId,
        AccountType? accountType,
        bool? activeOnly)
    {
        var query = context.Accounts.Where(a => a.CompanyId == companyId);
        
        if (accountType.HasValue) 
            query = query.Where(a => a.AccountType == accountType.Value);
            
        if (activeOnly.HasValue && activeOnly.Value) 
            query = query.Where(a => a.IsActive);
            
        return query;
    }

    public IQueryable<Concept> GetConcepts(
        [Service] FinancialDbContext context,
        Guid companyId,
        ConceptType? conceptType,
        bool? activeOnly)
    {
        var query = context.Concepts.Where(c => c.CompanyId == companyId);
        
        if (conceptType.HasValue) 
            query = query.Where(c => c.ConceptType == conceptType.Value);
            
        if (activeOnly.HasValue && activeOnly.Value) 
            query = query.Where(c => c.IsActive);
            
        return query;
    }
}