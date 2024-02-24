namespace ctrmmvp.DTOs.SalesOrder
{
    public class PurchaseOrderTaxDetail : PurchaseOrderDetail
    {
        public StringValue BranchID { get; set; }
        public StringValue InventoryID { get; set; }
        public StringValue LineType { get; set; }
        public DecimalValueField UnitCost { get; set; }
        public StringValue OrderType { get; set; }
        public StringValue TaxCategory { get; set; }
    }
}