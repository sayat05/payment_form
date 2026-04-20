using Microsoft.AspNetCore.Mvc;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.Models;

namespace PaymentForm.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController(IPaymentService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetAll()
    {
        return Ok(await service.GetAll());
    }

    [HttpGet("getSuccess")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetSuccess()
    {
        return Ok(await service.GetSuccessPayments());
    }

    [HttpGet("getSumDyDay")]
    public async Task<ActionResult<Decimal>> GetSumByDay([FromQuery] DateTime dateTime)
    {
        var utcDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        return Ok(await service.GetSumByDay(utcDate));
    }
}