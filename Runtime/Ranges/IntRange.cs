using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct IntRange : INumberRange<int>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private int _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public int min
        {
            get => _min;
            set => _min = value;
        }

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private int _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public int max
        {
            get => _max;
            set => _max = value;
        }

        /// <summary>
        /// The difference between the range min and max.
        /// </summary>
        public int Delta => _max - _min;

        /// <summary>
        /// The number in the middle of the range min and max.
        /// </summary>
        public int Median => (_min + _max) / 2;

        /// <summary>
        /// Shorthand for writing IntRange(0, 0).
        /// </summary>
        public static IntRange zero => new IntRange(0, 0);

        /// <summary>
        /// Shorthand for writing IntRange(1, 1).
        /// </summary>
        public static IntRange one => new IntRange(1, 1);

        /// <summary>
        /// Shorthand for writing IntRange(0, int.MaxValue).
        /// </summary>
        public static IntRange positive => new IntRange(0, int.MaxValue);

        /// <summary>
        /// Shorthand for writing IntRange(int.MinValue, 0).
        /// </summary>
        public static IntRange negative => new IntRange(int.MinValue, 0);

        /// <summary>
        /// Shorthand for writing IntRange(int.MinValue, int.MaxValue).
        /// </summary>
        public static IntRange minMax => new IntRange(int.MinValue, int.MaxValue);

        /// <summary>
        /// Creates a new IntRange with given min and max values.
        /// </summary>
        public IntRange(int min, int max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Determines if the given value is between the range
        /// [inclusive, exclusive).
        /// </summary>
        public bool Includes(int value) => value >= _min && value < _max;

        /// <summary>
        /// Determines if the given value is between the range
        /// using a custom inclusive/exclusive combination.
        /// </summary>
        public bool Includes(int value, bool includeMin, bool includeMax) => value.IsBetween(_min, _max, includeMin, includeMax);

        /// <summary>
        /// Returns a random value between the range
        /// [inclusive, exclusive).
        /// </summary>
        public int Random() => UnityEngine.Random.Range(_min, _max);

        /// <summary>
        /// Clamps the given value between the range.
        /// </summary>
        public int Clamp(int value) => Mathf.Clamp(value, _min, _max);

    }

}
