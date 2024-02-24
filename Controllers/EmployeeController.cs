using Microsoft.AspNetCore.Mvc;
using ctrmmvp.Services.Interface;
using ctrmmvp.DTOs.Employee;

namespace ctrmmvp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpPut]
    public async Task<IActionResult> CreateCustomer(CreateEmployeeRequestDto? createEmployee)
    {
        
        var result = await _employeeService.CreateEmployee(createEmployee);
        
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
       
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var result = await _employeeService.GetEmployeesAsync();
        
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }
}
