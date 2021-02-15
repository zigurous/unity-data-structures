using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct Vector3Range : INumberRange<Vector3>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private Vector3 _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public Vector3 min
        {
            get => _min;
            set => _min = value;
        }

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private Vector3 _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public Vector3 max
        {
            get => _max;
            set => _max = value;
        }

        /// <summary>
        /// The difference between the range min and max.
        /// </summary>
        public Vector3 Delta => _max - _min;

        /// <summary>
        /// The vector in the middle of the range min and max.
        /// </summary>
        public Vector3 Median => (_min + _max) / 2;

        /// <summary>
        /// Creates a new Vector3Range with given min and max values.
        /// </summary>
        public Vector3Range(Vector3 min, Vector3 max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Determines if the given vector is between the range [inclusive,
        /// inclusive].
        /// </summary>
        public bool Includes(Vector3 value) =>
            value.x >= _min.x && value.x <= _max.x &&
            value.y >= _min.y && value.y <= _max.y &&
            value.z >= _min.z && value.z <= _max.z;

        /// <summary>
        /// Returns a random vector between the range [inclusive, inclusive].
        /// </summary>
        public Vector3 Random() => new Vector3(
            UnityEngine.Random.Range(_min.x, _max.x),
            UnityEngine.Random.Range(_min.y, _max.y),
            UnityEngine.Random.Range(_min.z, _max.z));

        /// <summary>
        /// Clamps the given vector between the range.
        /// </summary>
        public Vector3 Clamp(Vector3 value)
        {
            value.x = Mathf.Clamp(value.x, _min.x, _max.x);
            value.y = Mathf.Clamp(value.y, _min.y, _max.y);
            value.z = Mathf.Clamp(value.z, _min.z, _max.z);
            return value;
        }

    }

}
