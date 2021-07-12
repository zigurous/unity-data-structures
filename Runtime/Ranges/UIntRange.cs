using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of uint values.
    /// </summary>
    [System.Serializable]
    public struct UIntRange : INumberRange<uint>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private uint _min;

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private uint _max;

        /// <inheritdoc />
        public uint min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc />
        public uint max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc />
        public uint Delta => _max - _min;

        /// <inheritdoc />
        public uint Median => (_min + _max) / 2;

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
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public UIntRange(uint min, uint max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, exclusive).
        /// </summary>
        public uint Random()
        {
            return (uint)UnityEngine.Random.Range((int)_min, (int)_max);
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, inclusive].
        /// </summary>
        public uint RandomInclusive()
        {
            return (uint)UnityEngine.Random.Range((int)_min, (int)_max + 1);
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(uint value)
        {
            return value >= _min && value < _max;
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(uint value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(_min, _max, includeMin, includeMax);
        }

        /// <inheritdoc />
        /// <param name="value">The value to clamp.</param>
        public uint Clamp(uint value)
        {
            return value < _min ? _min : (value > _max ? _max : value);
        }

    }

}
