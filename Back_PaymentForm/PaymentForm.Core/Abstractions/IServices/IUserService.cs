using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions.IServices;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(long id);
    Task<User?> GetByEmail(string email);
    Task<long> Add(UserAddDto dto);
}