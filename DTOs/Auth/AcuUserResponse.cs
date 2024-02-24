namespace ctrmmvp.DTOs.Auth
{
    public class AcuUserResponse : AcuApiResponseBase
    {
        public IntValue DefaultBranch { get; set; }
        public StringValue DefaultBranchBranch { get; set; }
        public StringValue Email { get; set; }
        public StringValue FirstName { get; set; }
        public StringValue LastName { get; set; }
        public StringValue Login { get; set; }
        public StringValue Status { get; set; }
    }
}