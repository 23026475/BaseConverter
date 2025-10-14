using NumberConverter.Models;

namespace NumberConverter.Service
{
    public class ConverterService
    {
        public ConversionResponse ConvertNumber(ConversionRequest request)
        {
            // Validate base (now 2–36)
            if (request.FromBase < 2 || request.FromBase > 36 || request.ToBase < 2 || request.ToBase > 36)
            {
                throw new Exception("Invalid Base. Supported bases: 2 to 36.");
            }

            if (!IsValidForBase(request.Input, request.FromBase))
            {
                throw new FormatException($"Input '{request.Input}' is not valid for base {request.FromBase}.");
            }

            // Convert input string from any base to decimal
            int decimalValue = 0;
            string input = request.Input.ToUpper();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                int digit = CharToDigit(c);
                if (digit >= request.FromBase)
                    throw new FormatException($"Digit '{c}' is invalid for base {request.FromBase}.");
                decimalValue = decimalValue * request.FromBase + digit;
            }

            // Convert decimal to target base
            string converted = DecimalToBase(decimalValue, request.ToBase);

            return new ConversionResponse
            {
                Original = input,
                FromBase = request.FromBase,
                ToBase = request.ToBase,
                Converted = converted
            };
        }

        // Helper: char to numeric value
        private int CharToDigit(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            return c - 'A' + 10; // 'A' -> 10, 'B' -> 11, ..., 'Z' -> 35
        }

        // Helper: convert decimal to any base (2–36)
        private string DecimalToBase(int decimalValue, int toBase)
        {
            if (decimalValue == 0) return "0";

            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            int value = decimalValue;
            while (value > 0)
            {
                int remainder = value % toBase;
                result = chars[remainder] + result;
                value /= toBase;
            }
            return result;
        }

        // Helper method: check if input string is valid for the base
        private bool IsValidForBase(string input, int fromBase)
        {
            input = input.ToUpper();
            string validChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, fromBase);
            foreach (char c in input)
            {
                if (!validChars.Contains(c))
                    return false;
            }
            return true;
        }
    }
}
