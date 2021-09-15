using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of int values.
    /// </summary>
    [System.Serializable]
    public struct IntRange : INumberRange<int>
    {
        /// <summary>
        /// Shorthand for writing <c>IntRange(0, 0)</c>.
        /// </summary>
        public static IntRange zero => new IntRange(0, 0);

        /// <summary>
        /// Shorthand for writing <c>IntRange(1, 1)</c>.
        /// </summary>
        public static IntRange one => new IntRange(1, 1);

        /// <summary>
        /// Shorthand for writing <c>IntRange(0, int.MaxValue)</c>.
        /// </summary>
        public static IntRange positive => new IntRange(0, int.MaxValue);

        /// <summary>
        /// Shorthand for writing <c>IntRange(int.MinValue, 0)</c>.
        /// </summary>
        public static IntRange negative => new IntRange(int.MinValue, 0);

        /// <summary>
        /// Shorthand for writing <c>IntRange(int.MinValue, int.MaxValue)</c>.
        /// </summary>
        public static IntRange minMax => new IntRange(int.MinValue, int.MaxValue);

        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private int _min;

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private int _max;

        /// <inheritdoc/>
        public int min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc/>
        public int max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc/>
        public int delta => _max - _min;

        /// <inheritdoc/>
        public int median => (_min + _max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public IntRange(int min, int max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, exclusive).
        /// </summary>
        /// <returns>A random value in the range [inclusive, exclusive).</returns>
        public int Random()
        {
            return UnityEngine.Random.Range(_min, _max);
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, inclusive].
        /// </summary>
        /// <returns>A random value in the range [inclusive, inclusive].</returns>
        public int RandomInclusive()
        {
            return UnityEngine.Random.Range(_min, _max + 1);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(int value)
        {
            return value >= _min && value < _max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(int value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(_min, _max, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public int Clamp(int value)
        {
            return Mathf.Clamp(value, _min, _max);
        }

    }

}
