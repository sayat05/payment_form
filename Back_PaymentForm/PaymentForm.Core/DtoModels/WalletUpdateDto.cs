namespace PaymentForm.Core.DtoModels;

public class WalletUpdateDto
{
    public required string WalletNumber { get; init; }
    public decimal Sum { get; set; }
}