using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct FloatRange : INumberRange<float>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private float _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public float min
        {
            get => _min;
            set => _min = value;
        }

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private float _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public float max
        {
            get => _max;
            set => _max = value;
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
            _min = min;
            _max = max;
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
