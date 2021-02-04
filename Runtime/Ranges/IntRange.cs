using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct IntRange : IRange<int>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        [Tooltip("The minimum value of the range.")]
        public int min;

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        [Tooltip("The maximum value of the range.")]
        public int max;

        /// <summary>
        /// The difference between the min and max value.
        /// </summary>
        public int Delta => this.max - this.min;

        /// <summary>
        /// Shorthand for writing IntRange(0, 0).
        /// </summary>
        public static IntRange zero => new IntRange(0, 0);

        /// <summary>
        /// Shorthand for writing IntRange(1, 1).
        /// </summary>
        public static IntRange one => new IntRange(1, 1);

        /// <summary>
        /// Shorthand for writing IntRange(0, int.MaxValue).
        /// </summary>
        public static IntRange positive => new IntRange(0, int.MaxValue);

        /// <summary>
        /// Shorthand for writing IntRange(int.MinValue, 0).
        /// </summary>
        public static IntRange negative => new IntRange(int.MinValue, 0);

        /// <summary>
        /// Shorthand for writing IntRange(int.MinValue, int.MaxValue).
        /// </summary>
        public static IntRange minMax => new IntRange(int.MinValue, int.MaxValue);

        /// <summary>
        /// Creates a new IntRange with given min and max values.
        /// </summary>
        public IntRange(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns a random value within the range.
        /// </summary>
        public int Random() => UnityEngine.Random.Range(this.min, this.max + 1);

        /// <summary>
        /// Clamps a value within the range.
        /// </summary>
        public int Clamp(int value) => Mathf.Clamp(value, this.min, this.max);

        /// <summary>
        /// Determines if a value is within the range
        /// (inlcusive, exclusive).
        /// </summary>
        public bool Includes(int value) => value >= this.min && value < this.max;

        /// <summary>
        /// Determines if a value is within the range
        /// using a custom inclusive/exclusive combination.
        /// </summary>
        public bool Includes(int value, bool includeMin, bool includeMax)
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
