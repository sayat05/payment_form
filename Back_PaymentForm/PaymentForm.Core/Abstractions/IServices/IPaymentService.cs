using PaymentForm.Core.DtoModels;

namespace PaymentForm.Core.Abstractions.IServices;

public interface IPaymentService
{
    Task<IEnumerable<PaymentResponse>> GetAll();
    Task<IEnumerable<PaymentResponse>> GetCreatedPayments();
    Task<IEnumerable<PaymentResponse>> GetRejectedPayments();
    Task<PaymentResponse?> GetById(long id);
    Task<Decimal> GetSumByDay(DateTime dateTime);
    Task<long> GetCountPaymentsByDay(DateTime dateTime);
    Task<Decimal> GetTotalSum();
    Task<long?> AddPayment(PaymentAddDto payment);
}