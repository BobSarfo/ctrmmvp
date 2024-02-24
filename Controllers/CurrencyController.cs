using ctrmmvp.Extensions;
using ctrmmvp.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ctrmmvp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CurrencyController : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetCurrenciesAsync()
    {
        var token = User.GetUserAcumaticaToken();
        var result = await CurrenciesService.GetCurrenciesAsync(token);
        return Ok(result);
    }

    [HttpGet("{currencyTo}")]
    public async Task<IActionResult> GetCurrencies(string currencyTo)
    {
        var token = User.GetUserAcumaticaToken();
        var result = await CurrenciesService.GetCurrenciesToAsync(currencyTo, token);
        return Ok(result);
    }
}