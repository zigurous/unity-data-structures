using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct FloatRange : IRange<float>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        [Tooltip("The minimum value of the range.")]
        public float min;

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        [Tooltip("The maximum value of the range.")]
        public float max;

        /// <summary>
        /// The difference between the min and max value.
        /// </summary>
        public float Delta => this.max - this.min;

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
        /// Creates a new FloatRange with given min and max values.
        /// </summary>
        public FloatRange(float min = 0.0f, float max = 1.0f)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns a random value within the range.
        /// </summary>
        public float Random() => UnityEngine.Random.Range(this.min, this.max);

        /// <summary>
        /// Clamps a value within the range.
        /// </summary>
        public float Clamp(float value) => Mathf.Clamp(value, this.min, this.max);

        /// <summary>
        /// Determines if a value is within the range
        /// (inclusive, inclusive).
        /// </summary>
        public bool Includes(float value) => value >= this.min && value <= this.max;

        /// <summary>
        /// Determines if a value is within the range
        /// using a custom inclusive/exclusive combination.
        /// </summary>
        public bool Includes(float value, bool includeMin, bool includeMax)
        {
            if (value < this.min || value > this.max) {
                return false;
            }

            if (!includeMin && value == this.min) {
                return false;
            }

            if (!includeMax && value == this.max) {
                return false;
            }

            return true;
        }

    }

}
