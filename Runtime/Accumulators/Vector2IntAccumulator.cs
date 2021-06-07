using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector2Int values into a single total value.
    /// </summary>
    public sealed class Vector2IntAccumulator : ValueAccumulator<Vector2Int>
    {
        protected override Vector2Int Add(Vector2Int value) => this.total + value;
        protected override Vector2Int Subtract(Vector2Int value) => this.total - value;

    }

}
