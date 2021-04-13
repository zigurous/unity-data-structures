using System;

namespace Zigurous.DataStructures
{
    public struct Range<T> : IRange<T> where T: IComparable<T>
    {
        private T _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public T min
        {
            get => _min;
            set => _min = value;
        }

        private T _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public T max
        {
            get => _max;
            set => _max = value;
        }

        /// <summary>
        /// Creates a new Range with given min and max values.
        /// </summary>
        public Range(T min = default(T), T max = default(T))
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Determines if the given value is between the range [inclusive,
        /// inclusive].
        /// </summary>
        public bool Includes(T value) => value.IsBetween(_min, _max, true, true);

        /// <summary>
        /// Determines if the given value is between the range using a custom
        /// inclusive/exclusive combination.
        /// </summary>
        public bool Includes(T value, bool includeMin, bool includeMax) => value.IsBetween(_min, _max, includeMin, includeMax);

    }

}
