using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of values clamped between a lower and upper bound.
    /// </summary>
    [System.Serializable]
    public struct ClampedRange : INumberRange<float>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private float _min;

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private float _max;

        /// <inheritdoc/>
        public float min
        {
            get => _min;
            set => _min = this.clamp.Clamp(value);
        }

        /// <inheritdoc/>
        public float max
        {
            get => _max;
            set => _max = this.clamp.Clamp(value);
        }

        /// <summary>
        /// The clamping values of the range.
        /// </summary>
        [Tooltip("The clamping values of the range.")]
        public FloatRange clamp;

        /// <inheritdoc/>
        public float delta => _max - _min;

        /// <inheritdoc/>
        public float median => (_min + _max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        /// <param name="clampLower">The lower clamping bound of the range.</param>
        /// <param name="clampUpper">The upper clamping bound of the range.</param>
        public ClampedRange(float min = 0f, float max = 1f, float clampLower = 0f, float clampUpper = 1f)
        {
            FloatRange clamp = new FloatRange(clampLower, clampUpper);
            this.clamp = clamp;

            _min = clamp.Clamp(min);
            _max = clamp.Clamp(max);
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
