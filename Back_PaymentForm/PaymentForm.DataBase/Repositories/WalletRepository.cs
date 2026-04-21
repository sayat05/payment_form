using Microsoft.EntityFrameworkCore;
using PaymentForm.Core.Abstractions.IRepositories;
using PaymentForm.Core.Models;
using PaymentForm.DataBase.DataBase;
using PaymentForm.DataBase.EfCoreModels;

namespace PaymentForm.DataBase.Repositories;

public class WalletRepository(MyAppContext context) : IWalletRepository
{
    public async Task<IEnumerable<Wallet>> GetAll()
    {
        var walletsEfCore = await context.Wallets.AsNoTracking().ToListAsync();
        return walletsEfCore.Select(ToWallet);
    }
    
    public async Task<IEnumerable<Wallet>>  GetByUserId(long userId)
    {
        var walletsEfCore = await context.Wallets
            .AsNoTracking()
            .Where(w => w.UserId == userId)
            .ToListAsync();
        
        return walletsEfCore.Select(ToWallet);    }

    public async Task<Wallet?> GetById(long id)
    {
        var walletEfCore = await context.Wallets.AsNoTracking().FirstOrDefaultAsync(w => w.Id == id);
        if (walletEfCore == null)
            return null;

        return ToWallet(walletEfCore);

    }

    public async Task<Wallet?> GetWalletNumber(string walletNumber)
    {
        var walletEfCore = await context.Wallets.AsNoTracking().FirstOrDefaultAsync(w => w.WalletNumber == walletNumber);
        if (walletEfCore == null)
            return null;

        return ToWallet(walletEfCore);
    }

    public async Task<long> Add(Wallet wallet)
    {
        var entity = await context.Wallets.AddAsync(new WalletEfCore
        {
            WalletNumber = wallet.WalletNumber,
            Balance = wallet.Balance,
            UserId = wallet.UserId,
        });

        await context.SaveChangesAsync();

        return entity.Entity.Id;
    }
    
    
    private Wallet ToWallet(WalletEfCore efCore)
    {
        return new Wallet
        {
            Id = efCore.Id,
            WalletNumber = efCore.WalletNumber,
            Balance = efCore.Balance,
            UserId = efCore.UserId
        };
    }
}