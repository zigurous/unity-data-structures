namespace Zigurous.DataStructures
{
    /// <summary>
    /// A generic interface for a range of number values.
    /// </summary>
    /// <typeparam name="T">The type of values in the range.</typeparam>
    public interface INumberRange<T> : IRange<T>
    {
        /// <summary>
        /// The difference between the maximum and minimum values (Read only).
        /// </summary>
        T delta { get; }

        /// <summary>
        /// The median value of the range (Read only).
        /// </summary>
        T median { get; }

        /// <summary>
        /// Returns a random value in the range.
        /// </summary>
        /// <returns>A random value in the range.</returns>
        T Random();

        /// <summary>
        /// Clamps a value to the range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns>The clamped value.</returns>
        T Clamp(T value);
    }

}
