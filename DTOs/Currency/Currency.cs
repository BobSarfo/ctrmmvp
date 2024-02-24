namespace ctrmmvp.DTOs.Currency
{
    public class Currency : AcuApiResponseBase
    {
        public BoolValue Active { get; set; }
        public DateTimeValue CreatedDateTime { get; set; }
        public StringValue CurrencyID { get; set; }
        public StringValue CurrencySymbol { get; set; }
        public StringValue Description { get; set; }
        public BoolValue UseForAccounting { get; set; }
    }
}