using System.Text;
using ctrmmvp.Data;
using ctrmmvp.Data.Models;
using ctrmmvp.DTOs.Employee;
using ctrmmvp.Services.Interface;

namespace ctrmmvp.Services.Implementation;

public class EmployeeService : IEmployeeService
{
   private CtrmDbContext _context;
   
   public async Task<object?> CreateEmployee(CreateEmployeeRequestDto? createEmployee)  
{
    if (createEmployee == null)
        return null;

    var employee = new Employee
    {
        Status = createEmployee.Status.Value,
        EmployeeID = createEmployee.EmployeeID.Value,
        EmployeeName = createEmployee.EmployeeName.Value,
        FinancialSettings = new FinancialSettings
        {
            APAccount = createEmployee.FinancialSettings.APAccount.Value,
            APSubaccount = createEmployee.FinancialSettings.APSubaccount.Value,
            CashAccount = createEmployee.FinancialSettings.CashAccount.Value,
            ExpenseAccount = createEmployee.FinancialSettings.ExpenseAccount.Value,
            ExpenseSubaccount = createEmployee.FinancialSettings.ExpenseSubaccount.Value,
            PaymentMethod = createEmployee.FinancialSettings.PaymentMethod.Value,
            PrepaymentAccount = createEmployee.FinancialSettings.PrepaymentAccount.Value,
            PrepaymentSubaccount = createEmployee.FinancialSettings.PrepaymentSubaccount.Value,
            SalesAccount = createEmployee.FinancialSettings.SalesAccount.Value,
            SalesSubaccount = createEmployee.FinancialSettings.SalesSubaccount.Value,
            TaxZone = createEmployee.FinancialSettings.TaxZone.Value,
            Terms = createEmployee.FinancialSettings.Terms.Value
        },
        EmployeeSettings = new EmployeeSettings
        {
            BranchID = createEmployee.EmployeeSettings.BranchID.Value,
            Calendar = createEmployee.EmployeeSettings.Calendar.Value,
            CurrencyID = createEmployee.EmployeeSettings.CurrencyID.Value,
            CurrencyRateTypeID = createEmployee.EmployeeSettings.CurrencyRateTypeID.Value,
            DepartmentID = createEmployee.EmployeeSettings.DepartmentID.Value,
            EmployeeClass = createEmployee.EmployeeSettings.EmployeeClass.Value
        },
        ContactInfo = new ContactInfo
        {
            LastName = createEmployee.ContactInfo.LastName.Value
        }
    };

    _context.Employees.Add(employee);

    await _context.SaveChangesAsync();

    return employee;
}
public async Task<object> GetEmployeesAsync()
{
    var url = @"http://acumatica.local/dev2/entity/Default/20.200.001/Employee";

    using (HttpClient client = new HttpClient())
    {
        try
        {
            StringContent content = new StringContent("{}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("GET request successful!");

                var data = await response.Content.ReadAsStringAsync();
                return data;
            }
            else
            {
                Console.WriteLine($"GET request failed with status code {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    return new object();
}
}
