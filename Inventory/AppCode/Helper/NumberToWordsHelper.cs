namespace Inventory.AppCode.Helper
{
    public static class NumberToWordsConverter
    {
        private static readonly string[] Units = {
        "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
        "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
    };

        private static readonly string[] Tens = {
        "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
    };
        //123456789 in words: One Hundred Twenty Three Million Four Hundred Fifty Six Thousand Seven Hundred Eighty Nine

        public static string ConvertToWords(int number)
        {
            if (number < 0)
                return "Minus " + ConvertToWords(-number);

            if (number < 20)
                return Units[number];

            if (number < 100)
                return Tens[number / 10] + ((number % 10 > 0) ? " " + Units[number % 10] : "");

            if (number < 1000)
                return Units[number / 100] + " Hundred" + ((number % 100 > 0) ? " and " + ConvertToWords(number % 100) : "");

            if (number < 1000000)
                return ConvertToWords(number / 1000) + " Thousand" + ((number % 1000 > 0) ? " " + ConvertToWords(number % 1000) : "");

            if (number < 1000000000)
                return ConvertToWords(number / 1000000) + " Million" + ((number % 1000000 > 0) ? " " + ConvertToWords(number % 1000000) : "");

            return ConvertToWords(number / 1000000000) + " Billion" + ((number % 1000000000 > 0) ? " " + ConvertToWords(number % 1000000000) : "");
        }
    }

}
