using System;
using System.Text;
using System.Threading.Tasks;

namespace ctrmmvp.Services
{
    public class CustomersService
    {
        public async Task<object> GetCustomersAsync()
        {
            var url = @"http://acumatica.local/dev2/entity/Default/20.200.001/Customer/01a0c017-df7f-ea11-8175-b9d61cb73193?$expand=MainContact/Address&$select=CustomerID,CustomerName,CustomerClass,MainContact/Email,MainContact/Phone1,MainContact/Address/AddressLine1,MainContact/Address/AddressLine2,MainContact/Address/City,MainContact/Address/State,MainContact/Address/PostalCode";

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
    }
}