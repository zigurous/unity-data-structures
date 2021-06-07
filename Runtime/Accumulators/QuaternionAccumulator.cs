using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates Quaternion values into a single total value.
    /// </summary>
    public sealed class QuaternionAccumulator : ValueAccumulator<Quaternion>
    {
        public QuaternionAccumulator() : base()
        {
            this.total = Quaternion.identity;
        }

        protected override Quaternion Add(Quaternion value) => this.total * value;
        protected override Quaternion Subtract(Quaternion value) => this.total * Quaternion.Inverse(value);

    }

}
