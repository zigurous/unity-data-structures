using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of Vector4 values.
    /// </summary>
    [System.Serializable]
    public struct Vector4Range : INumberRange<Vector4>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private Vector4 _min;

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private Vector4 _max;

        /// <inheritdoc />
        public Vector4 min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc />
        public Vector4 max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc />
        public Vector4 delta => _max - _min;

        /// <inheritdoc />
        public Vector4 median => (_min + _max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Vector4Range(Vector4 min, Vector4 max)
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc />
        public Vector4 Random()
        {
            return new Vector4(
                UnityEngine.Random.Range(_min.x, _max.x),
                UnityEngine.Random.Range(_min.y, _max.y),
                UnityEngine.Random.Range(_min.z, _max.z),
                UnityEngine.Random.Range(_min.w, _max.w));
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector4 value)
        {
            return value.x >= _min.x && value.x <= _max.x &&
                   value.y >= _min.y && value.y <= _max.y &&
                   value.z >= _min.z && value.z <= _max.z &&
                   value.w >= _min.w && value.w <= _max.w;
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector4 value, bool includeMin, bool includeMax)
        {
            return value.x.IsBetween(_min.x, _max.x, includeMin, includeMax) &&
                   value.y.IsBetween(_min.y, _max.y, includeMin, includeMax) &&
                   value.z.IsBetween(_min.z, _max.z, includeMin, includeMax) &&
                   value.w.IsBetween(_min.w, _max.w, includeMin, includeMax);
        }

        /// <inheritdoc />
        /// <param name="value">The value to clamp.</param>
        public Vector4 Clamp(Vector4 value)
        {
            value.x = Mathf.Clamp(value.x, _min.x, _max.x);
            value.y = Mathf.Clamp(value.y, _min.y, _max.y);
            value.z = Mathf.Clamp(value.z, _min.z, _max.z);
            value.w = Mathf.Clamp(value.w, _min.w, _max.w);
            return value;
        }

    }

}
