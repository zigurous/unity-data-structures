using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Exposes extension methods for hash sets.
    /// </summary>
    public static class HashSetExtensions
    {
        /// <returns>The first element in the hash set that satisfies the <paramref name="predicate"/>.</returns>
        /// <param name="set">The hash set to get the element from.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the elements in the hash set.</typeparam>
        public static T First<T>(this HashSet<T> set, Predicate<T> predicate)
        {
            foreach (T element in set)
            {
                if (predicate(element) == true) {
                    return element;
                }
            }

            return default(T);
        }

        /// <summary>Invokes an <paramref name="action"/> on each element in the hash set.</summary>
        /// <param name="set">The hash set to iterate over.</param>
        /// <param name="action">The action to invoke on each element.</param>
        /// <typeparam name="T">The type of the elements in the hash set.</typeparam>
        public static void ForEach<T>(this HashSet<T> set, Action<T> action)
        {
            foreach (T item in set) {
                action(item);
            }
        }

        /// <returns>True if any element in the hash set satisfies the <paramref name="predicate"/>.</returns>
        /// <param name="set">The hash set to check.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the elements in the hash set.</typeparam>
        public static bool IsAny<T>(this HashSet<T> set, Predicate<T> predicate)
        {
            foreach (T item in set)
            {
                if (predicate(item)) {
                    return true;
                }
            }

            return false;
        }

        /// <returns>True if each element in the hash set satisfies the <paramref name="predicate"/>.</returns>
        /// <param name="set">The hash set to check.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the elements in the hash set.</typeparam>
        public static bool IsEach<T>(this HashSet<T> set, Predicate<T> predicate)
        {
            foreach (T item in set)
            {
                if (!predicate(item)) {
                    return false;
                }
            }

            return true;
        }

    }

}
