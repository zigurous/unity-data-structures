using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector3 values into a single total value.
    /// </summary>
    public sealed class Vector3Accumulator : ValueAccumulator<Vector3>
    {
        protected override Vector3 Add(Vector3 amount) => this.total + amount;
        protected override Vector3 Subtract(Vector3 amount) => this.total - amount;
        protected override Vector3 SplitDifference(Vector3 newValue, Vector3 oldValue) => this.total + (newValue - oldValue);

    }

}
