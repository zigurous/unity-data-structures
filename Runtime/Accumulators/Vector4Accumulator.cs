using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector4 values into a single total value.
    /// </summary>
    public sealed class Vector4Accumulator : ValueAccumulator<Vector4>
    {
        protected override Vector4 Add(Vector4 value) => this.total + value;
        protected override Vector4 Subtract(Vector4 value) => this.total - value;

    }

}
