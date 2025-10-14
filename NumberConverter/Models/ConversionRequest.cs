namespace NumberConverter.Models
{
    public class ConversionRequest
    {
        public string Input { get; set; } = string.Empty; // the value to convert
        public int FromBase { get; set; }                 // e.g., 2, 10, 16
        public int ToBase { get; set; }
    }
}
