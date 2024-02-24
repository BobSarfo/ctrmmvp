namespace ctrmmvp.DTOs.SalesOrder
{
    public class PurchaseOrderRequest
    {
        public StringValue VendorID { get; set; }
        public StringValue Location { get; set; }
        public BoolValue Hold { get; set; }
        public List<PurchaseOrderDetail> Details { get; set; }
    }

    public class PurchaseOrderDetail
    {
        public StringValue BranchID { get; set; }
        public StringValue InventoryID { get; set; }
        public IntValue OrderQty { get; set; }
        public StringValue WarehouseID { get; set; }
        public StringValue UOM { get; set; }
    }

    public class TaxDetail
    {
        public StringValue Terms { get; set; }
        public StringValue Type { get; set; }
        public StringValue VendorID { get; set; }
        public StringValue VendorTaxZone { get; set; }
    }
}