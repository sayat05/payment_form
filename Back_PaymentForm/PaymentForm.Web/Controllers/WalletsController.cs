using Microsoft.AspNetCore.Mvc;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WalletsController(IWalletService service) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wallet>>> GetAll()
    {
        return Ok(await service.GetAll());
    }
    
    [HttpGet("getByUserId")]
    public async Task<ActionResult<IEnumerable<Wallet>>> GetByUserId(long userId)
    {
        return Ok(await service.GetByUserId(userId));
    }
    
    [HttpGet("getById")]
    public async Task<ActionResult<IEnumerable<Wallet>>> GetById(long id)
    {
        return Ok(await service.GetById(id));
    }
    
    [HttpGet("getWalletNumber")]
    public async Task<ActionResult<IEnumerable<Wallet>>> GetWalletNumber(string walletNumber)
    {
        return Ok(await service.GetWalletNumber(walletNumber));
    }
    
    [HttpGet("add")]
    public async Task<ActionResult<IEnumerable<Wallet>>> Add(WalletAddDto dto)
    {
        var id = await service.Add(dto);
        return id != null ? Ok(id) : BadRequest("User id not found");
    }
}