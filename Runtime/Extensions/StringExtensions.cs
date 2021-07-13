using System.Text;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// A reusable string builder.
        /// </summary>
        private static StringBuilder stringBuilder;

        /// <summary>
        /// Checks if the string is null or empty.
        /// </summary>
        /// <param name="str">The string to test.</param>
        public static bool IsEmpty(this string str)
        {
            return str == null || str.Length <= 0;
        }

        /// <summary>
        /// Checks if the string is not null and not empty.
        /// </summary>
        /// <param name="str">The string to test.</param>
        public static bool IsNotEmpty(this string str)
        {
            return str != null && str.Length > 0;
        }

        /// <summary>
        /// Repeats the string <paramref name="n"/> times.
        /// </summary>
        /// <param name="str">The string to repeat.</param>
        /// <param name="n">The number of times to repeat the string.</param>
        /// <returns>A new repeated string.</returns>
        public static string Repeat(this string str, int n)
        {
            if (stringBuilder == null) {
                stringBuilder = new StringBuilder();
            } else {
                stringBuilder.Clear();
            }

            stringBuilder.Capacity = str.Length * n;
            stringBuilder.Insert(0, str, n);
            return stringBuilder.ToString();
        }

    }

}
