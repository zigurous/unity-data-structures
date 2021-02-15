using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct ClampedRange : INumberRange<float>
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
            set => _min = this.clamp.Clamp(value);
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
            set => _max = this.clamp.Clamp(value);
        }

        /// <summary>
        /// The clamping values of the range.
        /// </summary>
        [Tooltip("The clamping values of the range.")]
        public FloatRange clamp;

        /// <summary>
        /// The difference between the range min and max.
        /// </summary>
        public float Delta => _max - _min;

        /// <summary>
        /// The number in the middle of the range min and max.
        /// </summary>
        public float Median => (_min + _max) / 2;

        /// <summary>
        /// Creates a new ClampedRange with given min and max values and a lower
        /// and upper clamp.
        /// </summary>
        public ClampedRange(float min = 0.0f, float max = 1.0f, float clampLower = 0.0f, float clampUpper = 1.0f)
        {
            FloatRange clamp = new FloatRange(clampLower, clampUpper);
            this.clamp = clamp;

            _min = clamp.Clamp(min);
            _max = clamp.Clamp(max);
        }

        /// <summary>
        /// Determines if the given value is between the range [inclusive,
        /// inclusive].
        /// </summary>
        public bool Includes(float value) => value >= _min && value <= _max;

        /// <summary>
        /// Returns a random value between the range [inclusive, inclusive].
        /// </summary>
        public float Random() => UnityEngine.Random.Range(_min, _max);

        /// <summary>
        /// Clamps the given value between the range.
        /// </summary>
        public float Clamp(float value) => Mathf.Clamp(value, _min, _max);

    }

}
