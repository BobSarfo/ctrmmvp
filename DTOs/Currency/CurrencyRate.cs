using ctrmmvp.DTOs;

namespace ctrmmvp.Data.Currency;

public class EffectiveDate
{
    public DateTime value { get; set; }
}

public class CurrencyEffectiveDate
{
    public DateTime value { get; set; }
}

public class CurrencyRate
{
    public double value { get; set; }
}

public class CurrencyRateType
{
    public string value { get; set; }
}

public class CuryRateID
{
    public int value { get; set; }
}

public class FromCurrency
{
    public string value { get; set; }
}

public class MultDiv
{
    public string value { get; set; }
}

public class RateReciprocal
{
    public double value { get; set; }
}

public class EffectiveRate
{
    public string id { get; set; }
    public int rowNumber { get; set; }
    public object note { get; set; }
    public CurrencyEffectiveDate CurrencyEffectiveDate { get; set; }
    public CurrencyRate CurrencyRate { get; set; }
    public CurrencyRateType CurrencyRateType { get; set; }
    public CuryRateID CuryRateID { get; set; }
    public FromCurrency FromCurrency { get; set; }
    public MultDiv MultDiv { get; set; }
    public RateReciprocal RateReciprocal { get; set; }
    public Dictionary<string, object> custom { get; set; }
}

public class CurrencyRates
{
    public string id { get; set; }
    public int rowNumber { get; set; }
    public object note { get; set; }
    public EffectiveDate EffectiveDate { get; set; }
    public List<EffectiveRate> EffectiveRates { get; set; }
    public StringValue ToCurrency { get; set; }
    public Object custom { get; set; }
}