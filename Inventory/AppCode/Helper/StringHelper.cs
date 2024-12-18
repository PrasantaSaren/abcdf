using System.Text.RegularExpressions;

namespace Inventory.AppCode.Helper
{
    public static class StringHelper
    {
        public static string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static string[] SplitByDelimiter(string input, char delimiter)
        {
            return input.Split(delimiter);
        }

        public static string JoinStrings(IEnumerable<string> strings, string separator)
        {
            return string.Join(separator, strings);
        }

        public static string ReplaceSubstring(string input, string oldValue, string newValue)
        {
            return input.Replace(oldValue, newValue);
        }

        public static string TruncateString(string input, int maxLength)
        {
            if (input.Length <= maxLength)
                return input;

            return input.Substring(0, maxLength);
        }

        public static string[] SplitByLength(string input, int length)
        {
            return Enumerable.Range(0, input.Length / length)
                .Select(i => input.Substring(i * length, length))
                .ToArray();
        }

        public static string ReverseWordsInSentence(string input)
        {
            string[] words = input.Split(' ');
            Array.Reverse(words);
            return string.Join(' ', words);
        }

        public static string RemoveNonAlphaNumeric(string input)
        {
            return new string(input.Where(char.IsLetterOrDigit).ToArray());
        }

        public static string ShuffleString(string input)
        {
            char[] array = input.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                char value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        public static string RotateStringLeft(string input, int positions)
        {
            positions = positions % input.Length;
            return input.Substring(positions) + input.Substring(0, positions);
        }

        public static string RemoveDuplicates(string input)
        {
            return new string(input.Distinct().ToArray());
        }

        public static string CamelCaseToWords(string input)
        {
            return Regex.Replace(input, "(\\B[A-Z])", " $1");
        }


    }
}
