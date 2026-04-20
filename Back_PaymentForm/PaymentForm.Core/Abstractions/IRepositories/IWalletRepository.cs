using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions.IRepositories;

public interface IWalletRepository
{
    Task<IEnumerable<Wallet>> GetAll();
    Task<Wallet?> GetById(long id);
    Task<Wallet?> GetWalletNumber(string walletNumber);
    Task<Wallet?> GetByUserId(long userId);
}