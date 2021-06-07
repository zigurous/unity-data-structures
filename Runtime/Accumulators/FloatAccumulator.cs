namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates float values into a single total value.
    /// </summary>
    public sealed class FloatAccumulator : ValueAccumulator<float>
    {
        protected override float Add(float value) => this.total + value;
        protected override float Subtract(float value) => this.total - value;

    }

}
