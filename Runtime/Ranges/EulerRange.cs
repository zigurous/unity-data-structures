using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct EulerRange : IRange<float>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        [Tooltip("The minimum value of the range.")]
        [Range(-360.0f, 360.0f)]
        public float min;

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        [Tooltip("The maximum value of the range.")]
        [Range(-360.0f, 360.0f)]
        public float max;

        /// <summary>
        /// The difference between the min and max value.
        /// </summary>
        public float Delta => this.max - this.min;

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
        public static EulerRange halfCycle => new EulerRange(-180.0f, 180.0f);

        /// <summary>
        /// Shorthand for writing EulerRange(-360.0f, 360.0f).
        /// </summary>
        public static EulerRange fullCycle => new EulerRange(-360.0f, 360.0f);

        /// <summary>
        /// Creates a new EulerRange with given min and max values.
        /// </summary>
        public EulerRange(float min = -360.0f, float max = 360.0f)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns a random value within the euler range.
        /// </summary>
        public float Random() => UnityEngine.Random.Range(this.min, this.max);

        /// <summary>
        /// Clamps a value within the euler range.
        /// </summary>
        public float Clamp(float value) => Mathf.Clamp(value, this.min, this.max);

        /// <summary>
        /// Determines if a value is within the euler range
        /// (inclusive, inclusive).
        /// </summary>
        public bool Includes(float value) => value >= this.min && value <= this.max;

        /// <summary>
        /// Determines if a value is within the euler range
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
