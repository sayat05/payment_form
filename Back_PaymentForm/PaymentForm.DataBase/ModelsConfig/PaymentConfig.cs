using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentForm.Core.Enums;
using PaymentForm.DataBase.EfCoreModels;

namespace PaymentForm.DataBase.ModelsConfig;

public class PaymentConfig : IEntityTypeConfiguration<PaymentEfCore>
{
    public void Configure(EntityTypeBuilder<PaymentEfCore> builder)
    {
        builder.ToTable("payments").HasKey(p => p.Id);

        builder
            .HasOne(p => p.WalletEfCore)
            .WithMany(w => w.PaymentsEfCore)
            .HasForeignKey(p => p.WalletId)
            .OnDelete(DeleteBehavior.Cascade);

        var payments = new List<PaymentEfCore>
        {
            new()
            {
                Id = 1,
                WalletId = 1,
                Email = "user_1@u",
                PhoneNumber = "1111111",
                Amount = 123,
                Comment = "",
                Currency = CurrencyType.Euro,
                // CreatedAt = DateTime.UtcNow,
                Status = PaymentStatus.Created
            },
            
            new()
            {
                Id = 2,
                WalletId = 2,
                Email = "user_1@u",
                PhoneNumber = "2222222",
                Amount = 1000,
                Comment = "",
                Currency = CurrencyType.Kzt,
                // CreatedAt = DateTime.UtcNow,
                Status = PaymentStatus.Created
            },
            
            
            new()
            {
                Id = 3,
                WalletId = 3,
                Email = "user_2@u",
                PhoneNumber = "3333333",
                Amount = 123,
                Comment = "",
                Currency = CurrencyType.Euro,
                // CreatedAt = DateTime.UtcNow,
                Status = PaymentStatus.Created
            },
            
            
            new()
            {
                Id = 4,
                WalletId = 4,
                Email = "user_3@u",
                PhoneNumber = "44444444",
                Amount = 765,
                Comment = "",
                Currency = CurrencyType.Rub,
                // CreatedAt = DateTime.UtcNow,
                Status = PaymentStatus.Created
            },
            
            
            new()
            {
                Id = 5,
                WalletId = 6,
                Email = "user_4@u",
                PhoneNumber = "5555555",
                Amount = 5000,
                Comment = "",
                Currency = CurrencyType.Uzs,
                // CreatedAt = DateTime.UtcNow,
                Status = PaymentStatus.Created
            },
        };

        builder.HasData(payments);
    }
}