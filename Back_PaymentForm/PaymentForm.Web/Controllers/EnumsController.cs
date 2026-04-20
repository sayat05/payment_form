using Microsoft.AspNetCore.Mvc;
using PaymentForm.Core.Enums;

namespace PaymentForm.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class EnumsController : ControllerBase
{
    [HttpGet("currencies")]
    public ActionResult<IEnumerable<string>> GetAllCurrencyType()
    {
        var currencies = Enum.GetNames(typeof(CurrencyType));
        return Ok(currencies);
    }
}