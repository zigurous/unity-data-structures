using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of values clamped between a lower and upper bound.
    /// </summary>
    [System.Serializable]
    public struct ClampedRange : INumberRange<float>
    {
        /// <inheritdoc/>
        public float min
        {
            get => this.range.min;
            set => this.range.min = this.clamp.Clamp(value);
        }

        /// <inheritdoc/>
        public float max
        {
            get => this.range.max;
            set => this.range.max = this.clamp.Clamp(value);
        }

        [SerializeField]
        [Tooltip("The min and max values of the range.")]
        private FloatRange range;

        /// <summary>
        /// The clamping values of the range.
        /// </summary>
        [Tooltip("The clamping values of the range.")]
        public FloatRange clamp;

        /// <inheritdoc/>
        public float delta => this.max - this.min;

        /// <inheritdoc/>
        public float median => (this.min + this.max) / 2f;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        /// <param name="clampLower">The lower clamping bound of the range.</param>
        /// <param name="clampUpper">The upper clamping bound of the range.</param>
        public ClampedRange(float min = 0f, float max = 1f, float clampLower = 0f, float clampUpper = 1f)
        {
            this.clamp = new FloatRange(clampLower, clampUpper);
            this.range = new FloatRange(this.clamp.Clamp(min), this.clamp.Clamp(max));
        }

        /// <inheritdoc/>
        public float Random()
        {
            return UnityEngine.Random.Range(this.min, this.max);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(float value)
        {
            return value >= this.min && value <= this.max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(float value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(this.min, this.max, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public float Clamp(float value)
        {
            return Mathf.Clamp(value, this.min, this.max);
        }

    }

}
