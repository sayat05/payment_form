using PaymentForm.Core.Enums;

namespace PaymentForm.DataBase.EfCoreModels;

public class PaymentEfCore
{
    public long Id { get; init; }
    public long WalletId { get; init; }
    public WalletEfCore WalletEfCore { get; init; } = null!;
    public required string Email { get; init; }
    public string PhoneNumber { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public CurrencyType Currency { get; init; }
    public PaymentStatus Status { get; init; }
    public string Comment { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}