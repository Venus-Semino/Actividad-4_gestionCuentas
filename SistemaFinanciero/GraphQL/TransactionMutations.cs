using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using SistemaFinanciero.Data;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.GraphQL;

[ExtendObjectType("Mutation")]
public class TransactionMutations
{
    public async Task<Transaction> CreateTransactionAsync(
        CreateTransactionInput input,
        [Service] FinancialDbContext context)
    {
        // 1. Validación de compatibilidad: Cuenta y Concepto existen
        var account = await context.Accounts.FirstOrDefaultAsync(a => a.Id == input.AccountId);
        var concept = await context.Concepts.FirstOrDefaultAsync(c => c.Id == input.ConceptId);

        if (account == null) throw new GraphQLException("La cuenta especificada no existe.");
        if (concept == null) throw new GraphQLException("El concepto especificado no existe.");

        // 2. Regla Financiera: Compatibilidad de tipos
        // Se asume que ConceptType tiene los mismos nombres (INCOME, EXPENSE) que TransactionType
        if (concept.ConceptType.ToString() != input.TransactionType.ToString())
        {
            throw new GraphQLException("El tipo de movimiento no es compatible con el tipo de concepto."); 
        }

        // 3. Validación de Relación: El concepto debe estar permitido para la cuenta
        var isAllowed = await context.AccountConcepts
            .AnyAsync(ac => ac.AccountId == input.AccountId && ac.ConceptId == input.ConceptId && ac.IsActive);

        if (!isAllowed) throw new GraphQLException("El concepto no está permitido para esta cuenta.");

        // 4. Instanciación segura (El constructor valida internamente que amount > 0)
        var transaction = new Transaction(
            input.AccountId,
            input.ConceptId,
            input.Amount,
            input.TransactionType,
            input.CapturedBy
        )
        {
            TransactionDate = input.TransactionDate ?? DateTime.UtcNow,
            ShortDescription = input.ShortDescription,
            LongDescription = input.LongDescription
        };

        context.Set<Transaction>().Add(transaction);
        await context.SaveChangesAsync();

        return transaction;
    }

    public async Task<Transaction> DeleteTransactionAsync(
        Guid id,
        [Service] FinancialDbContext context)
    {
        var transaction = await context.Set<Transaction>().FirstOrDefaultAsync(t => t.Id == id);
        if (transaction == null) throw new GraphQLException("Transacción no encontrada.");

        // Uso del método encapsulado en lugar de mutar la propiedad directamente
        transaction.Deactivate();
        await context.SaveChangesAsync();

        return transaction;
    }
}