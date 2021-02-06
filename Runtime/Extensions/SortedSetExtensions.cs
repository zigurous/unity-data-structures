using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    public static class SortedSetExtensions
    {
        public static T First<T>(this SortedSet<T> set, Predicate<T> where)
        {
            foreach (T element in set)
            {
                if (where(element) == true) {
                    return element;
                }
            }

            return default(T);
        }

        public static void ForEach<T>(this SortedSet<T> set, Action<T> action)
        {
            foreach (T item in set) {
                action(item);
            }
        }

        public static bool IsFalseForEach<T>(this SortedSet<T> set, Predicate<T> predicate)
        {
            foreach (T item in set)
            {
                if (predicate(item)) {
                    return false;
                }
            }

            return true;
        }

        public static bool IsTrueForEach<T>(this SortedSet<T> set, Predicate<T> predicate)
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
