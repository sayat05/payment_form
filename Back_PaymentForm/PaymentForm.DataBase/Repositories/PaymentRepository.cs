using Microsoft.EntityFrameworkCore;
using PaymentForm.Core.Abstractions.IRepositories;
using PaymentForm.Core.Enums;
using PaymentForm.Core.Models;
using PaymentForm.DataBase.DataBase;
using PaymentForm.DataBase.EfCoreModels;

namespace PaymentForm.DataBase.Repositories;

public class PaymentRepository(MyAppContext context) : IPaymentRepository
{
    public async Task<IEnumerable<Payment>> GetAll()
    {
        var paymentsEfCore = await context.Payments.AsNoTracking().ToListAsync();

        return paymentsEfCore.Select(ConvertorToPayment);
    }

    public async Task<IEnumerable<Payment>> GetSuccessPayments()
    {
        var paymentsEfCore = await context.Payments
            .AsNoTracking()
            .Where(p => p.Status == PaymentStatus.Created)
            .ToListAsync();

        return paymentsEfCore.Select(ConvertorToPayment);
    }

    public async Task<Payment?> GetById(long id)
    {
        var paymentEfCore = await context.Payments.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (paymentEfCore == null)
            return null;

        return ConvertorToPayment(paymentEfCore);
    }

    /// <summary>
    /// Сумма за день
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public async Task<decimal> GetSumByDay(DateTime dateTime)
    {
        return await context.Payments.Where(p => p.CreatedAt.Date == dateTime.Date).SumAsync(p => p.Amount);
    }

    /// <summary>
    /// Количество платежей за день
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public async Task<long> GetCountPaymentsByDay(DateTime dateTime)
    {
        return await context.Payments.CountAsync(p => p.CreatedAt.Date == dateTime);
    }

    public async Task<decimal> GetTotalSum()
    {
        return await context.Payments.SumAsync(p => p.Amount);
    }

    public async Task<long> AddPayment(Payment payment)
    {
        var entity = await context.Payments.AddAsync(new PaymentEfCore
        {
            WalletId = payment.WalletId,
            Email = payment.Email,
            Amount = payment.Amount,
            Currency = payment.Currency,
            Status = payment.Status,
            Comment = payment.Comment,
            CreatedAt = payment.CreatedAt
        });
        
        if (entity.Entity.Status == PaymentStatus.Created)
        {
            var wallet = await context.Wallets.FirstOrDefaultAsync(w => w.Id == entity.Entity.WalletId);
            wallet!.Balance -= entity.Entity.Amount;
        }
        
        await context.SaveChangesAsync();
        return entity.Entity.Id;
    }


    private Payment ConvertorToPayment(PaymentEfCore efCore)
    {
        return new Payment
        {
            Id = efCore.Id,
            WalletId = efCore.WalletId,
            Email = efCore.Email,
            Amount = efCore.Amount,
            Currency = efCore.Currency,
            Status = efCore.Status,
            Comment = efCore.Comment ?? "Unknown",
            CreatedAt = efCore.CreatedAt
        };
    }
}