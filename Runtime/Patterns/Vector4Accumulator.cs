﻿using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector4 values into a single total value.
    /// </summary>
    public sealed class Vector4Accumulator : ValueAccumulator<Vector4>
    {
        /// <inheritdoc />
        /// <param name="value">The value to add to the total.</param>
        protected override Vector4 Add(Vector4 value) => this.total + value;

        /// <inheritdoc />
        /// <param name="value">The value to subtract from the total.</param>
        protected override Vector4 Subtract(Vector4 value) => this.total - value;

    }

}