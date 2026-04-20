using Microsoft.EntityFrameworkCore;
using PaymentForm.DataBase.EfCoreModels;

namespace PaymentForm.DataBase.DataBase;

public class MyAppContext(DbContextOptions<MyAppContext> options) : DbContext(options)
{
    public DbSet<UserEfCore> Users => Set<UserEfCore>();
    public DbSet<PaymentEfCore> Payments => Set<PaymentEfCore>();
    public DbSet<WalletEfCore> Wallets => Set<WalletEfCore>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppContext).Assembly);
    }
}