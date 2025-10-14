namespace NumberConverter.Models
{
    public class ConversionResponse
    {
        public string Original { get; set; } = string.Empty;  // the input value
        public int FromBase { get; set; }                     // original base
        public int ToBase { get; set; }                       // target base
        public string Converted { get; set; } = string.Empty; // the resultgit 
    }
}
