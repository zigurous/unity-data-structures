using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Exposes extension methods for dictionaries.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <returns>A new dictionary containing only the key-value pairs that match the <paramref name="predicate"/>.</returns>
        /// <param name="dictionary">The dictionary to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        public static Dictionary<TKey, TValue> Where<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Predicate<KeyValuePair<TKey, TValue>> predicate)
        {
            Dictionary<TKey, TValue> matches = new Dictionary<TKey, TValue>(dictionary.Count);

            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                if (predicate(pair)) {
                    matches.Add(pair.Key, pair.Value);
                }
            }

            return matches;
        }

        /// <returns>A new list containing only the keys that match the <paramref name="predicate"/>.</returns>
        /// <param name="keys">The keys to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        public static List<TKey> Where<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection keys, Predicate<TKey> predicate)
        {
            List<TKey> matches = new List<TKey>(keys.Count);

            foreach (TKey key in keys)
            {
                if (predicate(key)) {
                    matches.Add(key);
                }
            }

            return matches;
        }

        /// <returns>A new list containing only the values that match the <paramref name="predicate"/>.</returns>
        /// <param name="values">The values to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        public static List<TValue> Where<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection values, Predicate<TValue> predicate)
        {
            List<TValue> matches = new List<TValue>(values.Count);

            foreach (TValue value in values)
            {
                if (predicate(value)) {
                    matches.Add(value);
                }
            }

            return matches;
        }

    }

}
