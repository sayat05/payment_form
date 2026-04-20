namespace PaymentForm.Core.Models;

public class User
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public string PhoneNumber { get; set; } = string.Empty;
}