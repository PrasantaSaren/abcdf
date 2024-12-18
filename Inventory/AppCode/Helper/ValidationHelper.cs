using System.Globalization;
using System.Text.RegularExpressions;

namespace Inventory.AppCode.Helper
{
    public static class ValidationHelper
    {
        public static bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsEmailpatternValid(string email)
        {
            // Basic email validation using regex
            // This regex pattern is simple and may not cover all cases
            const string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            // Validate phone number format using regex
            // Customize the pattern as per your needs
            const string phonePattern = @"^\+\d{1,3}-\d{3}-\d{3}-\d{4}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        public static bool IsPasswordStrong(string password)
        {
            // Password should contain at least 8 characters,
            // with at least one uppercase letter, one lowercase letter,
            // one number, and one special character.
            var hasMinimumLength = password.Length >= 8;
            var hasUppercase = password.Any(char.IsUpper);
            var hasLowercase = password.Any(char.IsLower);
            var hasDigit = password.Any(char.IsDigit);
            var hasSpecialCharacter = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasMinimumLength && hasUppercase && hasLowercase && hasDigit && hasSpecialCharacter;
        }

        public static bool IsNumberInRange(int number, int min, int max)
        {
            return number >= min && number <= max;
        }

        public static bool IsDateValid(string date)
        {
            // Date validation using DateTime.TryParseExact
            return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        public static bool IsZipCodeValid(string zipCode)
        {
            // Validate ZIP code format (US ZIP code format)
            const string zipPattern = @"^\d{5}(?:[-\s]\d{4})?$";
            return Regex.IsMatch(zipCode, zipPattern);
        }

        public static bool IsNumeric(string input)
        {
            double result;
            return double.TryParse(input, out result);
        }

        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsAgeValid(int age)
        {
            // Validate age within a reasonable range
            return age >= 0 && age <= 120; // Assuming a realistic age range
        }

        public static bool IsFileExtensionValid(string fileName, List<string> allowedExtensions)
        {
            // Validate file extension against a list of allowed extensions
            string extension = Path.GetExtension(fileName);
            return allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        public static bool IsCreditCardValid(string creditCardNumber)
        {
            // Validate credit card number using Luhn algorithm
            // Implementation of Luhn algorithm is required here
            // Check the card number's validity based on the algorithm
            return true;
        }
    }
}
