namespace ctrmmvp.Data.Currency;

public class ToCurrencyRequest
{
    public Value ToCurrency { get; set; }
}

public class Value
{
    public string value { get; set; }
}