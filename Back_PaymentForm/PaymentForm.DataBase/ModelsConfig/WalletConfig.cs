using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentForm.DataBase.EfCoreModels;

namespace PaymentForm.DataBase.ModelsConfig;

public class WalletConfig : IEntityTypeConfiguration<WalletEfCore>
{
    public void Configure(EntityTypeBuilder<WalletEfCore> builder)
    {
        builder.ToTable("wallets").HasKey(w => w.Id);
        builder.HasIndex(w => w.WalletNumber).IsUnique();

        builder
            .HasOne(w => w.UserEfCore)
            .WithMany(u => u.WalletsEfCore)
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(w => w.PaymentsEfCore)
            .WithOne(p => p.WalletEfCore)
            .OnDelete(DeleteBehavior.Cascade);

        var wallets = new List<WalletEfCore>
        {
            new() { Id = 1, WalletNumber = "1111", Balance = 1235, UserId = 1 },
            new() { Id = 2, WalletNumber = "2222", Balance = 9876, UserId = 1 },
            new() { Id = 3, WalletNumber = "3333", Balance = 4567, UserId = 2 },
            new() { Id = 4, WalletNumber = "4444", Balance = 1234, UserId = 3 },
            new() { Id = 5, WalletNumber = "5555", Balance = 5432, UserId = 4 },
            new() { Id = 6, WalletNumber = "6666", Balance = 7687, UserId = 4 },
        };

        builder.HasData(wallets);

    }
}