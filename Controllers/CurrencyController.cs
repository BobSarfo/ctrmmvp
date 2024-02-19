using Microsoft.AspNetCore.Mvc;

namespace ctrmmvp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    
    // Method to get customers
    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync()
    {
        return Ok();
    }
}
