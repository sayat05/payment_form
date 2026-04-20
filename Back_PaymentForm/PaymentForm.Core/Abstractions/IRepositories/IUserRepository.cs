using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions.IRepositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(long id);
    Task<User?> GetByEmail(string email);
    Task<long> Add(User user);
}