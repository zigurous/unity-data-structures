using System;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of values of the given type.
    /// </summary>
    /// <typeparam name="T">The type of values in the range.</typeparam>
    [System.Serializable]
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

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Range(T min = default(T), T max = default(T))
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(T value)
        {
            return value.IsBetween(_min, _max, true, true);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(T value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(_min, _max, includeMin, includeMax);
        }

    }

}
