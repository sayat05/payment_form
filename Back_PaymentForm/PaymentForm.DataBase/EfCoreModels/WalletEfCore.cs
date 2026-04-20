namespace PaymentForm.DataBase.EfCoreModels;

public class WalletEfCore
{
    public long Id { get; set; }
    public required string WalletNumber { get; init; }
    public required decimal Balance { get; set; }
    public required long UserId { get; init; }

    /// <summary>
    /// У одного счета один пользователь
    /// </summary>
    public UserEfCore UserEfCore { get; init; } = null!;
    
    /// <summary>
    /// У одного кошелька много платежей
    /// </summary>
    public List<PaymentEfCore> PaymentsEfCore { get; init; } = [];
}   