using System;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using SistemaFinanciero.Data;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.GraphQL;

[ExtendObjectType("Query")]
public class TransactionQueries
{
    public IQueryable<Transaction> GetTransactions(
        [Service] FinancialDbContext context,
        Guid? accountId,
        TransactionType? transactionType,
        int? limit,
        int? offset)
    {
        var query = context.Transactions.AsQueryable();

        if (accountId.HasValue)
            query = query.Where(t => t.AccountId == accountId.Value);

        if (transactionType.HasValue)
            query = query.Where(t => t.TransactionType == transactionType.Value);

        if (offset.HasValue)
            query = query.Skip(offset.Value);

        if (limit.HasValue)
            query = query.Take(limit.Value);

        return query;
    }
}