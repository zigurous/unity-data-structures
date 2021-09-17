using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of uint values.
    /// </summary>
    [System.Serializable]
    public struct UIntRange : INumberRange<uint>
    {
        /// <summary>
        /// Shorthand for writing <c>UIntRange(0, 0)</c>.
        /// </summary>
        public static UIntRange zero => new UIntRange(0, 0);

        /// <summary>
        /// Shorthand for writing <c>UIntRange(1, 1)</c>.
        /// </summary>
        public static UIntRange one => new UIntRange(1, 1);

        /// <summary>
        /// Shorthand for writing <c>UIntRange(uint.MinValue, uint.MaxValue)</c>.
        /// </summary>
        public static UIntRange minMax => new UIntRange(uint.MinValue, uint.MaxValue);

        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private uint _min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private uint _max;

        /// <inheritdoc/>
        public uint min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc/>
        public uint max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc/>
        public uint delta => _max - _min;

        /// <inheritdoc/>
        public uint median => (_min + _max) / 2;

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
        /// <returns>A random value in the range [inclusive, exclusive).</returns>
        public uint Random()
        {
            return (uint)UnityEngine.Random.Range((int)_min, (int)_max);
        }

        /// <summary>
        /// Returns a random value in the range [inclusive, inclusive].
        /// </summary>
        /// <returns>A random value in the range [inclusive, inclusive].</returns>
        public uint RandomInclusive()
        {
            return (uint)UnityEngine.Random.Range((int)_min, (int)_max + 1);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(uint value)
        {
            return value >= _min && value < _max;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(uint value, bool includeMin, bool includeMax)
        {
            return value.IsBetween(_min, _max, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public uint Clamp(uint value)
        {
            return value < _min ? _min : (value > _max ? _max : value);
        }

    }

}
