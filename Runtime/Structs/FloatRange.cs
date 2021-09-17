using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of float values.
    /// </summary>
    [System.Serializable]
    public struct FloatRange : INumberRange<float>
    {
        /// <summary>
        /// Shorthand for writing <c>FloatRange(0f, 0f)</c>.
        /// </summary>
        public static FloatRange zero => new FloatRange(0f, 0f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(1f, 1f)</c>.
        /// </summary>
        public static FloatRange one => new FloatRange(1f, 1f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(0f, 1f)</c>.
        /// </summary>
        public static FloatRange percent => new FloatRange(0f, 1f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(0f, float.MaxValue)</c>.
        /// </summary>
        public static FloatRange positive => new FloatRange(0f, float.MaxValue);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(float.MinValue, 0f)</c>.
        /// </summary>
        public static FloatRange negative => new FloatRange(float.MinValue, 0f);

        /// <summary>
        /// Shorthand for writing <c>FloatRange(float.MinValue, float.MaxValue)</c>.
        /// </summary>
        public static FloatRange minMax => new FloatRange(float.MinValue, float.MaxValue);

        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private float _min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private float _max;

        /// <inheritdoc/>
        public float min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc/>
        public float max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc/>
        public float delta => _max - _min;

        /// <inheritdoc/>
        public float median => (_min + _max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public FloatRange(float min = 0f, float max = 1f)
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc/>
        public float Random()
        {
            return UnityEngine.Random.Range(_min, _max);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(float value)
        {
            return value >= _min && value <= _max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(float value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(_min, _max, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public float Clamp(float value)
        {
            return Mathf.Clamp(value, _min, _max);
        }

    }

}
