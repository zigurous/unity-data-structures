namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates int values into a single total value.
    /// </summary>
    public sealed class IntAccumulator : ValueAccumulator<int>
    {
        protected override int Add(int value) => this.total + value;
        protected override int Subtract(int value) => this.total - value;

    }

}
