﻿using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Vector3Int values into a single total value.
    /// </summary>
    public sealed class Vector3IntAccumulator : ValueAccumulator<Vector3Int>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Vector3IntAccumulator() : base()
        {
            this.total = Vector3Int.zero;
        }

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Vector3Int Add(Vector3Int value) => this.total + value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Vector3Int Subtract(Vector3Int value) => this.total - value;

    }

}
