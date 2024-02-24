using ctrmmvp.DTOs.SAContract;
using ctrmmvp.Services.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        public async Task<IActionResult> GetAllContractsAsync()
        {
            throw new NotImplementedException();
        }
    }
}