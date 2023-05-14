using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
        private static readonly Regex IGNORED = new Regex("[^a-zA-Z0-9]");
        private static readonly Regex UPPER_START = new Regex("^[A-Z]*");
        private static readonly Regex LOWER_START = new Regex("^[a-z]*");
        // credit: https://stackoverflow.com/a/4489046/6127368
        private static readonly Regex SPLIT_UPPER = new Regex(@"(?<=[A-Z])(?=[A-Z][a-z]) |
(?<=[^A-Z])(?=[A-Z]) |
(?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

        #region ToCamel

        /// <summary>
        /// Converts to camelCase.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string ToCamel(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;


            string[] parts = IGNORED.Split(text);
            if (parts.Length == 1)
            {
                return ToCamelSimple(text);
            }

            string result = string.Join("", parts.Select((m, i) => i == 0 ? ToCamelSimple(m) : ToPascalSimple(m)));
            return result;
        }

        #endregion // ToCamel

        #region ToPascal

        /// <summary>
        /// Converts to PascalCase.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string ToPascal(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;


            string[] parts = IGNORED.Split(text);
            if (parts.Length == 1)
            {
                return ToPascalSimple(text);
            }

            return string.Join("", parts.Select(m => ToPascalSimple(m)));
        }

        #endregion // ToPascal

        #region ToSCREAMING

        /// <summary>
        /// Converts to SCREAMING_CASE.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string ToSCREAMING(this string text, char separator = '_')
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            (StringBuilder Result, char Last) aggregate = text.Trim().Aggregate(
               (Result: new StringBuilder(text.Length), Last: char.MinValue),
               (acc, current) =>
               {
                   char CURRENT = char.ToUpper(current);
                   var (result, last) = acc;
                   bool isCurWS = char.IsWhiteSpace(current);
                   if (isCurWS && result.Length != 0)
                   {
                       if (char.IsLetter(last) || char.IsDigit(last))
                           return (result.Append(separator), separator);
                       else
                           return (result, last);
                   }
                   if (result.Length == 0)
                   {
                       if (isCurWS)
                           return (result, char.MinValue);
                       else
                           return (result.Append(CURRENT), current);
                   }

                   if (current == separator || last == separator)
                   {
                       if (current == last)
                           return (result, current);
                       return (result.Append(CURRENT), current);
                   }
                   if ((char.IsLower(last) || !char.IsLetter(last)) && char.IsUpper(current))
                       return (result.Append(separator).Append(CURRENT), current);
                   return (result.Append(CURRENT), current);
               });


            return aggregate.Result.ToString();
        }

        #endregion // ToSCREAMING

        #region ToDash

        /// <summary>
        /// Converts to dash-separated (ignore anything which is not letter or digit).
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string ToDash(this string text, char separator = '-')
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            (StringBuilder Result, char Last) aggregate = text.Aggregate(
               (Result: new StringBuilder(text.Length), Last: char.MinValue),
               (acc, current) =>
               {
                   char lowerCurrent = char.ToLower(current);
                   var (result, last) = acc;
                   bool ignore = !char.IsDigit(current) && !char.IsLetter(current) || current == '_';
                   if (ignore && result.Length != 0)
                   {
                       return (result, separator);
                   }
                   if (result.Length == 0)
                   {
                       if (ignore)
                           return (result, char.MinValue);
                       else
                           return (result.Append(lowerCurrent), current);
                   }

                   if (current == separator || last == separator)
                   {
                       if (current == last)
                           return (result, current);
                       else if (last == separator)
                           return (result.Append(separator).Append(lowerCurrent), current);
                   }
                   if (char.IsUpper(current) && !char.IsUpper(last))
                       return (result.Append(separator).Append(lowerCurrent), current);
                   return (result.Append(lowerCurrent), current);
               });


            return aggregate.Result.ToString();
        }

        #endregion // ToDash

        #region ToCamelSimple

        private static string ToCamelSimple(string candidate)
        {
            if (string.IsNullOrEmpty(candidate))
                return string.Empty;

            int len = UPPER_START.Match(candidate).Length;
            if (len == 0)
                return candidate;

            var start = candidate[..len].ToLower();
            return $"{start}{candidate[len..]}";
        }

        #endregion // ToCamelSimple

        #region ToPascalSimple

        private static string ToPascalSimple(string candidate)
        {
            if (string.IsNullOrEmpty(candidate))
                return string.Empty;

            string[] parts = SPLIT_UPPER.Split(candidate);
            if (parts.Length > 1)
            {
                var ps = parts.Select(p => ToPascalSimple(p));
                return string.Join("", ps);
            }

            int len = LOWER_START.Match(candidate).Length;
            if (len == 0)
            {
                int lenUp = UPPER_START.Match(candidate).Length;
                if (lenUp <= 1)
                    return candidate;

                var fst = Char.ToUpper(candidate[0]);
                var rst = candidate[1..].ToLower();
                return $"{fst}{rst}";
            }

            var first = Char.ToUpper(candidate[0]);
            var rest = candidate[1..].ToLower();
            //var start = candidate[1..len].ToLower();
            //var rest = candidate[len..].ToLower();
            //return $"{first}{start}{candidate[len..]}";
            return $"{first}{rest}";
        }

        #endregion // ToPascalSimple
    }
}
