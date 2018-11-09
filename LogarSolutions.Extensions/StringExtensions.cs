using System;
using System.Collections.Generic;
using System.Linq;

namespace LogarSolutions.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsAllUpper(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return input.All(t => !char.IsLetter(t) || char.IsUpper(t));
        }

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
        /// <returns>String in upper case</returns>
        public static string SafeToUpper(this string input)
        {
            return (input ?? string.Empty).ToUpper();
        }

        /// <summary>
        ///     Safe to lower case
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>String in lower case</returns>
        public static string SafeToLower(this string input)
        {
            return (input ?? string.Empty).ToLower();
        }

        /// <summary>
        ///     Safe string of an object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSafeString(this object obj)
        {
            try
            {
                if (obj == null)
                {
                    return string.Empty;
                }

                return obj.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///     Trim string if string is not empty otherwise return empty string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SafeTrim(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            return str.Trim();
        }

        /// <summary>
        ///     String contains extension method with ignore case possibility
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="toCheck">Comparing string</param>
        /// <param name="comp">StringComparison</param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        ///     Get safe substring of a string or empty string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string SafeSubstring(this string str, int startIndex)
        {
            if (string.IsNullOrEmpty(str))
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
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SafeSubstring(this string str, int startIndex, int length)
        {
            str = str.SafeSubstring(startIndex);
            if (str.Length < length)
            {
                return str;
            }

            return str.Substring(0, length);
        }

        /// <summary>
        ///     Concatenate values with comma separator
        /// </summary>
        /// <param name="optionIds"></param>
        /// <returns></returns>
        public static string ConcatValues(this IList<int> optionIds)
        {
            if (optionIds.IsEmpty())
                return string.Empty;

            return string.Join(",", optionIds);
        }


        /// <summary>
        ///     Safe parse string to long
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ToSafeLong(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            long result;
            if (long.TryParse(str, out result))
            {
                return result;
            }

            return 0;
        }

        public static string AfterDotSubstring(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            int idx = str.IndexOf('.');
            if (idx >= 0)
            {
                return str.SafeSubstring(idx + 1);
            }

            return str;
        }
    }
}
