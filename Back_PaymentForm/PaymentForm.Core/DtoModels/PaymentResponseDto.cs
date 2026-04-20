namespace PaymentForm.Core.DtoModels;

public class PaymentResponseDto
{
    public long Id { get; init; }
    public long WalletId { get; init; }
    public required string Email { get; init; }
    public decimal Amount { get; init; }
    public required string Currency { get; init; }
    public required string Status { get; init; }
    public string Comment { get; set; } = string.Empty;
    public required string CreatedAt { get; init; }
}