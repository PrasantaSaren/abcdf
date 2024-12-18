using System.Security.Cryptography;
using System.Text;

namespace Inventory.AppCode.Helper
{
//    // Generating an OTP
//    string secretKey = "YourSecretKey"; // Replace with your secret key
//    string generatedOTP = OTPHelper.GenerateOTP(secretKey);
//    Console.WriteLine("Generated OTP: " + generatedOTP);

//// Verifying an OTP
//string userEnteredOTP = "UserEnteredOTP"; // Replace with user input
//    bool isValidOTP = OTPHelper.VerifyOTP(secretKey, userEnteredOTP);
//    Console.WriteLine("Is OTP valid? " + isValidOTP);

    public static class OTPHelper
    {
        private const int TotpSize = 6;
        private const int IntervalDuration = 30;

        public static string GenerateOTP(string secretKey)
        {
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            long timeStepCounter = GetCurrentTimeStep();

            byte[] counter = BitConverter.GetBytes(timeStepCounter);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(counter);
            }

            HMACSHA1 hmac = new HMACSHA1(secretKeyBytes);
            byte[] hash = hmac.ComputeHash(counter);

            int offset = hash[hash.Length - 1] & 0x0F;
            int binaryCode = ((hash[offset] & 0x7F) << 24) |
                             ((hash[offset + 1] & 0xFF) << 16) |
                             ((hash[offset + 2] & 0xFF) << 8) |
                             (hash[offset + 3] & 0xFF);

            int otp = binaryCode % (int)Math.Pow(10, TotpSize);
            return otp.ToString().PadLeft(TotpSize, '0');
        }

        public static bool VerifyOTP(string secretKey, string userOTP)
        {
            string generatedOTP = GenerateOTP(secretKey);
            return userOTP.Equals(generatedOTP);
        }

        private static long GetCurrentTimeStep()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long secondsSinceEpoch = (long)t.TotalSeconds;
            return secondsSinceEpoch / IntervalDuration;
        }
    }
}
