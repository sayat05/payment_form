using System.Security.AccessControl;
using PaymentForm.Core.Enums;

namespace PaymentForm.DataBase.EfCoreModels;

public class PaymentEfCore
{
    public long Id { get; init; }
    public long WalletId { get; init; }
    public WalletEfCore WalletEfCore { get; init; }
    public required string Email { get; init; }
    public decimal Amount { get; init; }
    public CurrencyType Currency { get; init; }
    public PaymentStatus Status { get; init; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// У одного платежа много счетов
    /// </summary>
    public List<WalletEfCore> WalletsEfCore { get; init; } = [];
}