using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    public static class HashSetExtensions
    {
        public static T First<T>(this HashSet<T> set, Predicate<T> where)
        {
            foreach (T element in set)
            {
                if (where(element) == true) {
                    return element;
                }
            }

            return default(T);
        }

        public static void ForEach<T>(this HashSet<T> set, Action<T> action)
        {
            foreach (T item in set) {
                action(item);
            }
        }

        public static bool IsFalseForEach<T>(this HashSet<T> set, Predicate<T> predicate)
        {
            foreach (T item in set)
            {
                if (predicate(item)) {
                    return false;
                }
            }

            return true;
        }

        public static bool IsTrueForEach<T>(this HashSet<T> set, Predicate<T> predicate)
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
