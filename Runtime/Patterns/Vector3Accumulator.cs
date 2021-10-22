﻿using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector3 values into a single total value.
    /// </summary>
    public sealed class Vector3Accumulator : ValueAccumulator<Vector3>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Vector3Accumulator() : base()
        {
            total = Vector3.zero;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Vector3 Add(Vector3 value) => total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Vector3 Subtract(Vector3 value) => total - value;

    }

}
