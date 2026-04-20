namespace PaymentForm.Core.DtoModels;

public class WalletAddDto
{
    public required string WalletNumber { get; init; }
    public required decimal Balance { get; init; }
    public required long UserId { get; init; }
}