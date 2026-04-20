using PaymentForm.Core.Abstractions.IRepositories;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Infrastructure;

public class PaymentService(IPaymentRepository repository) : IPaymentService
{
    public async Task<IEnumerable<PaymentResponse>> GetAll()
    {
        var payments = await repository.GetAll();

        return payments.Select(ConvertToPaymentResponse);
    }

    public async Task<IEnumerable<PaymentResponse>> GetSuccessPayments()
    {
        var payments = await repository.GetSuccessPayments();

        return payments.Select(ConvertToPaymentResponse);
    }

    public async Task<PaymentResponse> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<decimal> GetSumByDay(DateTime dateTime)
    {
        return await repository.GetSumByDay(dateTime);
    }

    public async Task<long> GetCountPaymentsByDay(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public async Task<decimal> GetTotalSum()
    {
        throw new NotImplementedException();
    }

    public async Task<long> AddPayment(PaymentAddDto payment)
    {
        throw new NotImplementedException();
    }

    private PaymentResponse ConvertToPaymentResponse(Payment payment)
    {
        return new PaymentResponse
        {
            Id = payment.Id,
            WalletId = payment.WalletId,
            Email = payment.Email,
            Currency = payment.Currency.ToString(),
            Status = payment.Status.ToString(),
            Amount = payment.Amount,
            Comment = payment.Comment,
            CreatedAt = payment.CreatedAt.ToString("d")
        };
    }
}