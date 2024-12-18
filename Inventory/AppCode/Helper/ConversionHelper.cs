using System.Text.Json;

namespace Inventory.AppCode.Helper
{
    public static class ConversionHelper
    {

        // 1. String to Int
        public static int StringToInt(string value)
        {
            int result;
            int.TryParse(value, out result);
            return result;
        }

        // 2. String to Double
        public static double StringToDouble(string value)
        {
            double result;
            double.TryParse(value, out result);
            return result;
        }

        // 3. String to Decimal
        public static decimal StringToDecimal(string value)
        {
            decimal result;
            decimal.TryParse(value, out result);
            return result;
        }

        // 4. String to DateTime
        public static DateTime StringToDateTime(string value)
        {
            DateTime result;
            DateTime.TryParse(value, out result);
            return result;
        }

        // 5. Int to String
        public static string IntToString(int value)
        {
            return value.ToString();
        }

        // 6. Double to String
        public static string DoubleToString(double value)
        {
            return value.ToString();
        }

        // 7. Decimal to String
        public static string DecimalToString(decimal value)
        {
            return value.ToString();
        }

        // 8. DateTime to String
        public static string DateTimeToString(DateTime value)
        {
            return value.ToString();
        }

        // 9. String to Boolean
        public static bool StringToBoolean(string value)
        {
            bool result;
            bool.TryParse(value, out result);
            return result;
        }

        // 10. Boolean to String
        public static string BooleanToString(bool value)
        {
            return value.ToString();
        }

        // 11. Object to JSON string
        public static string ObjectToJsonString(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        // 12. JSON string to Object
        public static T? JsonStringToObject<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        // 13. Enum to String
        public static string? EnumToString<T>(T value)
        {
            return value?.ToString();
        }

        // 14. String to Enum
        public static T StringToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        // 15. String to Guid
        public static Guid StringToGuid(string value)
        {
            Guid result;
            Guid.TryParse(value, out result);
            return result;
        }

        // 16. Guid to String
        public static string GuidToString(Guid value)
        {
            return value.ToString();
        }

        // 17. Bytes to Base64 string
        public static string BytesToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        // 18. Base64 string to Bytes
        public static byte[] Base64ToBytes(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        // 19. Enum to Int
        public static int EnumToInt<T>(T value) where T : Enum
        {
            return Convert.ToInt32(value);
        }

        // 20. Int to Enum
        public static T IntToEnum<T>(int value) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}
