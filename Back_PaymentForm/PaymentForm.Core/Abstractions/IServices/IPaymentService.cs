using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Core.Abstractions.IServices;

public interface IPaymentService
{
    Task<IEnumerable<PaymentResponse>> GetAll();
    Task<IEnumerable<PaymentResponse>> GetSuccessPayments();
    Task<PaymentResponse?> GetById(long id);
    Task<Decimal> GetSumByDay(DateTime dateTime);
    Task<long> GetCountPaymentsByDay(DateTime dateTime);
    Task<Decimal> GetTotalSum();
    Task<long?> AddPayment(PaymentAddDto payment);
}