using PaymentForm.Core.Enums;

namespace PaymentForm.Core.Models;

public class Payment
{
    public long Id { get; init; }
    public long WalletId { get; init; }
    public required string Email { get; init; }
    public decimal Amount { get; init; }
    public CurrencyType Currency { get; init; }
    public PaymentStatus Status { get; init; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}