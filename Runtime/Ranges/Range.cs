using System;

namespace Zigurous.DataStructures
{
    /// <summary>A range of values.</summary>
    /// <typeparam name="T">The type of values in the range.</typeparam>
    public struct Range<T> : IRange<T> where T: IComparable<T>
    {
        private T _min;
        private T _max;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public T min
        {
            get => _min;
            set => _min = value;
        }

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public T max
        {
            get => _max;
            set => _max = value;
        }

        /// <summary>Creates a new range with the given <paramref name="min"/> and <paramref name="max"/> values.</summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Range(T min = default(T), T max = default(T))
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc />
        /// <param name="vale">The value to check.</param>
        public bool Includes(T value)
        {
            return value.IsBetween(_min, _max, true, true);
        }

        /// <returns>True if the <paramref name="value"/> is in the range.</returns>
        /// <param name="value">The value to check.</param>
        /// <param name="includeMin">Whether to include the minimum value.</param>
        /// <param name="includeMax">Whether to include the maximum value.</param>
        public bool Includes(T value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(_min, _max, includeMin, includeMax);
        }

    }

}
