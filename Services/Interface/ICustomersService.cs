using System.Threading.Tasks;
using ctrmmvp.DTOs.Customer;

namespace ctrmmvp.Services.Interface;

public interface ICustomersService
{
    Task<object> GetCustomersAsync();
    Task<object?> CreateCustomer(CreateCustomerRequest? createCustomer);    
}
