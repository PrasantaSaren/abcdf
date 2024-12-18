namespace Inventory.AppCode.Helper
{
    public static class DateTimeHelper
    {
        public static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        public static string GetCurrentDateTimeAsString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime GetCurrentDateTimeInTimeZone(string timeZoneId)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        }

        public static DateTime GetCurrentDateTimeUTC()
        {
            return DateTime.UtcNow;
        }

        // 4. Get the number of days in a specific month of a year
        public static int GetDaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        // 5. Add days to a specific date
        public static DateTime AddDays(DateTime date, int days)
        {
            return date.AddDays(days);
        }

        // 6. Subtract days from a specific date
        public static DateTime SubtractDays(DateTime date, int days)
        {
            return date.AddDays(-days);
        }

        // 7. Get the day of the week for a specific date
        public static DayOfWeek GetDayOfWeek(DateTime date)
        {
            return date.DayOfWeek;
        }

        // 8. Get the current day of the year
        public static int GetCurrentDayOfYear()
        {
            return DateTime.UtcNow.DayOfYear;
        }

        // 9. Get the current month
        public static int GetCurrentMonth()
        {
            return DateTime.UtcNow.Month;
        }

        // 10. Get the current year
        public static int GetCurrentYear()
        {
            return DateTime.UtcNow.Year;
        }

        // 11. Get the time difference between two dates
        public static TimeSpan GetTimeDifference(DateTime start, DateTime end)
        {
            return end - start;
        }

        // 12. Convert a string to a DateTime object
        public static DateTime ParseStringToDateTime(string dateString)
        {
            return DateTime.Parse(dateString);
        }

        // 13. Convert a DateTime object to a string
        public static string ParseDateTimeToString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // 14. Get the current timestamp
        public static long GetCurrentTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        // 15. Round a DateTime object to the nearest second
        public static DateTime RoundToNearestSecond(DateTime date)
        {
            return new DateTime(date.Ticks - (date.Ticks % TimeSpan.TicksPerSecond), date.Kind);
        }

        // 16. Check if two DateTime objects represent the same date
        public static bool AreDatesEqual(DateTime date1, DateTime date2)
        {
            return date1.Date == date2.Date;
        }

        // 17. Get the first day of the month for a specific date
        public static DateTime GetFirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        // 18. Get the last day of the month for a specific date
        public static DateTime GetLastDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        // 19. Get the age based on the birthdate
        public static int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.UtcNow.Year - birthDate.Year;
            if (DateTime.UtcNow < birthDate.AddYears(age)) age--;
            return age;
        }

        // 20. Check if a DateTime falls within a specific range
        public static bool IsDateInRange(DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck <= endDate;
        }
    }
}
