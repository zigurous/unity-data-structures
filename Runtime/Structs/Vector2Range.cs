using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A range of Vector2 values.
    /// </summary>
    [System.Serializable]
    public struct Vector2Range : INumberRange<Vector2>
    {
        [SerializeField]
        [Tooltip("The lower bound of the range.")]
        private Vector2 _min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private Vector2 _max;

        /// <inheritdoc/>
        public Vector2 min
        {
            get => _min;
            set => _min = value;
        }

        /// <inheritdoc/>
        public Vector2 max
        {
            get => _max;
            set => _max = value;
        }

        /// <inheritdoc/>
        public Vector2 delta => _max - _min;

        /// <inheritdoc/>
        public Vector2 median => (_min + _max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Vector2Range(Vector2 min, Vector2 max)
        {
            _min = min;
            _max = max;
        }

        /// <inheritdoc/>
        public Vector2 Random()
        {
            return new Vector2(
                UnityEngine.Random.Range(_min.x, _max.x),
                UnityEngine.Random.Range(_min.y, _max.y));
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector2 value)
        {
            return value.x >= _min.x && value.x <= _max.x &&
                   value.y >= _min.y && value.y <= _max.y;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector2 value, bool includeMin, bool includeMax)
        {
            return value.x.IsBetween(_min.x, _max.x, includeMin, includeMax) &&
                   value.y.IsBetween(_min.y, _max.y, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public Vector2 Clamp(Vector2 value)
        {
            value.x = Mathf.Clamp(value.x, _min.x, _max.x);
            value.y = Mathf.Clamp(value.y, _min.y, _max.y);
            return value;
        }

    }

}
