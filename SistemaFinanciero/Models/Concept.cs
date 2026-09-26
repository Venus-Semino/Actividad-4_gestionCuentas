using System;

namespace SistemaFinanciero.Models;

public enum ConceptType { INCOME, EXPENSE }

public class Concept
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public ConceptType ConceptType { get; set; }
    public string Name { get; set; } = null!;
    public string? ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}