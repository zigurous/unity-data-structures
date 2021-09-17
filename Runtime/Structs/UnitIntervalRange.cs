using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of values between zero and one.
    /// </summary>
    [System.Serializable]
    public struct UnitIntervalRange : INumberRange<float>
    {
        /// <summary>
        /// Shorthand for writing <c>UnitIntervalRange(0f, 0f)</c>.
        /// </summary>
        public static UnitIntervalRange zero => new UnitIntervalRange(0f, 0f);

        /// <summary>
        /// Shorthand for writing <c>UnitIntervalRange(1f, 1f)</c>.
        /// </summary>
        public static UnitIntervalRange one => new UnitIntervalRange(1f, 1f);

        /// <summary>
        /// Shorthand for writing <c>UnitIntervalRange(0f, 1f)</c>.
        /// </summary>
        public static UnitIntervalRange minMax => new UnitIntervalRange(0f, 1f);

        [SerializeField]
        [Range(0f, 1f)]
        [Tooltip("The lower bound of the range.")]
        private float _min;

        [SerializeField]
        [Range(0f, 1f)]
        [Tooltip("The upper bound of the range.")]
        private float _max;

        /// <inheritdoc/>
        public float min
        {
            get => _min;
            set => _min = Mathf.Clamp01(value);
        }

        /// <inheritdoc/>
        public float max
        {
            get => _max;
            set => _max = Mathf.Clamp01(value);
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
        public UnitIntervalRange(float min = 0f, float max = 1f)
        {
            _min = Mathf.Clamp01(min);
            _max = Mathf.Clamp01(max);
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
