using ctrmmvp.Extensions;
using ctrmmvp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ctrmmvp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CurrencyController : ControllerBase
{
    private readonly ICurrenciesService _currenciesService;

    public CurrencyController(ICurrenciesService currenciesService)
    {
        _currenciesService = currenciesService;
    }

    [HttpGet("{currency}")]
    public async Task<IActionResult> GetCurrencies(string currency)
    {
        var token = User.GetUserAcumaticaToken();
        var result = await _currenciesService.GetCurrenciesAsync(currency, token);
        return Ok(result);
    }
}