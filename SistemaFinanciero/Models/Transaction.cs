using System;

namespace SistemaFinanciero.Models;

public enum TransactionType { INCOME, EXPENSE } //[cite: 2]

public class Transaction
{
    // Utilizamos 'init' para evitar que el ID o la cuenta se modifiquen después de instanciar.
    public Guid Id { get; init; }
    public Guid AccountId { get; init; }
    public Guid ConceptId { get; init; }
    public TransactionType TransactionType { get; init; }
    public decimal Amount { get; private set; }
    public DateTime TransactionDate { get; init; }
    public DateTime CapturedAt { get; init; }
    public Guid CapturedBy { get; init; } // ID del usuario que registra
    public string? ShortDescription { get; init; }
    public string? LongDescription { get; init; }
    public bool IsActive { get; private set; } // Puede cambiar si se elimina/cancela
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; private set; }

    // Propiedades de navegación (Entity Framework)
    public Account Account { get; init; } = null!;
    public Concept Concept { get; init; } = null!;

    // Método controlado para la eliminación lógica
    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    // Constructor para forzar la inyección de datos críticos y validar estado interno
    public Transaction(Guid accountId, Guid conceptId, decimal amount, TransactionType type, Guid capturedBy)
    {
        if (amount <= 0) throw new ArgumentException("El monto debe ser mayor que cero."); 

        Id = Guid.NewGuid();
        AccountId = accountId;
        ConceptId = conceptId;
        Amount = amount;
        TransactionType = type;
        CapturedBy = capturedBy;
        TransactionDate = DateTime.UtcNow;
        CapturedAt = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        IsActive = true;
    }
}