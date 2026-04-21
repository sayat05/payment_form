using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions.IRepositories;

public interface IWalletRepository
{
    Task<IEnumerable<Wallet>> GetAll();
    Task<IEnumerable<Wallet>> GetByUserId(long userId);
    Task<Wallet?> GetById(long id);
    Task<Wallet?> GetByWalletNumber(string walletNumber);
    Task<long> Add(Wallet wallet);
    Task<bool> Update(Wallet wallet);
}