namespace ctrmmvp.Data.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public Contact MainContact { get; set; }
}

public class Contact
{
    public string Email { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
}
