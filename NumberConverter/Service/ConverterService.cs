using NumberConverter.Models;

namespace NumberConverter.Service
{
    public class ConverterService
    {
        public ConversionResponse ConvertNumber(ConversionRequest request)
        {
            // ✅ Validate input characters for the given base
            if (!IsValidForBase(request.Input, request.FromBase))
            {
                throw new FormatException($"Input '{request.Input}' is not valid for base {request.FromBase}.");
            }

            try
            {
                // Convert input to decimal
                int decimalValue = Convert.ToInt32(request.Input, request.FromBase);

                // Convert decimal to target base
                string convertedValue = Convert.ToString(decimalValue, request.ToBase).ToUpper();

                return new ConversionResponse
                {
                    Original = request.Input.ToUpper(),
                    FromBase = request.FromBase,
                    ToBase = request.ToBase,
                    Converted = convertedValue
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error converting number: {ex.Message}");
            }
        }

        // ✅ Helper method: check if input string is valid for the base
        private bool IsValidForBase(string input, int fromBase)
        {
            input = input.ToUpper();

            string validChars = "0123456789ABCDEF".Substring(0, fromBase);
            foreach (char c in input)
            {
                if (!validChars.Contains(c))
                    return false;
            }
            return true;
        }
    }
}
