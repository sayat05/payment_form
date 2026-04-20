using PaymentForm.Core.Abstractions.IRepositories;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Enums;
using PaymentForm.Core.Models;

namespace PaymentForm.Infrastructure.Services;

public class PaymentService(IPaymentRepository repository, IWalletRepository walletRepository) : IPaymentService
{
    public async Task<IEnumerable<PaymentResponseDto>> GetAll()
    {
        var payments = await repository.GetAll();

        return payments.Select(ToPaymentResponse);
    }

    public async Task<(long count, IEnumerable<PaymentResponseDto> payments)> GetCreatedPayments()
    {
        var payments = await repository.GetCreatedPayments();

        
        return (payments.count, payments.payments.Select(ToPaymentResponse));
    }

    public async Task<(long count, IEnumerable<PaymentResponseDto> payments)> GetRejectedPayments()
    {
        var payments = await repository.GetRejectedPayments();

        return (payments.count, payments.payments.Select(ToPaymentResponse));
    }

    public async Task<PaymentResponseDto?> GetById(long id)
    {
        var payment = await repository.GetById(id);
        if (payment == null)
            return null;
        
        return ToPaymentResponse(payment);
    }

    public async Task<decimal> GetSumByDay(DateTime dateTime)
    {
        var utcDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        return await repository.GetSumByDay(utcDate);
    }

    public async Task<long> GetCountPaymentsByDay(DateTime dateTime)
    {
        var utcDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        return await repository.GetCountPaymentsByDay(utcDate);
    }

    public async Task<decimal> GetTotalSum()
    {
        return await repository.GetTotalSum();
    }

    public async Task<(string status, long? id)> AddPayment(PaymentAddDto dto)
    {
        var wallet = await walletRepository.GetWalletNumber(dto.WalletNumber);
        if (wallet == null || wallet.UserId != dto.UserId)
            return (nameof(PaymentStatus.Rejected), null);
        
        var status = dto.Amount > wallet.Balance ? PaymentStatus.Rejected : PaymentStatus.Created;
        
        var id = await repository.AddPayment(new Payment
        {
            WalletId = wallet.Id,
            Email = dto.Email,
            Amount = dto.Amount,
            Status = status,
            Currency = dto.Currency switch
            {
                "Usd" => CurrencyType.Usd,
                "Euro" => CurrencyType.Euro,
                "Rub" => CurrencyType.Rub,
                "Kzt" => CurrencyType.Kzt,
                "Uzs" => CurrencyType.Uzs,
                _ => throw new ArgumentOutOfRangeException($"Curency type doesnt match")
            },
            Comment = dto.Comment,
            CreatedAt = DateTime.UtcNow
        });

        return status == PaymentStatus.Created ? (nameof(PaymentStatus.Created), id) : (nameof(PaymentStatus.Rejected), id);
    }

    private PaymentResponseDto ToPaymentResponse(Payment payment)
    {
        return new PaymentResponseDto
        {
            Id = payment.Id,
            WalletId = payment.WalletId,
            Email = payment.Email,
            Currency = payment.Currency.ToString(),
            Status = payment.Status.ToString(),
            Amount = payment.Amount,
            Comment = payment.Comment,
            CreatedAt = payment.CreatedAt.ToLocalTime().ToString("d")
        };
    }
}