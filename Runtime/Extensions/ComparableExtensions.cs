using System;

namespace Zigurous
{
    public static class ComparableExtensions
    {
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
