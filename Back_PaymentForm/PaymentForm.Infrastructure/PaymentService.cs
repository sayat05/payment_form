using PaymentForm.Core.Abstractions.IRepositories;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Enums;
using PaymentForm.Core.Models;

namespace PaymentForm.Infrastructure;

public class PaymentService(IPaymentRepository repository, IWalletRepository walletRepository) : IPaymentService
{
    public async Task<IEnumerable<PaymentResponseDto>> GetAll()
    {
        var payments = await repository.GetAll();

        return payments.Select(ConvertToPaymentResponse);
    }

    public async Task<(long, IEnumerable<PaymentResponseDto>)> GetCreatedPayments()
    {
        var payments = await repository.GetCreatedPayments();

        
        return (payments.Item1, payments.Item2.Select(ConvertToPaymentResponse));
    }

    public async Task<(long, IEnumerable<PaymentResponseDto>)> GetRejectedPayments()
    {
        var payments = await repository.GetRejectedPayments();

        return (payments.Item1, payments.Item2.Select(ConvertToPaymentResponse));
    }

    public async Task<PaymentResponseDto?> GetById(long id)
    {
        var payment = await repository.GetById(id);
        if (payment == null)
            return null;
        
        return ConvertToPaymentResponse(payment);
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

    public async Task<long?> AddPayment(PaymentAddDto dto)
    {
        var wallet = await walletRepository.GetWalletNumber(dto.WalletNumber);
        if (wallet == null || wallet.UserId != dto.UserId)
            return null;
        
        var status = dto.Amount > wallet.Balance ? PaymentStatus.Rejected : PaymentStatus.Created;
        
        return await repository.AddPayment(new Payment
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
            },
            Comment = dto.Comment,
            CreatedAt = DateTime.UtcNow
        });
    }

    private PaymentResponseDto ConvertToPaymentResponse(Payment payment)
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
            CreatedAt = payment.CreatedAt.ToString("d")
        };
    }
}