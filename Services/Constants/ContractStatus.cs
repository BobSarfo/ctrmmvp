namespace ctrmmvp.Services.Constants
{
    public static class ContractStatus
    {
        public static readonly List<string> Values = new() { OnHold, ToBeFixed, PartiallyFixed, FullyFixed, Confirmed, Shipment, Delivery, Completed, Deactivated };
        public static readonly List<string> Labels = new() { "On Hold", "To Be Fixed", "Partially Fixed", "Fully Fixed", "Confirmed", "Shipment", "Delivery", "Completed", "Deactivated" };

        public const string OnHold = "OH";
        public const string ToBeFixed = "TF";
        public const string PartiallyFixed = "PD";
        public const string FullyFixed = "FF";
        public const string Confirmed = "CD";
        public const string Shipment = "SH";
        public const string Delivery = "DL";
        public const string Completed = "CO";
        public const string Deactivated = "DE";
    }
}