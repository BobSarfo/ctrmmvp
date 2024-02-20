namespace ctrmmvp.DTOs.Customer
{
    public class Address
    {
        public StringValueField AddressLine1 { get; set; }
        public StringValueField AddressLine2 { get; set; }
        public StringValueField City { get; set; }
        public StringValueField State { get; set; }
        public StringValueField PostalCode { get; set; }
    }

    public class MainContact
    {
        public StringValueField Email { get; set; }
        public Address Address { get; set; }
    }

    public class CreateCustomerRequest
    {
        public StringValueField CustomerID { get; set; }
        public StringValueField CustomerName { get; set; }
        public StringValueField CustomerClass { get; set; }
        public MainContact MainContact { get; set; }
    }
}