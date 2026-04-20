namespace PaymentForm.Core.DtoModels;

public class UserAddDto
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public string PhoneNumber { get; set; } = string.Empty;
}