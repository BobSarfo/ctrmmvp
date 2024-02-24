namespace ctrmmvp.DTOs.Customer
{
    public class Address
    {
        public StringValue AddressLine1 { get; set; }
        public StringValue AddressLine2 { get; set; }
        public StringValue City { get; set; }
        public StringValue State { get; set; }
        public StringValue PostalCode { get; set; }
    }

    public class MainContact
    {
        public StringValue Email { get; set; }
        public Address Address { get; set; }
    }

    public class CreateCustomerRequest
    {
        public StringValue CustomerID { get; set; }
        public StringValue CustomerName { get; set; }
        public StringValue CustomerClass { get; set; }
        public MainContact MainContact { get; set; }
    }
}