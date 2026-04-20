using Microsoft.EntityFrameworkCore;
using PaymentForm.Core.Abstractions.IRepositories;
using PaymentForm.Core.Models;
using PaymentForm.DataBase.DataBase;
using PaymentForm.DataBase.EfCoreModels;

namespace PaymentForm.DataBase.Repositories;

public class UserRepository(MyAppContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAll()
    {
        var usersEfCore = await context.Users.AsNoTracking().ToListAsync();
        return usersEfCore.Select(ToUser);
    }

    public async Task<User?> GetById(long id)
    {
        var userEfCore = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (userEfCore == null)
            return null;
        
        return ToUser(userEfCore);
    }

    public async Task<User?> GetByEmail(string email)
    {
        var userEfCore = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        if (userEfCore == null)
            return null;
        
        return ToUser(userEfCore);    }

    public async Task<long> Add(User user)
    {
        var entity = await context.Users.AddAsync(new UserEfCore
        {
            Name = user.Name,
            Email =  user.Email,
            PhoneNumber = user.PhoneNumber
        });

        await context.SaveChangesAsync();
        return entity.Entity.Id;
    }

    private User ToUser(UserEfCore efCore)
    {
        return new User
        {
            Id = efCore.Id,
            Name = efCore.Name,
            Email = efCore.Email,
            PhoneNumber = efCore.PhoneNumber
        };
    }
}