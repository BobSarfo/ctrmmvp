namespace ctrmmvp.DTOs.Employee;

public class CreateEmployeeRequestDto
{
    public ValueDto Status { get; set; }
    public ValueDto EmployeeID { get; set; }
    public ValueDto EmployeeName { get; set; }
    public FinancialSettingsDto FinancialSettings { get; set; }
    public EmployeeSettingsDto EmployeeSettings { get; set; }
    public ContactInfoDto ContactInfo { get; set; }
}

public class ValueDto
{
    public string Value { get; set; }
}

public class FinancialSettingsDto
{
    public ValueDto APAccount { get; set; }
    public ValueDto APSubaccount { get; set; }
    public ValueDto CashAccount { get; set; }
    public ValueDto ExpenseAccount { get; set; }
    public ValueDto ExpenseSubaccount { get; set; }
    public ValueDto PaymentMethod { get; set; }
    public ValueDto PrepaymentAccount { get; set; }
    public ValueDto PrepaymentSubaccount { get; set; }
    public ValueDto SalesAccount { get; set; }
    public ValueDto SalesSubaccount { get; set; }
    public ValueDto TaxZone { get; set; }
    public ValueDto Terms { get; set; }
}

public class EmployeeSettingsDto
{
    public ValueDto BranchID { get; set; }
    public ValueDto Calendar { get; set; }
    public ValueDto CurrencyID { get; set; }
    public ValueDto CurrencyRateTypeID { get; set; }
    public ValueDto DepartmentID { get; set; }
    public ValueDto EmployeeClass { get; set; }
}

public class ContactInfoDto
{
    public ValueDto LastName { get; set; }
}
