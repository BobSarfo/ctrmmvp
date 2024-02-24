using ctrmmvp.DTOs.Employee;

namespace ctrmmvp.Services.Interface;

public interface IEmployeeService
{
    public Task<object?> CreateEmployee(CreateEmployeeRequestDto? createEmployee);
    public Task<object> GetEmployeesAsync();
}
