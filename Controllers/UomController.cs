using ctrmmvp.Extensions;
using ctrmmvp.Services.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ctrmmvp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UomController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUom()
        {
            var token = User.GetUserAcumaticaToken();

            var result = await UOMService.GetUOMAsync(token);

            return Ok(result);
        }
    }
}