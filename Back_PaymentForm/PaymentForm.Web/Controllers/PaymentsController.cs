using Microsoft.AspNetCore.Mvc;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.DtoModels;
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

    [HttpGet("getCreated")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetCreated()
    {
        return Ok(await service.GetCreatedPayments());
    }
    
    [HttpGet("getRejected")]
    public async Task<ActionResult<IEnumerable<Payment>>> GetRejected()
    {
        return Ok(await service.GetRejectedPayments());
    }

    [HttpGet("getSumDyDay")]
    public async Task<ActionResult<Decimal>> GetSumByDay([FromQuery] DateTime dateTime)
    {
        return Ok(await service.GetSumByDay(dateTime));
    }
    
    [HttpGet("getCountByDay")]
    public async Task<ActionResult<long>> GetCountByDay([FromQuery] DateTime dateTime)
    {
        return Ok(await service.GetCountPaymentsByDay(dateTime));
    }
    
    [HttpGet("geTotalSum")]
    public async Task<ActionResult<long>> GetTotalSum()
    {
        return Ok(await service.GetTotalSum());
    }
    
    [HttpPost("add")]
    public async Task<ActionResult<long>> Add(PaymentAddDto dto)
    {
        var id = await service.AddPayment(dto);
        
        return  id != null ? Ok(id) : BadRequest("Wallet not found or userId not own");
    }
}