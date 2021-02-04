using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct Vector3Range : IRange<Vector3>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        [Tooltip("The minimum value of the range.")]
        public Vector3 min;

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        [Tooltip("The maximum value of the range.")]
        public Vector3 max;

        /// <summary>
        /// Creates a new Vector3Range with given min and max values.
        /// </summary>
        public Vector3Range(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Returns a random value within the vector range.
        /// </summary>
        public Vector3 Random() => new Vector3(
            UnityEngine.Random.Range(this.min.x, this.max.x),
            UnityEngine.Random.Range(this.min.y, this.max.y),
            UnityEngine.Random.Range(this.min.z, this.max.z));

        /// <summary>
        /// Clamps a value within the vector range.
        /// </summary>
        public Vector3 Clamp(Vector3 value) => new Vector3(
            Mathf.Clamp(value.x, this.min.x, this.max.x),
            Mathf.Clamp(value.x, this.min.y, this.max.y),
            Mathf.Clamp(value.x, this.min.z, this.max.z));

        /// <summary>
        /// Determines if a value is within the vector range
        /// (inclusive, inclusive).
        /// </summary>
        public bool Includes(Vector3 value) =>
            value.x >= this.min.x && value.x <= this.max.x &&
            value.y >= this.min.y && value.y <= this.max.y &&
            value.z >= this.min.z && value.z <= this.max.z;

    }

}
