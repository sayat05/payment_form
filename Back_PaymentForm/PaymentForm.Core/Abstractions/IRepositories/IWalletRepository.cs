using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions.IRepositories;

public interface IWalletRepository
{
    Task<IEnumerable<Wallet>> GetAll();
    Task<Wallet?> GetById(long id);
    Task<Wallet?> GetByUserId(long userId);
    Task UpdateWallet(long id);
}