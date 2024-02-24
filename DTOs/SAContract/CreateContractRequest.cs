namespace ctrmmvp.DTOs.SAContract
{
    public class CreateContractRequest
    {
        public DateTime ContractDate { get; set; }
        public string Commodity { get; set; }

        public string PricingType { get; set; }
        public string PurchaseOrSale { get; set; }
        public string ProductCode { get; set; }

        public string Origin { get; set; }

        public string ConterpartyId { get; set; }
        public string ConterpartyRef { get; set; }

        public string Doctype { get; set; }
        public decimal Franchise { get; set; }
        public decimal Tolerance { get; set; }

        public decimal Quantity { get; set; }
        public string UOM { get; set; }
        public string ContractCury { get; set; }
    }
}