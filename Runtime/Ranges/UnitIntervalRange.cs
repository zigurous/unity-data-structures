using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct UnitIntervalRange : INumberRange<float>
    {
        [Tooltip("The lower bound of the range.")]
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public float min
        {
            get => _min;
            set => _min = Mathf.Clamp01(value);
        }

        [Tooltip("The upper bound of the range.")]
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public float max
        {
            get => _max;
            set => _max = Mathf.Clamp01(value);
        }

        /// <summary>
        /// The difference between the range min and max.
        /// </summary>
        public float Delta => _max - _min;

        /// <summary>
        /// The number in the middle of the range min and max.
        /// </summary>
        public float Median => (_min + _max) / 2;

        /// <summary>
        /// Shorthand for writing UnitIntervalRange(0.0f, 0.0f).
        /// </summary>
        public static UnitIntervalRange zero => new UnitIntervalRange(0.0f, 0.0f);

        /// <summary>
        /// Shorthand for writing UnitIntervalRange(1.0f, 1.0f).
        /// </summary>
        public static UnitIntervalRange one => new UnitIntervalRange(1.0f, 1.0f);

        /// <summary>
        /// Shorthand for writing UnitIntervalRange(0.0f, 1.0f).
        /// </summary>
        public static UnitIntervalRange minMax => new UnitIntervalRange(0.0f, 1.0f);

        /// <summary>
        /// Creates a new UnitIntervalRange with given min and max values.
        /// </summary>
        public UnitIntervalRange(float min = 0.0f, float max = 1.0f)
        {
            _min = Mathf.Clamp01(min);
            _max = Mathf.Clamp01(max);
        }

        /// <summary>
        /// Determines if the given value is between the range
        /// [inclusive, inclusive].
        /// </summary>
        public bool Includes(float value) => value >= _min && value <= _max;

        /// <summary>
        /// Returns a random value between the range
        /// [inclusive, inclusive].
        /// </summary>
        public float Random() => UnityEngine.Random.Range(_min, _max);

        /// <summary>
        /// Clamps the given value between the range.
        /// </summary>
        public float Clamp(float value) => Mathf.Clamp(value, _min, _max);

    }

}
