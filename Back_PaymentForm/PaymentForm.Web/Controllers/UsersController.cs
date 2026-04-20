using Microsoft.AspNetCore.Mvc;
using PaymentForm.Core.Abstractions.IServices;
using PaymentForm.Core.DtoModels;
using PaymentForm.Core.Models;

namespace PaymentForm.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        return Ok(await service.GetAll());
    }

    [HttpGet("getById")]
    public async Task<ActionResult<IEnumerable<User>>> GetById(long id)
    {
        return Ok(await service.GetById(id));
    }

    [HttpGet("getByEmial")]
    public async Task<ActionResult<IEnumerable<User>>> GetByEmail(string email)
    {
        return Ok(await service.GetByEmail(email));
    }

    [HttpPost("add")]
    public async Task<ActionResult<IEnumerable<User>>> Add([FromBody] UserAddDto dto)
    {
        try
        {
            return Ok(await service.Add(dto));
        }
        catch (Exception e)
        {
            return BadRequest($"The email already exist, {e.Message}");
        }
    }
}