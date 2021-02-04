using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct Vector2Range : IRange<Vector2>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        [Tooltip("The minimum value of the range.")]
        public Vector2 min;

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        [Tooltip("The maximum value of the range.")]
        public Vector2 max;

        /// <summary>
        /// Creates a new Vector2Range with given min and max values.
        /// </summary>
        public Vector2Range(Vector2 min, Vector2 max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns a random value within the vector range.
        /// </summary>
        public Vector2 Random() => new Vector2(
            UnityEngine.Random.Range(this.min.x, this.max.x),
            UnityEngine.Random.Range(this.min.y, this.max.y));

        /// <summary>
        /// Clamps a value within the vector range.
        /// </summary>
        public Vector2 Clamp(Vector2 value) => new Vector3(
            Mathf.Clamp(value.x, this.min.x, this.max.x),
            Mathf.Clamp(value.x, this.min.y, this.max.y));

        /// <summary>
        /// Determines if a value is within the vector range
        /// (inclusive, inclusive).
        /// </summary>
        public bool Includes(Vector2 value) =>
            value.x >= this.min.x && value.x <= this.max.x &&
            value.y >= this.min.y && value.y <= this.max.y;

    }

}
