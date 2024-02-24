namespace ctrmmvp.DTOs.SalesOrder
{
    public class PurchaseOrderWithTaxRequest : PurchaseOrderRequest
    {
        public BoolValue IsTaxValid { get; set; }
        public StringValue Terms { get; set; }
        public StringValue Type { get; set; }
        public StringValue VendorID { get; set; }
        public StringValue VendorTaxZone { get; set; }

        public List<TaxDetail> TaxDetails { get; set; }
    }
}