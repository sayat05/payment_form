using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions.IServices;

public interface IWalletService
{
    Task<IEnumerable<Wallet>> GetAll();
    Task<IEnumerable<Wallet>> GetByUserId(long userId);
    Task<Wallet?> GetById(long id);
    Task<Wallet?> GetWalletNumber(string walletNumber);
    Task<long?> Add(WalletAddDto dto);
}