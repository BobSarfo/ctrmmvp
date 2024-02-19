using System;

namespace ctrmmvp.Data.Models;

public class Note
{
    public string value { get; set; }
}

public class ApplyOverdueCharges
{
    public bool value { get; set; }
}

public class AutoApplyPayments
{
    public bool value { get; set; }
}

public class BillingAddressOverride
{
    public bool value { get; set; }
}

public class BillingContactOverride
{
    public bool value { get; set; }
}

public class CreatedDateTime
{
    public DateTime value { get; set; }
}

public class CurrencyID
{
    public string value { get; set; }
}

public class CustomerClass
{
    public string value { get; set; }
}

public class CustomerID
{
    public string value { get; set; }
}

public class CustomerName
{
    public string value { get; set; }
}

public class EnableCurrencyOverride
{
    public bool value { get; set; }
}

public class EnableRateOverride
{
    public bool value { get; set; }
}

public class EnableWriteOffs
{
    public bool value { get; set; }
}

public class LastModifiedDateTime
{
    public DateTime value { get; set; }
}

public class LocationName
{
    public string value { get; set; }
}

public class MultiCurrencyStatements
{
    public bool value { get; set; }
}

public class OrderPriority
{
    public int value { get; set; }
}

public class PrintDunningLetters
{
    public bool value { get; set; }
}

public class PrintInvoices
{
    public bool value { get; set; }
}

public class PrintStatements
{
    public bool value { get; set; }
}

public class ResidentialDelivery
{
    public bool value { get; set; }
}

public class SaturdayDelivery
{
    public bool value { get; set; }
}

public class SendDunningLettersbyEmail
{
    public bool value { get; set; }
}

public class SendInvoicesbyEmail
{
    public bool value { get; set; }
}

public class SendStatementsbyEmail
{
    public bool value { get; set; }
}

public class ShippingRule
{
    public string value { get; set; }
}

public class StatementCycleID
{
    public string value { get; set; }
}

public class StatementType
{
    public string value { get; set; }
}

public class Status
{
    public string value { get; set; }
}

public class Terms
{
    public string value { get; set; }
}

public class WriteOffLimit
{
    public double value { get; set; }
}
    public class AcuCustomerResponse    
{
    public string id { get; set; }
    public int rowNumber { get; set; }
    public Note note { get; set; }
    public ApplyOverdueCharges ApplyOverdueCharges { get; set; }
    public AutoApplyPayments AutoApplyPayments { get; set; }
    public BillingAddressOverride BillingAddressOverride { get; set; }
    public BillingContactOverride BillingContactOverride { get; set; }
    public CreatedDateTime CreatedDateTime { get; set; }
    public CurrencyID CurrencyID { get; set; }
    public CustomerClass CustomerClass { get; set; }
    public CustomerID CustomerID { get; set; }
    public CustomerName CustomerName { get; set; }
    public EnableCurrencyOverride EnableCurrencyOverride { get; set; }
    public EnableRateOverride EnableRateOverride { get; set; }
    public EnableWriteOffs EnableWriteOffs { get; set; }
    public LastModifiedDateTime LastModifiedDateTime { get; set; }
    public LocationName LocationName { get; set; }
    public MultiCurrencyStatements MultiCurrencyStatements { get; set; }
    public OrderPriority OrderPriority { get; set; }
    public PrintDunningLetters PrintDunningLetters { get; set; }
    public PrintInvoices PrintInvoices { get; set; }
    public PrintStatements PrintStatements { get; set; }
    public ResidentialDelivery ResidentialDelivery { get; set; }
    public SaturdayDelivery SaturdayDelivery { get; set; }
    public SendDunningLettersbyEmail SendDunningLettersbyEmail { get; set; }
    public SendInvoicesbyEmail SendInvoicesbyEmail { get; set; }
    public SendStatementsbyEmail SendStatementsbyEmail { get; set; }
    public ShippingRule ShippingRule { get; set; }
    public StatementCycleID StatementCycleID { get; set; }
    public StatementType StatementType { get; set; }
    public Status Status { get; set; }
    public Terms Terms { get; set; }
    public WriteOffLimit WriteOffLimit { get; set; }
    public object custom { get; set; }
    public Links _links { get; set; }
}

public class Links
{
    public string self { get; set; }
    public string files_put { get; set; }
}
