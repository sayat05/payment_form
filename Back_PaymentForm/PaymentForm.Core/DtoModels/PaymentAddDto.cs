namespace PaymentForm.Core.DtoModels;

public class PaymentAddDto
{
    public required string WalletNumber { get; init; }
    public required long UserId { get; init; }
    public required string Email { get; init; }
    public string PhoneNumber { get; init; } = string.Empty;
    public required string Currency { get; init; }
    public decimal Amount { get; init; }
    public string Comment { get; init; } = string.Empty;
}