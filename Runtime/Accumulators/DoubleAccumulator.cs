namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates double values into a single total value.
    /// </summary>
    public sealed class DoubleAccumulator : ValueAccumulator<double>
    {
        protected override double Add(double value) => this.total + value;
        protected override double Subtract(double value) => this.total - value;

    }

}
