namespace Iirc.Utils.Text
{
    using System;
    using System.Linq;

    public static class StringExtensions
    {
        public static string SanitizeWhitespace(this string str)
        {
            var lines = str
                .SplitNewlines()
                .Select(line => line.Trim())
                .Where(line => line.Length > 0)
                .Select(line => string.Join(' ', line.Split(' ', StringSplitOptions.RemoveEmptyEntries)));

            return string.Join("\n", lines);
        }

        public static string[] SplitNewlines(this string str)
        {
            return str.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
        }
    }
}