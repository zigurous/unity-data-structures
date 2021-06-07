using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector3Int values into a single total value.
    /// </summary>
    public sealed class Vector3IntAccumulator : ValueAccumulator<Vector3Int>
    {
        protected override Vector3Int Add(Vector3Int value) => this.total + value;
        protected override Vector3Int Subtract(Vector3Int value) => this.total - value;

    }

}
