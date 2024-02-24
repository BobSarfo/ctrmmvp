namespace ctrmmvp.Data.Models;

public class Employee
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public FinancialSettings FinancialSettings { get; set; }
    public EmployeeSettings EmployeeSettings { get; set; }
    public ContactInfo ContactInfo { get; set; }
}

public class FinancialSettings
{
    public string APAccount { get; set; }
    public string APSubaccount { get; set; }
    public string CashAccount { get; set; }
    public string ExpenseAccount { get; set; }
    public string ExpenseSubaccount { get; set; }
    public string PaymentMethod { get; set; }
    public string PrepaymentAccount { get; set; }
    public string PrepaymentSubaccount { get; set; }
    public string SalesAccount { get; set; }
    public string SalesSubaccount { get; set; }
    public string TaxZone { get; set; }
    public string Terms { get; set; }
}

public class EmployeeSettings
{
    public string BranchID { get; set; }
    public string Calendar { get; set; }
    public string CurrencyID { get; set; }
    public string CurrencyRateTypeID { get; set; }
    public string DepartmentID { get; set; }
    public string EmployeeClass { get; set; }
}

public class ContactInfo
{
    public string LastName { get; set; }
}
