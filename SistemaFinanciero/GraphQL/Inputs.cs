using System;
using SistemaFinanciero.Models;

namespace SistemaFinanciero.GraphQL;

public record CreateAccountInput(
    Guid CompanyId,
    AccountType AccountType,
    string Name,
    string? BankName,
    string? AccountNumber,
    string? Clabe,
    string? CardLastDigits,
    string? ShortDescription,
    string? LongDescription
);

public record CreateConceptInput(
    Guid CompanyId,
    ConceptType ConceptType,
    string Name,
    string? ShortDescription,
    string? LongDescription
);

public record AssignConceptToAccountInput(
    Guid AccountId,
    Guid ConceptId
);

public record CreateTransactionInput(
    Guid AccountId,
    Guid ConceptId,
    TransactionType TransactionType,
    decimal Amount,
    DateTime? TransactionDate,
    string? ShortDescription,
    string? LongDescription,
    Guid CapturedBy // Simulando el usuario autenticado
);