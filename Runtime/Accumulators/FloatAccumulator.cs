namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates float values into a single total value.
    /// </summary>
    public sealed class FloatAccumulator : ValueAccumulator<float>
    {
        protected override float Add(float amount) => this.total + amount;
        protected override float Subtract(float amount) => this.total - amount;
        protected override float SplitDifference(float newValue, float oldValue) => this.total + (newValue - oldValue);

    }

}
