using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct UIntRange : INumberRange<uint>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private uint _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public uint min
        {
            get => _min;
            set => _min = value;
        }

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private uint _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public uint max
        {
            get => _max;
            set => _max = value;
        }

        /// <summary>
        /// The difference between the range min and max.
        /// </summary>
        public uint Delta => _max - _min;

        /// <summary>
        /// The number in the middle of the range min and max.
        /// </summary>
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
        /// Creates a new UIntRange with given min and max values.
        /// </summary>
        public UIntRange(uint min, uint max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Determines if the given value is between the range [inclusive,
        /// exclusive).
        /// </summary>
        public bool Includes(uint value) => value >= _min && value < _max;

        /// <summary>
        /// Determines if the given value is between the range using a custom
        /// inclusive/exclusive combination.
        /// </summary>
        public bool Includes(uint value, bool includeMin, bool includeMax) => value.IsBetween(_min, _max, includeMin, includeMax);

        /// <summary>
        /// Returns a random value between the range [inclusive, exclusive).
        /// </summary>
        public uint Random() => (uint)UnityEngine.Random.Range((int)_min, (int)_max);

        /// <summary>
        /// Returns a random value between the range [inclusive, inclusive].
        /// </summary>
        public uint RandomInclusive() => (uint)UnityEngine.Random.Range((int)_min, (int)_max + 1);

        /// <summary>
        /// Clamps the given value between the range.
        /// </summary>
        public uint Clamp(uint value) => value < _min ? _min : (value > _max ? _max : value);

    }

}
