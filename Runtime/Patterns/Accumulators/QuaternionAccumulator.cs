﻿using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Quaternion values into a single total value.
    /// </summary>
    public sealed class QuaternionAccumulator : ValueAccumulator<Quaternion>
    {
        /// <inheritdoc/>
        protected override Quaternion defaultValue => Quaternion.identity;

        /// <inheritdoc/>
        /// <param name="value">The value to add to the total.</param>
        protected override Quaternion Add(Quaternion value) => total * value;

        /// <inheritdoc/>
        /// <param name="value">The value to subtract from the total.</param>
        protected override Quaternion Subtract(Quaternion value) => total * Quaternion.Inverse(value);
    }

}
