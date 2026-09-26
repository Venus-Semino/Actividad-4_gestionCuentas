using System;

namespace SistemaFinanciero.Models;

public enum AccountType { DEBIT, CREDIT, CASH, SAVINGS, INVESTMENT, WALLET, OTHER }

public class Account
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public AccountType AccountType { get; set; }
    public string Name { get; set; } = null!;
    public string? BankName { get; set; }
    public string? AccountNumber { get; set; }
    public string? Clabe { get; set; }
    public string? CardLastDigits { get; set; }
    public string? ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}