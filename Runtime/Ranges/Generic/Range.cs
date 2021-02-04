namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct Range<T>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        public T min;

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        public T max;

        /// <summary>
        /// Creates a new Range with given min and max values.
        /// </summary>
        public Range(T min = default(T), T max = default(T))
        {
            this.min = min;
            this.max = max;
        }

    }

}
