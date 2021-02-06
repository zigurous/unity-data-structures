using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct EulerRange : INumberRange<float>
    {
        [Tooltip("The lower bound of the range.")]
        [Range(-360.0f, 360.0f)]
        [SerializeField]
        private float _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public float min
        {
            get => _min;
            set => _min = EulerRange.Wrap(value, -360.0f, 360.0f);
        }

        [Tooltip("The upper bound of the range.")]
        [Range(-360.0f, 360.0f)]
        [SerializeField]
        private float _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public float max
        {
            get => _max;
            set => _max = EulerRange.Wrap(value, -360.0f, 360.0f);
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
        public static EulerRange halfRange => new EulerRange(-180.0f, 180.0f);

        /// <summary>
        /// Shorthand for writing EulerRange(-360.0f, 360.0f).
        /// </summary>
        public static EulerRange fullRange => new EulerRange(-360.0f, 360.0f);

        /// <summary>
        /// Creates a new EulerRange with given min and max values.
        /// </summary>
        public EulerRange(float min = -360.0f, float max = 360.0f)
        {
            _min = EulerRange.Wrap(min, -360.0f, 360.0f);
            _max = EulerRange.Wrap(max, -360.0f, 360.0f);
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

        /// <summary>
        /// Wraps the given value between the range.
        /// </summary>
        public float Wrap(float value) => EulerRange.Wrap(value, _min, _max);

        private static float Wrap(float value, float min, float max)
        {
            if (value < min) {
                return max - (min - value) % (max - min);
            } else if (value > max) {
                return min + (value - min) % (max - min);
            } else {
                return value;
            }
        }

    }

}
