namespace Zigurous.DataStructures
{
    /// <summary>A generic interface for a range of values.</summary>
    /// <typeparam name="T">The type of values in the range.</typeparam>
    public interface IRange<T>
    {
        /// <summary>
        /// The lower bound of the range.
        /// </summary>
        T min { get; set; }

        /// <summary>
        /// The upper bound of the range.
        /// </summary>
        T max { get; set; }

        /// <returns>True if the <paramref name="value"/> is in the range.</returns>
        /// <param name="value">The value to check.</param>
        bool Includes(T value);

        /// <returns>True if the <paramref name="value"/> is in the range.</returns>
        /// <param name="value">The value to check.</param>
        /// <param name="includeMin">The minimum value is inclusive if true, exclusive if false.</param>
        /// <param name="includeMax">The maximum value is inclusive if true, exclusive if false.</param>
        bool Includes(T value, bool includeMin, bool includeMax);
    }

    /// <summary>A generic interface for a range of number values.</summary>
    /// <typeparam name="T">The type of values in the range.</typeparam>
    public interface INumberRange<T> : IRange<T>
    {
        /// <returns>
        /// The difference between the maximum and minimum values.
        /// </returns>
        T Delta { get; }

        /// <returns>
        /// The median value of the range.
        /// </returns>
        T Median { get; }

        /// <returns>
        /// A random value in the range.
        /// </returns>
        T Random();

        /// <returns>The <paramref name="value"/> clamped to the range.</returns>
        /// <param name="value">The value to clamp.</param>
        T Clamp(T value);
    }

}
