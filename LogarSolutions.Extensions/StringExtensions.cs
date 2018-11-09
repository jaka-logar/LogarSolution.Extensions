using System;
using System.Collections.Generic;
using System.Linq;

namespace LogarSolutions.Extensions
{
    /// <summary>
    ///     String extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Check if string is null or empty
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>True of string is null or empty</returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        /// <summary>
        ///     Check if string is null or whitespace
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>True of string is null or whitespace</returns>
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        ///     Check if given string has all upper characters
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>True if string has all upper characters</returns>
        public static bool IsAllUpper(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return input.All(t => !char.IsLetter(t) || char.IsUpper(t));
        }

        /// <summary>
        ///     Change input string that first character is capitalize
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Capitalize input string; Null if input is null</returns>
        public static string FirstLetterToUpper(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        /// <summary>
        ///     Safe to upper case
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>String in upper case; Empty string if input is null</returns>
        public static string SafeToUpper(this string input)
        {
            return (input ?? string.Empty).ToUpper();
        }

        /// <summary>
        ///     Safe to lower case
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>String in lower case; Empty string if input is null</returns>
        public static string SafeToLower(this string input)
        {
            return (input ?? string.Empty).ToLower();
        }

        /// <summary>
        ///     Safe string of an object
        /// </summary>
        /// <param name="obj">Input object</param>
        /// <returns>ToString representation of an object; Empty string if object is null or in case of exception</returns>
        public static string ToSafeString(this object obj)
        {
            try
            {
                return obj == null ? string.Empty : obj.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///     Trim string if string is not empty otherwise return empty string
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Trimmed input string; Empty string if input is null</returns>
        public static string SafeTrim(this string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str.Trim();
        }

        /// <summary>
        ///     String contains extension method with ignore case possibility
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="toCheck">Comparing string</param>
        /// <param name="comp">StringComparison</param>
        /// <returns>Bool if source contains toCheck string</returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        ///     Get safe substring of a string or empty string
        /// </summary>
        /// <param name="str">Input string</param>
        /// <param name="startIndex">Start index of substring</param>
        /// <returns>Substring from starting index on; Empty string if input is null or start index is greater than input string</returns>
        public static string SafeSubstring(this string str, int startIndex)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            if (startIndex < 0)
            {
                return string.Empty;
            }

            if (str.Length < startIndex)
            {
                return string.Empty;
            }

            return str.Substring(startIndex);
        }

        /// <summary>
        ///     Get safe substring of a string or empty string
        /// </summary>
        /// <param name="str">Input string</param>
        /// <param name="startIndex">Start index of substring</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>
        ///     Substring from starting index on with selected number of characters if length is greater than zero;
        ///     Empty string if input is null or start index is greater than input string or start index is less than zero;
        ///     Empty string if length is less than zero
        /// </returns>
        public static string SafeSubstring(this string str, int startIndex, int length)
        {
            str = str.SafeSubstring(startIndex);

            if (length < 0)
            {
                return string.Empty;
            }

            if (str.Length < length)
            {
                return str;
            }

            return str.Substring(0, length);
        }

        /// <summary>
        ///     Concatenate values with given separator
        /// </summary>
        /// <param name="values">Input list of values</param>
        /// <param name="separator">Concat input values separator</param>
        /// <returns>Concatenated string of input values</returns>
        public static string ConcatValues<T>(this IList<T> values, string separator = ",")
        {
            if (values.IsEmpty())
            {
                return string.Empty;
            }

            return string.Join(separator, values);
        }


        /// <summary>
        ///     Safe parse string to long
        /// </summary>
        /// <param name="str">Input string</param>
        /// <param name="defaultReturnValue">Default return value if parse fails</param>
        /// <returns>Parsed string value to long; defaultReturnValue if parse fails</returns>
        public static long ToSafeLong(this string str, long defaultReturnValue = default(long))
        {
            if (string.IsNullOrEmpty(str))
            {
                return defaultReturnValue;
            }

            if (long.TryParse(str, out long result))
            {
                return result;
            }

            return defaultReturnValue;
        }

        /// <summary>
        ///     Get substring after first occurrence of input character
        /// </summary>
        /// <param name="str">Input string</param>
        /// <param name="charToFind">Character to check</param>
        /// <returns>Substring after found character; Empty string if input is null or empty; Input string if character not found</returns>
        public static string AfterCharSubstring(this string str, char charToFind = '.')
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            int idx = str.IndexOf(charToFind);
            return idx >= 0 ? str.SafeSubstring(idx + 1) : str;
        }
    }
}