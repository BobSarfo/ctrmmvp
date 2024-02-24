using ctrmmvp.DTOs.Customer;
using System.Text;
using ctrmmvp.Services.Interface;
using ctrmmvp.Data;
using ctrmmvp.Data.Models;
using Address = ctrmmvp.Data.Models.Address;

namespace ctrmmvp.Services;

public class CustomersService : ICustomersService
{
    private readonly CtrmDbContext _context;
    public async Task<object> GetCustomersAsync()
    {
        var url = @"http://acumatica.local/dev2/entity/Default/20.200.001/Customer/01a0c017-df7f-ea11-8175-b9d61cb73193?$expand=MainContact/Address&$select=CustomerID,CustomerSName,CustomerClass,MainContact/Email,MainContact/Phone1,MainContact/Address/AddressLine1,MainContact/Address/AddressLine2,MainContact/Address/City,MainContact/Address/State,MainContact/Address/PostalCode";

        // Create an instance of HttpClientd
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Create a StringContent object with the JSON data
                StringContent content = new StringContent("{}", Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.GetAsync(url);

                // Check if the request was successful (status code 200-299)
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("POST request successful!");

                    var data = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"POST request failed with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //for generic inquire ... put with empty {}endpoint..endpointversion
        //$expand=Results
        //{fieldName:{value: ####}}

        return new object();
    }

    public async Task<object?> CreateCustomer(CreateCustomerRequest? createCustomer)
    {
        if (createCustomer == null)
            return null;

        
        var customer = new Customer
        {
            Id = int.Parse(createCustomer.CustomerID.value),
            Name = createCustomer.CustomerName.value,
            Class = createCustomer.CustomerClass.value,
            MainContact = new Contact
            {
                Email = createCustomer.MainContact.Email.value,
                Address = new Address
                {
                    AddressLine1 = createCustomer.MainContact.Address.AddressLine1.value,
                    AddressLine2 = createCustomer.MainContact.Address.AddressLine2.value,
                    City = createCustomer.MainContact.Address.City.value,
                    State = createCustomer.MainContact.Address.State.value,
                    PostalCode = createCustomer.MainContact.Address.PostalCode.value
                }
            }
        };
        
        _context.Customers.Add(customer);
        
        await _context.SaveChangesAsync();

        return customer;
    }
}
