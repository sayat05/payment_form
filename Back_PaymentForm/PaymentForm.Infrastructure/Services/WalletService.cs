using PaymentForm.Core.Abstractions.IRepositories;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Infrastructure.Services;

public class WalletService(IWalletRepository repository, IUserRepository userRepository) : IWalletService
{
    public async Task<IEnumerable<Wallet>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<IEnumerable<Wallet>> GetByUserId(long userId)
    {
        return await repository.GetByUserId(userId);
    }

    public async Task<Wallet?> GetById(long id)
    {
        return await repository.GetById(id);
    }

    public async Task<Wallet?> GetWalletNumber(string walletNumber)
    {
        return await repository.GetWalletNumber(walletNumber);
    }

    public async Task<long?> Add(WalletAddDto dto)
    {
        var user = await userRepository.GetById(dto.UserId);
        if (user == null)
            return null;
        
        return await repository.Add(new Wallet
        {
            WalletNumber = dto.WalletNumber,
            Balance = dto.Balance,
            UserId = dto.UserId
        });
    }
}