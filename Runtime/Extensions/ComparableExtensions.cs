using System;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Extension methods for IComparable.
    /// </summary>
    public static class ComparableExtensions
    {
        /// <summary>
        /// Checks if the value is between <paramref name="min"/> and
        /// <paramref name="max"/>.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="includeMin">The minimum value is inclusive if true, exclusive if false.</param>
        /// <param name="includeMax">The maximum value is inclusive if true, exclusive if false.</param>
        /// <typeparam name="T">The type of value to check.</typeparam>
        public static bool IsBetween<T>(this T value, T min, T max, bool includeMin, bool includeMax) where T: IComparable<T>
        {
            int minCompare = value.CompareTo(min);
            int maxCompare = value.CompareTo(max);

            if (minCompare < 0 || maxCompare > 0) return false;
            if (!includeMin && minCompare == 0) return false;
            if (!includeMax && maxCompare == 0) return false;

            return true;
        }

    }

}
