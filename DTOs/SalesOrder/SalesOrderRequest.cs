namespace ctrmmvp.DTOs.PurchaseOrder
{
    public class SalesOrderRequest
    {
        public StringValue CustomerID { get; set; }
        public List<SalesOrderDetail> Details { get; set; }
    }

    public class SalesOrderDetail
    {
        public StringValue Branch { get; set; }
        public StringValue InventoryID { get; set; }
        public StringValue UOM { get; set; }
        public IntValue OrderQty { get; set; }
        public StringValue WarehouseID { get; set; }
    }
}