using System.Text;
using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Represents how a number is abbreviated to a string.
        /// </summary>
        [System.Serializable]
        public struct NumberAbbreviation
        {
            /// <summary>
            /// The number factor after which the abbreviation is applied.
            /// </summary>
            [Tooltip("The number factor after which the abbreviation is applied.")]
            public float factor;

            /// <summary>
            /// The string format of the abbreviated number.
            /// </summary>
            [Tooltip("The string format of the abbreviated number.")]
            public string format;

            /// <summary>
            /// Creates a new number abbreviation with the given
            /// <paramref name="factor"/> and <paramref name="format"/>.
            /// </summary>
            /// <param name="factor">The number factor after which the abbreviation is applied.</param>
            /// <param name="format">The string format of the abbreviated number.</param>
            public NumberAbbreviation(float factor, string format)
            {
                this.factor = factor;
                this.format = format;
            }

        }

        /// <summary>
        /// A pre-defined set of number abbreviations.
        /// </summary>
        private static readonly NumberAbbreviation[] abbreviations = new NumberAbbreviation[4] {
            new NumberAbbreviation(1_000_000_000_000, "0T"),
            new NumberAbbreviation(1_000_000_000, "0B"),
            new NumberAbbreviation(1_000_000, "0M"),
            new NumberAbbreviation(1_000, "0K"),
        };

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

        /// <summary>
        /// Converts the number to an abbreviated string.
        /// </summary>
        /// <param name="number">The number to abbreviate.</param>
        /// <returns>A new string of the abbreviated number.</returns>
        public static string ToAbbreviatedString(this float number)
        {
            return ToAbbreviatedString(number, StringExtensions.abbreviations);
        }

        /// <summary>
        /// Converts the number to an abbreviated string using the provided
        /// <paramref name="abbreviations"/>.
        /// </summary>
        /// <param name="number">The number to abbreviate.</param>
        /// <param name="abbreviations">The abbreviations that can be applied to the number.</param>
        /// <returns>A new string of the abbreviated number.</returns>
        public static string ToAbbreviatedString(this float number, NumberAbbreviation[] abbreviations)
        {
            float abs = System.Math.Abs(number);

            for (int i = 0; i < abbreviations.Length; i++)
            {
                NumberAbbreviation abbreviation = abbreviations[i];

                if (abs >= abbreviation.factor) {
                    return (number / abbreviation.factor).ToString(abbreviation.format);
                }
            }

            return number.ToString();
        }

    }

}
