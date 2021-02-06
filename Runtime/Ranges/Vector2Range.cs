using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct Vector2Range : INumberRange<Vector2>
    {
        [Tooltip("The lower bound of the range.")]
        [SerializeField]
        private Vector2 _min;

        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        public Vector2 min
        {
            get => _min;
            set => _min = value;
        }

        [Tooltip("The upper bound of the range.")]
        [SerializeField]
        private Vector2 _max;

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        public Vector2 max
        {
            get => _max;
            set => _max = value;
        }

        /// <summary>
        /// The difference between the range min and max.
        /// </summary>
        public Vector2 Delta => _max - _min;

        /// <summary>
        /// The vector in the middle of the range min and max.
        /// </summary>
        public Vector2 Median => (_min + _max) / 2;

        /// <summary>
        /// Creates a new Vector2Range with given min and max values.
        /// </summary>
        public Vector2Range(Vector2 min, Vector2 max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Determines if the given vector is between the range
        /// [inclusive, inclusive].
        /// </summary>
        public bool Includes(Vector2 value) =>
            value.x >= _min.x && value.x <= _max.x &&
            value.y >= _min.y && value.y <= _max.y;

        /// <summary>
        /// Returns a random vector between the range
        /// [inclusive, inclusive].
        /// </summary>
        public Vector2 Random() => new Vector2(
            UnityEngine.Random.Range(_min.x, _max.x),
            UnityEngine.Random.Range(_min.y, _max.y));

        /// <summary>
        /// Clamps the given vector between the range.
        /// </summary>
        public Vector2 Clamp(Vector2 value)
        {
            value.x = Mathf.Clamp(value.x, _min.x, _max.x);
            value.y = Mathf.Clamp(value.y, _min.y, _max.y);
            return value;
        }

    }

}
