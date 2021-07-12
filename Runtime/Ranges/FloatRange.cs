using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of float values.
    /// </summary>
    [System.Serializable]
    public struct FloatRange : INumberRange<float>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private float _min;

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private float _max;

        /// <inheritdoc />
        public float min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc />
        public float max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc />
        public float Delta => _max - _min;

        /// <inheritdoc />
        public float Median => (_min + _max) / 2;

        /// <summary>
        /// Shorthand for writing FloatRange(0.0f, 0.0f).
        /// </summary>
        public static FloatRange zero => new FloatRange(0.0f, 0.0f);

        /// <summary>
        /// Shorthand for writing FloatRange(1.0f, 1.0f).
        /// </summary>
        public static FloatRange one => new FloatRange(1.0f, 1.0f);

        /// <summary>
        /// Shorthand for writing FloatRange(0.0f, 1.0f).
        /// </summary>
        public static FloatRange percent => new FloatRange(0.0f, 1.0f);

        /// <summary>
        /// Shorthand for writing FloatRange(0.0f, float.MaxValue).
        /// </summary>
        public static FloatRange positive => new FloatRange(0.0f, float.MaxValue);

        /// <summary>
        /// Shorthand for writing FloatRange(float.MinValue, 0.0f).
        /// </summary>
        public static FloatRange negative => new FloatRange(float.MinValue, 0.0f);

        /// <summary>
        /// Shorthand for writing FloatRange(float.MinValue, float.MaxValue).
        /// </summary>
        public static FloatRange minMax => new FloatRange(float.MinValue, float.MaxValue);

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public FloatRange(float min = 0.0f, float max = 1.0f)
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc />
        public float Random()
        {
            return UnityEngine.Random.Range(_min, _max);
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(float value)
        {
            return value >= _min && value <= _max;
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(float value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(_min, _max, includeMin, includeMax);
        }

        /// <inheritdoc />
        /// <param name="value">The value to clamp.</param>
        public float Clamp(float value)
        {
            return Mathf.Clamp(value, _min, _max);
        }

    }

}
