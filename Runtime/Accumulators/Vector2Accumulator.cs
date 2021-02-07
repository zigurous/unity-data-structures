using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector2 values into a single total value.
    /// </summary>
    public sealed class Vector2Accumulator : ValueAccumulator<Vector2>
    {
        protected override Vector2 Add(Vector2 amount) => this.total + amount;
        protected override Vector2 Subtract(Vector2 amount) => this.total - amount;
        protected override Vector2 SplitDifference(Vector2 newValue, Vector2 oldValue) => this.total + (newValue - oldValue);

    }

}
