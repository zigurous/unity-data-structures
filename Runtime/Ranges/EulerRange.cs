using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of euler values.
    /// </summary>
    [System.Serializable]
    public struct EulerRange : INumberRange<float>
    {
        [Tooltip("The lower bound of the range.")]
        [Range(-360.0f, 360.0f)]
        [SerializeField]
        private float _min;

        [Tooltip("The upper bound of the range.")]
        [Range(-360.0f, 360.0f)]
        [SerializeField]
        private float _max;

        /// <inheritdoc />
        public float min
        {
            get => _min;
            set => _min = EulerRange.Wrap(value, -360.0f, 360.0f);
        }

        /// <inheritdoc />
        public float max
        {
            get => _max;
            set => _max = EulerRange.Wrap(value, -360.0f, 360.0f);
        }

        /// <inheritdoc />
        public float Delta => _max - _min;

        /// <inheritdoc />
        public float Median => (_min + _max) / 2;

        /// <summary>
        /// Shorthand for writing EulerRange(0.0f, 0.0f).
        /// </summary>
        public static EulerRange zero => new EulerRange(0.0f, 0.0f);

        /// <summary>
        /// Shorthand for writing EulerRange(0.0f, 180.0f).
        /// </summary>
        public static EulerRange pi => new EulerRange(0.0f, 180.0f);

        /// <summary>
        /// Shorthand for writing EulerRange(0.0f, 360.0f).
        /// </summary>
        public static EulerRange pi2 => new EulerRange(0.0f, 360.0f);

        /// <summary>
        /// Shorthand for writing EulerRange(-180.0f, 180.0f).
        /// </summary>
        public static EulerRange halfRange => new EulerRange(-180.0f, 180.0f);

        /// <summary>
        /// Shorthand for writing EulerRange(-360.0f, 360.0f).
        /// </summary>
        public static EulerRange fullRange => new EulerRange(-360.0f, 360.0f);

        /// <summary>Creates a new euler range with the specified values.</summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public EulerRange(float min = -360.0f, float max = 360.0f)
        {
            _min = EulerRange.Wrap(min, -360.0f, 360.0f);
            _max = EulerRange.Wrap(max, -360.0f, 360.0f);
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

        /// <returns>The <paramref name="value"/> wrapped in the range.</returns>
        /// <param name="value">The value to wrap.</param>
        public float Wrap(float value)
        {
            return EulerRange.Wrap(value, _min, _max);
        }

        private static float Wrap(float value, float min, float max)
        {
            if (value < min) {
                return max - (min - value) % (max - min);
            } else if (value > max) {
                return min + (value - min) % (max - min);
            } else {
                return value;
            }
        }

    }

}
