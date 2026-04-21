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
    public async Task<ActionResult<Wallet>> GetById(long id)
    {
        return Ok(await service.GetById(id));
    }
    
    [HttpGet("getByWalletNumber")]
    public async Task<ActionResult<Wallet>> GetByWalletNumber(string walletNumber)
    {
        return Ok(await service.GetByWalletNumber(walletNumber));
    }
    
    [HttpPost("add")]
    public async Task<ActionResult<long>> Add(WalletAddDto dto)
    {
        var id = await service.Add(dto);
        return id != null ? Ok(id) : BadRequest("User id not found");
    }
    
    [HttpPut("update")]
    public async Task<ActionResult<bool>> Update(WalletUpdateDto dto)
    {
        var result = await service.Update(dto);
        return result != null ? Ok(result) : BadRequest("Wallet id not found");
    }
}