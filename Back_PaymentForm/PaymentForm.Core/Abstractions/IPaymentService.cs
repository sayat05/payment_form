using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAll();
    Task<IEnumerable<Payment>> GetSuccessPayments();
    Task<Payment> GetById(long id);
    Task<Decimal> GetSumByDay(DateTime dateTime);
    Task<long> GetCountPaymentsByDay(DateTime dateTime);
    Task<Decimal> GetTotalSum();
    Task<long> AddPayment(PaymentAddDto payment);
}