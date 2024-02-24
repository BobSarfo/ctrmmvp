using ctrmmvp.DTOs.SAContract;
using ctrmmvp.Services.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ctrmmvp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        [HttpGet("status")]
        public async Task<IActionResult> GetContractStatus()
        {
            var response = new ContractStatusResponse { Labels = ContractStatus.Labels, Values = ContractStatus.Values };

            return Ok(response);
        }
    }
}