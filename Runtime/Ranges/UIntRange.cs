using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct UIntRange : IRange<uint>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        [Tooltip("The minimum value of the range.")]
        public uint min;

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        [Tooltip("The maximum value of the range.")]
        public uint max;

        /// <summary>
        /// The difference between the min and max value.
        /// </summary>
        public uint Delta => this.max - this.min;

        /// <summary>
        /// Shorthand for writing UIntRange(0, 0).
        /// </summary>
        public static UIntRange zero => new UIntRange(0, 0);

        /// <summary>
        /// Shorthand for writing UIntRange(1, 1).
        /// </summary>
        public static UIntRange one => new UIntRange(1, 1);

        /// <summary>
        /// Shorthand for writing UIntRange(uint.MinValue, uint.MaxValue).
        /// </summary>
        public static UIntRange minMax => new UIntRange(uint.MinValue, uint.MaxValue);

        /// <summary>
        /// Creates a new UIntRange with given min and max values.
        /// </summary>
        public UIntRange(uint min, uint max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns a random value within the range.
        /// </summary>
        public uint Random() => (uint)UnityEngine.Random.Range((int)this.min, (int)this.max + 1);

        /// <summary>
        /// Clamps a value within the range.
        /// </summary>
        public uint Clamp(uint value) => value < this.min ? this.min : (value > this.max ? this.max : value);

        /// <summary>
        /// Determines if a value is within the range (inlcusive, exclusive).
        /// </summary>
        public bool Includes(uint value) => value >= this.min && value < this.max;

        /// <summary>
        /// Determines if a value is within the range
        /// using a custom inclusive/exclusive combination.
        /// </summary>
        public bool Includes(uint value, bool includeMin, bool includeMax)
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
