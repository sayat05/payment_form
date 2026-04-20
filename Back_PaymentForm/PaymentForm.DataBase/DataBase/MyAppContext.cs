using Microsoft.EntityFrameworkCore;
using PaymentForm.DataBase.EfCoreModels;

namespace PaymentForm.DataBase.DataBase;

public class MyAppContext(DbContextOptions<MyAppContext> options) : DbContext(options)
{
    private DbSet<UserEfCore> Users => Set<UserEfCore>();
    private DbSet<PaymentEfCore> Payments => Set<PaymentEfCore>();
    private DbSet<WalletEfCore> Wallets => Set<WalletEfCore>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppContext).Assembly);
    }
}