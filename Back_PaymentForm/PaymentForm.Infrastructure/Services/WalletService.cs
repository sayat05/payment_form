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

    public async Task<Wallet?> GetByWalletNumber(string walletNumber)
    {
        return await repository.GetByWalletNumber(walletNumber);
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

    public async Task<bool?> Update(WalletUpdateDto dto)
    {
        var wallet = await repository.GetByWalletNumber(dto.WalletNumber);
        if (wallet == null)
            return null;

        dto.Sum += wallet.Balance;
        return await repository.Update(new Wallet
        {
            WalletNumber = wallet.WalletNumber,
            Balance = dto.Sum,
            UserId = wallet.UserId
        });
    }
}