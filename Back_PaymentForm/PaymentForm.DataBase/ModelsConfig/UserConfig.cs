using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentForm.DataBase.EfCoreModels;

namespace PaymentForm.DataBase.ModelsConfig;

public class UserConfig : IEntityTypeConfiguration<UserEfCore>
{
    public void Configure(EntityTypeBuilder<UserEfCore> builder)
    {
        builder.ToTable("users").HasKey(u => u.Id);
        builder.HasIndex(u => u.Email).IsUnique();

        builder
            .HasMany(u => u.WalletsEfCore)
            .WithOne(w => w.UserEfCore)
            .OnDelete(DeleteBehavior.Cascade);
        

        var users = new List<UserEfCore>
        {
            new() { Id = 1, Name = "user_1", Email = "user_1@u", PhoneNumber = "555-111-3333" },
            new() { Id = 2, Name = "user_2", Email = "user_2@u"},
            new() { Id = 3, Name = "user_3", Email = "user_3@u", PhoneNumber = "123-123-1234" },
            new() { Id = 4, Name = "user_4", Email = "user_4@u", PhoneNumber = ""}
        };

        builder.HasData(users);
    }
}