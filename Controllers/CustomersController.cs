using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ctrmmvp.Services.Interface;
using ctrmmvp.DTOs.Customer;

namespace ctrmmvp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    ICustomersService _customersService;

    public CustomersController(ICustomersService customersService)
    {
        _customersService = customersService;
    }
    
    [HttpPut]
    public async Task<IActionResult> CreateCustomer(CreateCustomerRequest? createCustomer)
    {
        
        var result = await _customersService.CreateCustomer(createCustomer);
        
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
       
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var result = await _customersService.GetCustomersAsync();
        
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }
}
