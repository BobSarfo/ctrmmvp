namespace ctrmmvp.DTOs.Auth
{
    public class AcuGetCompanyResponse : AcuApiResponseBase
    {
        public List<AcuGetBranchResponse> Branches { get; set; }
        public StringValue AccessRole { get; set; }
        public StringValue CompanyID { get; set; }
        public StringValue CompanyName { get; set; }
    }

    public class AcuGetBranchResponse : AcuApiResponseBase
    {
        public StringValue AccessRole { get; set; }
        public BoolValue Active { get; set; }
        public StringValue BranchID { get; set; }
        public StringValue BranchName { get; set; }
        public StringValue RoleDescription { get; set; }
    }
}