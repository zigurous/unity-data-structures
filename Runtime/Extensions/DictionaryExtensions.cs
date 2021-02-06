using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> Where<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Predicate<KeyValuePair<TKey, TValue>> match)
        {
            Dictionary<TKey, TValue> matches = new Dictionary<TKey, TValue>(dictionary.Count);

            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                if (match(pair)) {
                    matches.Add(pair.Key, pair.Value);
                }
            }

            return matches;
        }

        public static List<TKey> Where<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection keys, Predicate<TKey> match)
        {
            List<TKey> matches = new List<TKey>(keys.Count);

            foreach (TKey key in keys)
            {
                if (match(key)) {
                    matches.Add(key);
                }
            }

            return matches;
        }

        public static List<TValue> Where<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection values, Predicate<TValue> match)
        {
            List<TValue> matches = new List<TValue>(values.Count);

            foreach (TValue value in values)
            {
                if (match(value)) {
                    matches.Add(value);
                }
            }

            return matches;
        }

    }

}
