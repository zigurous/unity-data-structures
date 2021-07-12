using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of Vector3 values.
    /// </summary>
    [System.Serializable]
    public struct Vector3Range : INumberRange<Vector3>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private Vector3 _min;

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private Vector3 _max;

        /// <inheritdoc />
        public Vector3 min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc />
        public Vector3 max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc />
        public Vector3 Delta => _max - _min;

        /// <inheritdoc />
        public Vector3 Median => (_min + _max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Vector3Range(Vector3 min, Vector3 max)
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc />
        public Vector3 Random()
        {
            return new Vector3(
                UnityEngine.Random.Range(_min.x, _max.x),
                UnityEngine.Random.Range(_min.y, _max.y),
                UnityEngine.Random.Range(_min.z, _max.z));
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector3 value)
        {
            return value.x >= _min.x && value.x <= _max.x &&
                   value.y >= _min.y && value.y <= _max.y &&
                   value.z >= _min.z && value.z <= _max.z;
        }

        /// <inheritdoc />
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector3 value, bool includeMin, bool includeMax)
        {
            return value.x.IsBetween(_min.x, _max.x, includeMin, includeMax) &&
                   value.y.IsBetween(_min.y, _max.y, includeMin, includeMax) &&
                   value.z.IsBetween(_min.z, _max.z, includeMin, includeMax);
        }

        /// <inheritdoc />
        /// <param name="value">The value to clamp.</param>
        public Vector3 Clamp(Vector3 value)
        {
            value.x = Mathf.Clamp(value.x, _min.x, _max.x);
            value.y = Mathf.Clamp(value.y, _min.y, _max.y);
            value.z = Mathf.Clamp(value.z, _min.z, _max.z);
            return value;
        }

    }

}
