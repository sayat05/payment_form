namespace PaymentForm.Core.Models;

public class Wallet
{
    public long Id { get; set; }
    public required string WalletNumber { get; init; }
    public required decimal Balance { get; init; }
    public required long UserId { get; init; }
}