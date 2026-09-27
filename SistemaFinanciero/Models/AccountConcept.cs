using System;

namespace SistemaFinanciero.Models;

public class AccountConcept
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid ConceptId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public Account Account { get; set; } = null!;
    public Concept Concept { get; set; } = null!;
}