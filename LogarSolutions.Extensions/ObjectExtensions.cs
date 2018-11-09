using System;

namespace LogarSolutions.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///     Throw exception if null
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <param name="name">Optional ArgumentNullException name</param>
        public static void NullCheck(this object obj, string name = "")
        {
            if (obj == null)
            {
                if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();

                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        ///     Is null or default value
        /// </summary>
        /// <typeparam name="T">Type of struct</typeparam>
        /// <param name="value">Value</param>
        /// <returns>Boolean</returns>
        public static bool IsNullOrDefault<T>(this T? value) where T : struct
        {
            return default(T).Equals(value.GetValueOrDefault());
        }
    }
}