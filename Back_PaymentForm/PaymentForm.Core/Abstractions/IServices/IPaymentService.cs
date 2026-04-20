using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Enums;

namespace PaymentForm.Core.Abstractions.IServices;

public interface IPaymentService
{
    Task<IEnumerable<PaymentResponseDto>> GetAll();
    Task<(long count, IEnumerable<PaymentResponseDto> payments)> GetCreatedPayments();
    Task<(long count, IEnumerable<PaymentResponseDto> payments)> GetRejectedPayments();
    Task<PaymentResponseDto?> GetById(long id);
    Task<Decimal> GetSumByDay(DateTime dateTime);
    Task<long> GetCountPaymentsByDay(DateTime dateTime);
    Task<Decimal> GetTotalSum();
    Task<(string status, long? id)> AddPayment(PaymentAddDto payment);
}