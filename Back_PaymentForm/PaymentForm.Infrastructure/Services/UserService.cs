using PaymentForm.Core.Abstractions.IRepositories;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Infrastructure.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<IEnumerable<User>> GetAll()
    {
        return await repository.GetAll();
    }

    public async Task<User?> GetById(long id)
    {
        return await repository.GetById(id);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await repository.GetByEmail(email);
    }

    public async Task<long> Add(UserAddDto dto)
    {
        return await repository.Add(new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber
        });
    }
}