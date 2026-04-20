namespace PaymentForm.DataBase.EfCoreModels;

public class UserEfCore
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public string PhoneNumber { get; init; } = string.Empty;

    
    /// <summary>
    /// У одного пользователя много счетов
    /// </summary>
    public List<WalletEfCore> WalletsEfCore { get; init; } = [];
}