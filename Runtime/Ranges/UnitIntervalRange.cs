using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of values between zero and one.
    /// </summary>
    [System.Serializable]
    public struct UnitIntervalRange : INumberRange<float>
    {
        [Tooltip("The lower bound of the range.")]
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float _min;

        [Tooltip("The upper bound of the range.")]
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float _max;

        /// <inheritdoc />
        public float min
        {
            get => _min;
            set => _min = Mathf.Clamp01(value);
        }

        /// <inheritdoc />
        public float max
        {
            get => _max;
            set => _max = Mathf.Clamp01(value);
        }

        /// <inheritdoc />
        public float Delta => _max - _min;

        /// <inheritdoc />
        public float Median => (_min + _max) / 2;

        /// <summary>
        /// Shorthand for writing UnitIntervalRange(0.0f, 0.0f).
        /// </summary>
        public static UnitIntervalRange zero => new UnitIntervalRange(0.0f, 0.0f);

        /// <summary>
        /// Shorthand for writing UnitIntervalRange(1.0f, 1.0f).
        /// </summary>
        public static UnitIntervalRange one => new UnitIntervalRange(1.0f, 1.0f);

        /// <summary>
        /// Shorthand for writing UnitIntervalRange(0.0f, 1.0f).
        /// </summary>
        public static UnitIntervalRange minMax => new UnitIntervalRange(0.0f, 1.0f);

        /// <summary>Creates a new unit interval range with the specified values.</summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public UnitIntervalRange(float min = 0.0f, float max = 1.0f)
        {
            _min = Mathf.Clamp01(min);
            _max = Mathf.Clamp01(max);
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
