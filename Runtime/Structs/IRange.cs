namespace Zigurous.DataStructures
{
    /// <summary>
    /// A generic interface for a range of values.
    /// </summary>
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

        /// <summary>
        /// Checks if a value is in the range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the value is in the range, false otherwise.</returns>
        bool Includes(T value);

        /// <summary>
        /// Checks if a value is in the range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="includeMin">The minimum value is inclusive if true, exclusive if false.</param>
        /// <param name="includeMax">The maximum value is inclusive if true, exclusive if false.</param>
        /// <returns>True if the value is in the range, false otherwise.</returns>
        bool Includes(T value, bool includeMin, bool includeMax);
    }

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
