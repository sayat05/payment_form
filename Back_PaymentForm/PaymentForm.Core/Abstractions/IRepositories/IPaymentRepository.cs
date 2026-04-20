using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions.IRepositories;

public interface IPaymentRepository
{
    Task<IEnumerable<Payment>> GetAll();
    Task<IEnumerable<Payment>> GetCreatedPayments();
    Task<IEnumerable<Payment>> GetRejectedPayments();
    Task<Payment?> GetById(long id);
    Task<Decimal> GetSumByDay(DateTime dateTime);
    Task<long> GetCountPaymentsByDay(DateTime dateTime);
    Task<Decimal> GetTotalSum();
    Task<long> AddPayment(Payment payment);
}