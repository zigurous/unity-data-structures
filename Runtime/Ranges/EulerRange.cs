using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of euler values wrapped between -360 and +360.
    /// </summary>
    [System.Serializable]
    public struct EulerRange : INumberRange<float>
    {
        /// <summary>
        /// Shorthand for writing <c>EulerRange(0f, 0f)</c>.
        /// </summary>
        public static EulerRange zero => new EulerRange(0f, 0f);

        /// <summary>
        /// Shorthand for writing <c>EulerRange(0f, 180f)</c>.
        /// </summary>
        public static EulerRange pi => new EulerRange(0f, 180f);

        /// <summary>
        /// Shorthand for writing <c>EulerRange(0f, 360f)</c>.
        /// </summary>
        public static EulerRange pi2 => new EulerRange(0f, 360f);

        /// <summary>
        /// Shorthand for writing <c>EulerRange(-180f, 180f)</c>.
        /// </summary>
        public static EulerRange halfRange => new EulerRange(-180f, 180f);

        /// <summary>
        /// Shorthand for writing <c>EulerRange(-360f, 360f)</c>.
        /// </summary>
        public static EulerRange fullRange => new EulerRange(-360f, 360f);

        [Tooltip("The lower bound of the range.")]
        [Range(-360f, 360f)]
        [SerializeField]
        private float _min;

        [Tooltip("The upper bound of the range.")]
        [Range(-360f, 360f)]
        [SerializeField]
        private float _max;

        /// <inheritdoc />
        public float min
        {
            get => _min;
            set => _min = EulerRange.Wrap(value, -360f, 360f);
        }

        /// <inheritdoc />
        public float max
        {
            get => _max;
            set => _max = EulerRange.Wrap(value, -360f, 360f);
        }

        /// <inheritdoc />
        public float delta => _max - _min;

        /// <inheritdoc />
        public float median => (_min + _max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public EulerRange(float min = -360f, float max = 360f)
        {
            _min = EulerRange.Wrap(min, -360f, 360f);
            _max = EulerRange.Wrap(max, -360f, 360f);
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

        /// <summary>
        /// Wraps a value within the range.
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <returns>The wrapped value.</returns>
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
