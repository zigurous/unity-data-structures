﻿using UnityEngine;

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
        private Vector2 m_Min;

        [SerializeField]
        [Tooltip("The upper bound of the range.")]
        private Vector2 m_Max;

        /// <inheritdoc/>
        public Vector2 min
        {
            get => m_Min;
            set => m_Min = value;
        }

        /// <inheritdoc/>
        public Vector2 max
        {
            get => m_Max;
            set => m_Max = value;
        }

        /// <inheritdoc/>
        public Vector2 delta => max - min;

        /// <inheritdoc/>
        public Vector2 median => (min + max) / 2;

        /// <summary>
        /// Creates a new range with the specified values.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public Vector2Range(Vector2 min, Vector2 max)
        {
            m_Min = min;
            m_Max = max;
        }

        /// <inheritdoc/>
        public Vector2 Random()
        {
            return new Vector2(
                UnityEngine.Random.Range(min.x, max.x),
                UnityEngine.Random.Range(min.y, max.y));
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector2 value)
        {
            return value.x >= min.x && value.x <= max.x &&
                   value.y >= min.y && value.y <= max.y;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to check.</param>
        public bool Includes(Vector2 value, bool includeMin, bool includeMax)
        {
            return value.x.IsBetween(min.x, max.x, includeMin, includeMax) &&
                   value.y.IsBetween(min.y, max.y, includeMin, includeMax);
        }

        /// <inheritdoc/>
        /// <param name="value">The value to clamp.</param>
        public Vector2 Clamp(Vector2 value)
        {
            value.x = Mathf.Clamp(value.x, min.x, max.x);
            value.y = Mathf.Clamp(value.y, min.y, max.y);
            return value;
        }

    }

}
