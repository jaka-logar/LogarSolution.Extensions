using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LogarSolutions.Extensions
{
    /// <summary>
    ///     Enumerable extensions
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Checks if IEnumerable is null or has no elements
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <param name="items">Element enumerable</param>
        /// <returns>True if null or has no elements</returns>
        [ContractAnnotation("items:null => true")]
        public static bool IsEmpty<T>(this IEnumerable<T> items)
        {
            return items == null || !items.Any();
        }

        /// <summary>
        ///     Add item to list if item is not null
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <param name="items">IList of items</param>
        /// <param name="item">Item to check and add</param>
        public static void AddIfNotNull<T>(this IList<T> items, T item)
        {
            if (item != null)
            {
                items?.Add(item);
            }
        }

        /// <summary>
        ///     Distinct by property specified
        /// </summary>
        /// <typeparam name="TSource">Type of source enumerable</typeparam>
        /// <typeparam name="TKey">Type of key selector</typeparam>
        /// <param name="source">Source enumerable</param>
        /// <param name="keySelector">Lambda key selector</param>
        /// <returns>Enumerable with no duplicates filtered by given key</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        ///     Create multiple enumerable batches with max elements
        /// </summary>
        /// <typeparam name="T">Enumerable item type</typeparam>
        /// <param name="items">Input items</param>
        /// <param name="maxItems">Max batch size</param>
        /// <returns>Multiple enumerable</returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int maxItems)
        {
            return items.Select((item, inx) => new {item, inx})
                .GroupBy(x => x.inx / maxItems)
                .Select(g => g.Select(x => x.item));
        }
    }
}