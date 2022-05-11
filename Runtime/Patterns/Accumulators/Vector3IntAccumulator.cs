﻿using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector3Int values into a single total value.
    /// </summary>
    public sealed class Vector3IntAccumulator : ValueAccumulator<Vector3Int>
    {
        /// <inheritdoc/>
        protected override Vector3Int defaultValue => Vector3Int.zero;

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Vector3Int Add(Vector3Int value) => total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Vector3Int Subtract(Vector3Int value) => total - value;
    }

}
