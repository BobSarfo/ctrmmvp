namespace ctrmmvp.DTOs
{
    public class AcuApiResponseBase
    {
        public string id { get; set; }
        public int rowNumber { get; set; }
        public StringValue note { get; set; }
        public object custom { get; set; }
        public Links _links { get; set; }
    }
    public class Links
    {
        public string self { get; set; }
        public string files_put { get; set; }
    }

}