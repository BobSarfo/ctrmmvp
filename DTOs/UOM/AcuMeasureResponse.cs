namespace ctrmmvp.DTOs.UOM
{
    public class AcuUOMResponse
    {
        public List<AcuUom> AcuUOMResponses { get; set; }
    }

    public class AcuUom : AcuApiResponseBase
    {
        public DecimalValueField ConversionFactor { get; set; }
        public StringValue FromUOM { get; set; }
        public StringValue MultiplyOrDivide { get; set; }
        public StringValue ToUOM { get; set; }
        public DateTimeValue CreatedDateTime { get; set; }
        public DateTimeValue LastModifiedDateTime { get; set; }
    }
}